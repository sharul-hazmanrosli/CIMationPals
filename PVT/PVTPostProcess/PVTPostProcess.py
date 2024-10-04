import tkinter as tk
from tkinter import ttk
from tkinter import filedialog
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import (FigureCanvasTkAgg, NavigationToolbar2Tk)
import numpy as np
import webcolors
import glob
import os
import sys
from adjustText import adjust_text
from PIL import Image,ImageTk
import re

# Global variables
TEST_TYPE = 'Pressure' # Test type, can be 'Decay' or 'Pressure'
CHANNEL = 'all'
CHANNEL_NAMES = ["magenta", "cyan", "yellow", "k (black)"]
SERIAL_NUMBER = "NA"
RUN_NUMBER = "NA"
source_path = ""
destination_path = ""
log_file = ""
serial_numbers_list = ["NA"]
run_numbers_list = ["NA"]
new_log_file = True
lbl_img = None
current_help = "help_about"
toggle_annotation = True
serial_number_pattern = r'\d{2}_(.{14})_(\d{1,2})' # \d{2}: matches 2 digts, .{14}: any char 14 times, \d{2}: matches 2 digits
station_number_pattern = r'LX.*?_\d{1,2}'
current_selection = {"f1_station":"NA","f2_station":"NA","f3_station":"NA","f1_serial_number":"NA","f2_serial_number":"NA","f3_serial_number":"NA","f1_run_number":"NA","f2_run_number":"NA","f3_run_number":"NA"}
# Default test result, contains various parameters with default values
test_result_default = {'SamplingHz': 'NA', 'Number Samples': 'NA', 'Mech2TestPrimingPressure': -1, 'sampling_rate': 'NA', 'maxP_magenta': 'NA', 'maxP_cyan': 'NA', 'maxP_yellow': 'NA', 'maxP_black': 'NA', 'maxP_within_range': -1,
                       'pressure_vent_delay': 'NA', 'pressure_vent_rate': 'NA', 'pressure_vent_delay_result': -1, 'pressure_vent_rate_result': -1,
                       'pressure_vent_delay_UL': 'NA', 'pressure_vent_delay_LL': 'NA', 'pressure_vent_rate_UL': 'NA', 'pressure_vent_rate_LL': 'NA',
                       'decay_rate': 'NA', 'decay_vent_rate': 'NA', 'decay_rate_result': -1, 'decay_vent_rate_result': -1,
                       'decay_rate_UL': 'NA', 'decay_rate_LL': 'NA', 'decay_vent_rate_UL': 'NA', 'decay_vent_rate_LL': 'NA'}
test_result = test_result_default.copy()  # initialize dictionary test_result with default values
# Update matplotlib configuration to suppress warning when opening multiple figures
plt.rcParams.update({'figure.max_open_warning': 0})

# main window
root = tk.Tk()
root.title("PVT Post Process Tool")
root.geometry("890x740") # set window size
root.resizable(False,False) # fix window drag size
menubar = tk.Menu(root) # Create a new menu bar
root.config(menu=menubar) # Configure the root window to use the created menu bar

def exit_button_press():        # function to properly close if executed from CIMation
    current_pid = os.getpid()   # Kill through the program's process ID
    os.kill(current_pid, 9)     # 9 corresponds to the SIGKILL signal
root.protocol("WM_DELETE_WINDOW", exit_button_press)


tab_style = ttk.Style() # Creaet tab style
tab_style.theme_use('winnative') #winnative(abit white and pop out tab)
tab_style.configure('TNotebook.Tab', font=('Arial', '12'), borderwidth = 2) # Configure the font of the tab text

# Create tabs
tab_control = ttk.Notebook(root)
home_tab = ttk.Frame(tab_control) 
help_tab = ttk.Frame(tab_control)
current_tab = ttk.Frame()

# create empty tkinter canvas
canvas = FigureCanvasTkAgg()

# set minsize and weight for each row and column for home_tab
home_tab.rowconfigure(0,minsize=10,weight=1)
home_tab.rowconfigure(1, minsize=310, weight=1) # change back to 400, 310, 450
home_tab.rowconfigure(2, minsize=250, weight=1)
home_tab.rowconfigure(3, minsize=100, weight=1)
home_tab.columnconfigure(0, minsize=20, weight=1)
home_tab.columnconfigure(1, minsize=640, weight=1)
home_tab.columnconfigure(2, minsize=240, weight=1)

#help_tab.columnconfigure(0, minsize=40, weight=1)
help_tab.columnconfigure(1, minsize=20, weight=1)
#help_tab.columnconfigure(2, minsize=1, weight=1)
#help_tab.grid_rowconfigure(0, weight=1)

# configure the grid
def configure_grid(widget):
    rows, columns = widget.grid_size()
    # Configure rows and columns to expand equally when the widget is resized
    for row in range(rows):
        widget.rowconfigure(row, weight=1)
    for column in range(columns):
        widget.columnconfigure(column, weight=1)
    # If the widget is a frame, also configure its children
    if isinstance(widget, tk.Frame):
        for child in widget.winfo_children():
            child.grid(sticky='nsew')
            rows, columns = child.grid_size()
            configure_grid(child)


def select_directory():
    try:
        global source_path,SERIAL_NUMBER,RUN_NUMBER,SERIAL_NUMBER_COMP,RUN_NUMBER_COMP,STATION_NUMBER_COMP, log_file,CHANNEL
        directory = filedialog.askdirectory(title=f"Select Source Directory")
        if directory != "":  # if user click cancel, directory will be empty string
            new_source_path = directory.replace('/', '\\')
            if source_path != new_source_path:
                source_path = new_source_path
                # reset SERIAL NUMBER and RUN NUMBER to NA
                SERIAL_NUMBER = "NA"
                RUN_NUMBER = "NA"
                log_file = ""
                CHANNEL = 'all'
            main_GUI()
    except Exception as e:
        print(f"An error occurred: {e}")


def update_serial_numbers_list():
    try:
        global serial_numbers_list, station_list_comp
        # from source_path, filter only .log files
        files = os.listdir(source_path)
        files = [file for file in files if file.endswith(".log")]
        serial_numbers_list = []
        # get the unique serial numbers from the files
        for file in files:
            match = re.search(serial_number_pattern,file)
            if match:
                serial_numbers_list.append(match.group(1))
            else:
                serial_numbers_list.append(file.split('\\')[-1].split('_')[0])
        serial_numbers_list = list(set(serial_numbers_list))
        if len(serial_numbers_list) > 1:
            serial_numbers_list.sort()          
    except FileNotFoundError:
        print(f"Directory {source_path} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")


def update_run_numbers_list():
    try:
        global run_numbers_list, SERIAL_NUMBER, new_log_file
        # from source_path, filter all the files start with serial_number
        files = os.listdir(source_path)
        files = [file for file in files if SERIAL_NUMBER in file and file.endswith(".log")]
        # check if files list is not empty to avoid IndexError
        if files:
            run_numbers_list = []
            # get the first file in files, if after splitting by _ the items count is 9
            if len(files[0].split('\\')[-1].split('_')) >= 9:
                if len(files[0].split('\\')[-1].split('_')) == 9:
                    # filter files that contain 9 items after splitting by _
                    files = [file for file in files if len(file.split('\\')[-1].split('_')) == 9]
                    # get the unique run numbers from the files, run number is the 2nd part of the file name
                    run_numbers_list = list(set([file.split('\\')[-1].split('_')[1] for file in files]))                    
                else:
                    for file in files:
                        match = re.search(serial_number_pattern,file)
                        if match:
                            run_numbers_list.append(match.group(2))
                        else:
                            run_numbers_list.append(file.split('\\')[-1].split('_')[0])
                    run_numbers_list = list(set(run_numbers_list))                    
                new_log_file = True
            else:
                run_numbers_list = ["NA"]
                new_log_file = False

            if len(run_numbers_list) > 1:
                run_numbers_list.sort(reverse=True) # sort descending order
        else:
            print("No files found with the given serial number.")
    except FileNotFoundError:
        print(f"Directory {source_path} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")


def on_serial_number_selected(*args):
    global run_numbers_list, SERIAL_NUMBER, RUN_NUMBER
    SERIAL_NUMBER = args[0].get() # Get the selected serial number from the first argument
    print(f"The selected option is {SERIAL_NUMBER}")
    # Update the list of run numbers based on the selected serial number
    update_run_numbers_list() 
    RUN_NUMBER = run_numbers_list[0] # Set the current run number to the first run number in the list
    main_GUI() # Update the GUI


def on_run_number_selected(*args):
    global RUN_NUMBER, run_numbers_list
    # Get the selected run number from the first argument
    RUN_NUMBER = args[0].get()
    print(f"The selected option is {RUN_NUMBER}")
    main_GUI() # Update the GUI


def color_name_to_hex(color_name):
    if color_name == 'k (black)':
        color_name = 'black'
    try:
        # Get the hexadecimal representation of the color name
        hex_value = webcolors.name_to_hex(color_name)
        if color_name == 'yellow':
            hex_value = '#9B870C'
        return hex_value
    except ValueError:
        # Handle the case when the color name is not valid
        return None


def obtain_latest_file(test_type):
    if test_type == "":
        test_type = TEST_TYPE
    test_type = test_type.capitalize() + 'Test'
    # Use glob to find files matching the pattern '*PressureTest.log'
    test_name = '*' + test_type + '.log'
    files = glob.glob(os.path.join(source_path, test_name))

    # If test file exist, use latest ; else exit
    if files:
        latest_test_file = max(files, key=os.path.getmtime)  # Sort files based on modification time (latest file first)
        return latest_test_file
    else:
        print(f"Error: No {test_name} file found")

# function to be called when an option is selected
def on_option_selected(*args): # *args is a tuple, args[0] is the selected_option, args[1] is the selector name
    global CHANNEL, TEST_TYPE
    print(f"The selected option is {args[0].get()}")
    if args[1] == "Test":
        TEST_TYPE = args[0].get()
        load_log_file(TEST_TYPE)
        plot(CHANNEL)
    else: # if channel is selected
        plot(args[0].get())
    bottom_bar_GUI()


def on_tab_change(event):
    global current_tab
    current_tab = get_current_tab()
    print(f"The current tab is {current_tab}")

def dropdown_menu(from_tab, select, options_input, frm_selection, row_index, col_index, callback_function):
    global CHANNEL, TEST_TYPE, SERIAL_NUMBER, RUN_NUMBER

    options = options_input # Define the options for the dropdown

    if select[-1].isdigit():
        index = int(select[-1])-1
    selected_option = tk.StringVar(frm_selection)
    if select == "Channel":
        selected_option.set(CHANNEL)
    elif select == "Test":
        selected_option.set(TEST_TYPE)
    elif select == "Serial Number":
        selected_option.set(SERIAL_NUMBER)
    elif select == "Run Number":
        selected_option.set(RUN_NUMBER)

    # Call the callback function when the value of the selected option changes
    selected_option.trace_add("write", lambda *args: callback_function(selected_option, select))
    # Create the dropdown
    dropdown_channel = tk.OptionMenu(frm_selection, selected_option, *options)
    dropdown_channel.grid(row=row_index, column=col_index, sticky="nw")
    if str(from_tab) == 'compare_tab':
        dropdown_channel.config(font=("Arial", 13), width=14)
    else:
        dropdown_channel.config(font=("Arial", 14), width=15) 


def extract_test_result(test_type):
    global test_result
    if test_type == "":
        test_type = TEST_TYPE
    pressure_test_file = ""
    decay_test_file = ""
    if SERIAL_NUMBER == "NA" and RUN_NUMBER == "NA":  # first time load log_file
        try:
            # get latest results from both pressure and decay test
            pressure_test_file = obtain_latest_file('pressure')
            decay_test_file = obtain_latest_file('decay')
        except Exception as e:
            print(f"An error occurred: {e} in extract_test_result")
    else:
        if RUN_NUMBER == "NA":
            # get latest result for that serial number
            pressure_test_file = '*'+SERIAL_NUMBER+'_' +'*' + 'PressureTest.log'
            decay_test_file = '*'+SERIAL_NUMBER+'_' +'*' + 'DecayTest.log'
        else:
            pressure_test_file = '*'+SERIAL_NUMBER+'_' + str(RUN_NUMBER)+'*' + 'PressureTest.log'
            decay_test_file = '*'+SERIAL_NUMBER+'_' + str(RUN_NUMBER)+'*' + 'DecayTest.log'
        # Use glob to find files matching the pattern 'SERIAL_NUMBER+'_'+RUN_NUMBER+*PressureTest.log'
        files = glob.glob(os.path.join(source_path, pressure_test_file))
        # If test file exist, use latest ; else exit
        if files:
            # Sort files based on modification time (latest file first)
            pressure_test_file = max(files, key=os.path.getmtime)
        else:
            print(f"Error: No {pressure_test_file} file found")
        # Use glob to find files matching the pattern 'SERIAL_NUMBER+'_'+RUN_NUMBER+*DecayTest.log'
        files = glob.glob(os.path.join(source_path, decay_test_file))
        # If test file exist, use latest ; else exit
        if files:
            # Sort files based on modification time (latest file first)
            decay_test_file = max(files, key=os.path.getmtime)
        else:
            print(f"Error: No {decay_test_file} file found")
    # extract test_result from pressure_test_file
    with open(pressure_test_file, 'r') as file:
        lines = file.readlines()
        # find index of line that starts with Colors:
        channel_index = [i for i, line in enumerate(lines) if line.startswith('Colors:')][0]
        for i in range(channel_index):
            line = lines[i].strip()
            #check if line is empty
            if line == '':
                continue
            key = line.split(':')[0].strip()
            value = line.split(':')[1].strip()
            # if value is float, round to 2 decimal place
            if type(value) == float:
                value = round(float(value), 2)
            test_result[key] = value
    # extract test_result from decay_test_file
    with open(decay_test_file, 'r') as file:
        lines = file.readlines()
        # find index of line that starts with Colors:
        channel_index = [i for i, line in enumerate(lines) if line.startswith('Colors:')][0]
        for i in range(channel_index):
            line = lines[i].strip()
            #check if line is empty
            if line == '':
                continue
            key = line.split(':')[0].strip()
            value = line.split(':')[1].strip()  
            # if value is float, round to 2 decimal place
            if type(value) == float:
                value = round(float(value), 2)            
            test_result[key] = value
    if test_type == 'Pressure':
        return pressure_test_file
    else:
        return decay_test_file
    

def load_log_file(test_type):
    try:
        global log_file, SERIAL_NUMBER, RUN_NUMBER, new_log_file,test_result
        if test_type == "":
            test_type = TEST_TYPE
        # extract test_result from log_file
        log_file = extract_test_result(test_type)
        # check if no log_file is found
        if log_file == "":
            return    
        # check if log_file is logging test result
        elif len(log_file.split('\\')[-1].split('_')) < 9:
            new_log_file = False
        else:
            new_log_file = True
        if new_log_file:
            if SERIAL_NUMBER == "NA":
                RUN_NUMBER = re.search(r'\d{2}_(.{14})_(\d{1,2})',log_file).group(2)
            SERIAL_NUMBER = re.search(r'\d{2}_(.{14})_(\d{1,2})',log_file).group(1)
        else:
            test_result = test_result_default.copy() # set test_result to default
            SERIAL_NUMBER = log_file.split('\\')[-1].split('_')[0]
    except IndexError:
        print("Error: Unable to split log file name.")
        log_file = ""
    except Exception as e:
        print(f"An error occurred: {e}")
        log_file = ""


def plot(channel):
    global log_file,TEST_TYPE, CHANNEL, canvas
    if channel == "":
        channel = CHANNEL    
    texts = []
    data = np.loadtxt(log_file, skiprows=54, dtype=float, delimiter=',')
    # Get channel names from Row 3 of log file
    with open(log_file, 'r') as file:
        lines = file.readlines()
        # find index of line that starts with Colors:
        channel_index = [i for i, line in enumerate(lines) if line.startswith('Colors:')][0]
    CHANNEL_NAMES = (str(lines[channel_index].strip().split(':')[1]).strip().lower()).split(',')

    fig = plt.figure(figsize=(6.5, 4), dpi=100) # originally (6.5, 5)
    ax = fig.add_subplot()

    x_data = data[:, 0]

    if channel == 'all':
        # plot all channels
        for column in CHANNEL_NAMES:
            y_data = data[:, CHANNEL_NAMES.index(column)+1]
            ax.plot(x_data, y_data, label=column, color=color_name_to_hex(column))
    else:
        y_data = data[:, CHANNEL_NAMES.index(channel)+1]
        start_rise_pressure,start_vent_time_pressure,stop_vent_time_pressure,start_decay_time,stop_decay_time,start_vent_time,stop_vent_time = 0,0,0,0,0,0,0

        # plot selected channel
        ax.plot(x_data, y_data, label=channel, color=color_name_to_hex(channel))

        # Get the maximum y value and its index
        ymax = max(y_data)
        # format ymax to 1 decimal place
        ymax = round(ymax, 1)
        xmax = x_data[y_data.argmax()]

        if toggle_annotation:
            texts.append(plt.text(xmax, ymax, f"maxP({xmax},{ymax})", fontsize=8))  

        if new_log_file:
            if channel == 'k (black)':
                temp = 'black'
            else:
                temp = channel # temp is the channel name
            start_rise_time = float(test_result['start_rise_time'+'_'+temp])
            start_vent_pressure = float(test_result['start_vent_pressure'+'_'+temp])
            stop_vent_pressure = float(test_result['stop_vent_pressure'+'_'+temp])
            start_decay = float(test_result['start_decay'+'_'+temp])
            stop_decay= float(test_result['stop_decay'+'_'+temp])
            start_vent = float(test_result['start_vent'+'_'+temp])
            stop_vent = float(test_result['stop_vent'+'_'+temp])
            for x,y in np.column_stack((x_data, y_data)): # loop through x_data and y_data, get corresponding x and y value
                if x == start_rise_time:
                    start_rise_pressure = float(y)
                if y == start_vent_pressure:
                    start_vent_time_pressure = int(x)
                if y == stop_vent_pressure:
                    stop_vent_time_pressure = int(x)
                if y >= start_decay and start_decay_time == 0:
                    start_decay_time = int(x)
                if y >= stop_decay and stop_decay_time == 0:
                    stop_decay_time = int(x)
                if y == start_vent:
                    start_vent_time = int(x)
                if y == stop_vent:
                    stop_vent_time = int(x)
            if TEST_TYPE == 'Pressure' and toggle_annotation:
                # annotate the values in (x,y) format
                texts.append(plt.text(start_rise_time, start_rise_pressure, f"start_rise\n({start_rise_time},{round(start_rise_pressure,1)})", fontsize=8))
                texts.append(plt.text(start_vent_time_pressure, start_vent_pressure, f"start_vent\n({start_vent_time_pressure},{round(start_vent_pressure,1)})", fontsize=8))
                texts.append(plt.text(stop_vent_time_pressure, stop_vent_pressure, f"stop_vent\n({stop_vent_time_pressure},{round(stop_vent_pressure,1)})", fontsize=8))                              
            elif TEST_TYPE == 'Decay' and toggle_annotation:
                # annotate the values in (x,y) format
                texts.append(plt.text(start_decay_time, start_decay, f"start_decay({start_decay_time},{round(start_decay,1)})", fontsize=8))
                texts.append(plt.text(stop_decay_time, stop_decay, f"stop_decay({stop_decay_time},{round(stop_decay,1)})", fontsize=8))
                texts.append(plt.text(start_vent_time, start_vent, f"start_vent\n({start_vent_time},{round(start_vent,1)})", fontsize=8))
                texts.append(plt.text(stop_vent_time, stop_vent, f"stop_vent\n({stop_vent_time},{round(stop_vent,1)})", fontsize=8))

    # labels and legend
    ax.set_xlabel('No. of Samples')
    ax.set_ylabel('Pressure')
    ax.legend(loc='upper right')

    # create tkinter canvas
    canvas = FigureCanvasTkAgg(fig, master=home_tab)
    canvas.draw()

    # create the toolbar
    toolbar_frm = tk.Frame(home_tab)
    toolbar = NavigationToolbar2Tk(canvas, toolbar_frm)
    toolbar.update()

    if toggle_annotation and channel != 'all': # call adjust_text to avoid annotations overlap

        adjust_text(texts, arrowprops=dict(arrowstyle='->'),expand_points=(1.9,2.9))

    # place the canvas and toolbar on the tkinter root
    canvas.get_tk_widget().grid(row=1, column=1, sticky="nw")
    toolbar.grid(row=0, column=0, sticky="nw")
    toolbar_frm.grid(row=1, column=1, sticky="nw")

    # update the global variable CHANNEL
    CHANNEL = channel

    # button to toggle annotation, only show if log_file is not empty
    if log_file != "":
        btn_toggle = tk.Button(master=home_tab, text="Toggle Annotation", font = ("Arial",12), command=on_toggle_annotation_click)
        btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def on_toggle_annotation_click():
    global toggle_annotation
    toggle_annotation = not toggle_annotation # toggle toggle_annotation
    plot(CHANNEL)


def get_current_tab():
    global current_tab
    selected_tab = tab_control.select() # get current tab
    if selected_tab == str(tab_control.nametowidget(tab_control.tabs()[0])):     
        return home_tab
    else:
        return help_tab
    

def show_about():
    help_tab = tab_control.nametowidget(tab_control.tabs()[1])
    create_label(help_tab,"PVT Post Process Tool\nVersion 1.0\nCreated by: HP CIMation",1,1,"ew","font_16",25,(5,5)) 


def left_padding_GUI():
    frm_left_padding = tk.Frame(master=home_tab, borderwidth=2, width=20)
    frm_left_padding.grid(row=1, column=0, sticky="nw", rowspan=5)
    configure_grid(frm_left_padding)


def right_selection_GUI():
    paddings = {'padx': 5, 'pady': 5} # Define the padding for the widgets
    frm_selection = tk.Frame(master=home_tab, borderwidth=2)
    create_label(frm_selection, "Select Test:", 2, 0, "w", "font_14",13, (5,5), "light grey")
    create_label(frm_selection, "Toggle Channel:", 4, 0, "w", "font_14",13, (5,5), "light grey")
    create_label(frm_selection, "Serial Number:", 6, 0, "w", "font_14",13, (5,5), "light grey")
    create_label(frm_selection, "Run Number:", 8, 0, "w", "font_14",13, (5,5), "light grey")

    if source_path != "" and test_result["Mech2TestPrimingPressure"] != -1:
        if new_log_file:
            if test_result['Mech2TestPrimingPressure'] == 'True':
                text = "Pass"
                background = "light green"
            else:
                text = "Fail"
                background = "light coral"
                test_result["Mech2TestPrimingPressure"] = False
            create_label(frm_selection, text, 0, 0, "w", "font_14",9, (5,5), background)
        else:
            create_label(frm_selection, "", 0, 0, "w", "font_14",9, (5,5))  
    else:
        #create empty label at row 0 and column 0
        create_label(frm_selection, "", 0, 0, "w", "font_14",9, (5,5))
        
    # Create a label for the sampling rate
    create_label(frm_selection, f"Sampling Rate: {test_result['SamplingHz']}", 1, 0, "w", "font_14",9, (5,5))
    
    # Place the labels and frames in the grid
    frm_selection.grid(row=1, column=2, sticky="nw") # remove rowspan=5 temporarily

    # Create dropdown menus for "Test", "Channel", "Serial Number", and "Run Number"
    dropdown_menu("home_tab", "Test", ["Decay", "Pressure"], frm_selection, 3, 0, on_option_selected)
    dropdown_menu("home_tab", "Channel", ["all", "magenta", "cyan", "yellow", "k (black)"], frm_selection, 5, 0, on_option_selected)
    dropdown_menu("home_tab", "Serial Number", serial_numbers_list, frm_selection, 7, 0, on_serial_number_selected)
    dropdown_menu("home_tab", "Run Number", run_numbers_list, frm_selection, 9, 0, on_run_number_selected)
    configure_grid(frm_selection)

    frm_exit = tk.Frame(master=home_tab, borderwidth=2)
    # Insert empty lbl before btn_exit
    create_label(frm_exit, "", 0, 0, "nsew", "font_16",8, (5,0), height=5)
    btn_exit = tk.Button(frm_exit, height=2, width=10, font=("Arial", 16), text="Exit", background="light coral", command=exit_button_press)
    btn_exit.grid(row=1, column=0, sticky="nsew")
    frm_exit.grid(row=2, column=2, sticky="nsew", rowspan=5, padx=(50, 5))

def create_label(parent, text, row, column, sticky="w", input_font="font_16", width=None, padding=(5, 5), bg=None, fg=None, height=None, columnspan=None):
    temp = input_font.split('_')
    if len(temp) == 2:
        font = ("Arial", temp[1])
    else:
        font = ("Arial", temp[1], temp[2])

    # Create label with optional parameters
    label_options = {
        "master": parent,
        "text": text,
        "font": font
    }
    if bg:
        label_options["background"] = bg
    if fg:
        label_options["foreground"] = fg
    if height:
        label_options["height"] = height
    if width:
        label_options["width"] = width
    label = tk.Label(**label_options)
    label.grid(row=row, column=column, sticky=sticky, padx=padding[0], pady=padding[1], columnspan=columnspan if columnspan else 1)

    return label

def test_result_GUI():
    # test results frame
    frm_result = tk.Frame(master=home_tab, borderwidth=2)
    frm_max_pressures = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2, height=2000)
    frm_pressure_test_result = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2)
    frm_decay_test_result = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2)

    paddings = {'padx': 5, 'pady': 5} # Define the padding for the widgets
    frm_result.grid(row=2, column=1, sticky="nw", columnspan=2)
    frm_max_pressures.grid(row=0, column=0, sticky="nw", **paddings)
    frm_pressure_test_result.grid(row=0, column=1, sticky="nw", **paddings)
    frm_decay_test_result.grid(row=0, column=2, sticky="nw", **paddings)

    # set titles for each test result frames
    create_label(frm_max_pressures, "Max Pressures", 0, 0, "w", "font_16_bold",13, (0,3.3),columnspan = 2)
    create_label(frm_pressure_test_result, "Pressure Test", 0, 0, "w", "font_16_bold",13, (0,1))
    create_label(frm_decay_test_result, "Decay Test", 0, 0, "w", "font_16_bold",13, (0,1))

    # test result for max pressures
    index = 1
    result = ['maxP_magenta', 'maxP_cyan', 'maxP_yellow', 'maxP_black']
    for key in result:
        try:
            value = round(float(test_result[key]), 2)
        except:
            value = test_result[key]
        create_label(frm_max_pressures, key.split('_')[1].capitalize(), index, 0, "nw", "font_16",10, (0,5))
        create_label(frm_max_pressures, f"{value}", index, 1, "nw", "font_16", padding=(0,5), bg = "white")
        index += 1

    if test_result['maxP_within_range'] == '1':
        create_label(frm_max_pressures, "maxP within range", 5, 0, "nw", "font_16",15, (5,5), bg="light green", columnspan= 2)
    elif test_result['maxP_within_range'] == '0':
        create_label(frm_max_pressures, "maxP outside range", 5, 0, "nw", "font_16",15, (5,5), bg="light coral", columnspan= 2)
        test_result["Mech2TestPrimingPressure"] = False
    else:
        create_label(frm_max_pressures, "NA", 5, 0, "nw", "font_16",15, (5,5), bg="light grey", columnspan= 2)


    # test result for Pressure Test
    row_increment = 0
    result = ['pressure_vent_delay', 'pressure_vent_rate']
    for key in result:
        try:
            value = round(float(test_result[key]), 2)
        except:
            value = test_result[key]
        background = 'light green'
        Upperbound = key+'_UL'
        Lowerbound = key+'_LL'
        if Upperbound in test_result and Lowerbound in test_result:
            try:
                background = "light grey" if test_result[Upperbound] == 'NA' else "light green" if float(test_result[Lowerbound]) <= float(test_result[key]) <= float(test_result[Upperbound]) else "light coral"
                if background == "light coral":
                    test_result["Mech2TestPrimingPressure"] = False
            except Exception as e:
                background = "light grey"
        # extract the string vent_delay or vent_rate from the key
        create_label(frm_pressure_test_result, f"{key.split('pressure_')[1].replace('_', ' ').title()}", 2+row_increment, 0, "nw", "font_16",15, (5,3))
        create_label(frm_pressure_test_result, f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", 3+row_increment, 0, "nw", "font_12",15, (5,3), fg = "grey")
        create_label(frm_pressure_test_result, f"{value}", 4+row_increment, 0, "nw", "font_16",15, (5,3), bg = background)
        row_increment += 3

    # test result for Decay Test
    row_increment = 0
    result = ['decay_rate', 'decay_vent_rate']
    for key in result:
        try:
            value = round(float(test_result[key]), 2)
        except:
            value = test_result[key]
        background = 'light green'
        Upperbound = key+'_UL'
        Lowerbound = key+'_LL'
        # if temp is in test_result
        if Upperbound in test_result and Lowerbound in test_result:
            try:
                if test_result[Upperbound] == 'NA':
                    background = "light grey"
                elif float(test_result[Lowerbound]) <= float(test_result[key]) <= float(test_result[Upperbound]):
                    background = "light green" 
                else:
                    background = "light coral"
                    test_result["Mech2TestPrimingPressure"] = False
            except Exception as e:
                background = "light grey"
        create_label(frm_decay_test_result, "Decay Rate" if key == 'decay_rate' else "Vent Rate", 2+row_increment, 0, "nw", "font_16",15, (5,3))
        create_label(frm_decay_test_result, f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", 3+row_increment, 0, "nw", "font_12",15, (5,3), fg = "grey")
        create_label(frm_decay_test_result, f"{value}", 4+row_increment, 0, "nw", "font_16",15, (5,3), bg = background)
        row_increment += 3

    configure_grid(frm_result)
    configure_grid(frm_max_pressures)
    configure_grid(frm_pressure_test_result)
    configure_grid(frm_decay_test_result)


def bottom_bar_GUI():
    global log_file
    if source_path == "":
        return
    # Erase bottom_bar before creating new label
    for widget in home_tab.grid_slaves():
        if int(widget.grid_info()["row"]) == 3 and int(widget.grid_info()["column"]) == 1:
            widget.destroy()
    # bottom bar to show the log file name
    if log_file != "":
        frm_bottom_bar = tk.Frame(master=home_tab, borderwidth=2)
        filename = log_file.split('\\')[-1]
        create_label(frm_bottom_bar, f"Log File:{filename}", 0, 0, "nw", "font_13", padding=(5,5))
        frm_bottom_bar.grid(row=3, column=1, sticky="nw", columnspan=2) #change bottom bar to show in row 0 from row 3


def show_help(input):
    global current_help
    current_help = "help_"+input
    help_GUI(input)

def show_profile(test_type='Decay'):
    global btn_close, lbl_img, current_tab 

    if test_type == 'Pressure':
        img_file = "C:\Program Files (x86)\CIMProjects.Net\Marconi\DataFiles\PressureTestAnnotations.png"
    else:
        img_file = "C:\Program Files (x86)\CIMProjects.Net\Marconi\DataFiles\DecayTestAnnotations.png"

    img = ImageTk.PhotoImage(Image.open(img_file).resize((680,500)))
    lbl_img = tk.Label(master=help_tab, image=img) 
    lbl_img.image = img
    lbl_img.grid(row=0, column=1, sticky="sw")

def clear_chart():
    global canvas
    canvas.get_tk_widget().delete("all")


def menu_bar_GUI():
    menu_f = tk.Menu(menubar,tearoff=0) # file menu
    menu_f.add_command(label="Open Folder", command=select_directory)

    #edit this select_directory command
    menubar.add_cascade(label="File", menu=menu_f, font = ("Arial", 12)) # Top Line

    
def toggle_annotation_GUI():
    # button to toggle annotation
    btn_toggle = tk.Button(master=home_tab, text="Toggle Annotation", font = ("Arial",16),command=on_toggle_annotation_click)
    btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def tab_control_GUI():
    tab_control.add(home_tab, text='Home') # Add Home tab
    tab_control.add(help_tab, text='Help') # Add Help tab
    tab_control.grid(row=0, column=0, sticky="nsew", columnspan=3)

    # trigger a callback when the tab is changed
    tab_control.bind("<<NotebookTabChanged>>", on_tab_change)

def main_GUI():
    global test_result, canvas
    if source_path != '':
        load_log_file(TEST_TYPE) # load log_file, default is pressure test
        if log_file != "":
            plot(CHANNEL) # plot the graph
            update_serial_numbers_list()  # get the unique serial numbers from the source_path
            update_run_numbers_list()  # get the run numbers from the source_path
        else:
            test_result = test_result_default.copy()
            clear_chart()
            create_label(home_tab, "     Selected log file does not exist!!", 1, 1, "nw", "font_16", padding=(5,5), fg="red", height= 2, width=53)
    else:
        # add label ask user to click file button and select source directory
        create_label(home_tab, "     Please click File and open a source directory", 1, 1, "nw", "font_16", padding=(5,5), fg="red")

    tab_control_GUI()
    left_padding_GUI()
    test_result_GUI()
    right_selection_GUI()
    bottom_bar_GUI()
    
    configure_grid(home_tab)
    

def help_GUI(selection="about"):
    for widget in help_tab.winfo_children():
        widget.grid_forget()
    help_frame = tk.Frame(master=help_tab, borderwidth=2, height = 890 ,width=110)        
    bg_color = "light grey"
    btn_about = tk.Button(master=help_frame, text="About", font = ("Arial",14), width = 14, background = bg_color if selection != "about" else "#E5F1FB", command=lambda:show_help("about"))
    btn_about.grid(row=0, column=0, sticky="nw", padx=5, pady=5)
    btn_pressure = tk.Button(master=help_frame, text="Pressure Profile", font = ("Arial",14), width = 14, background = bg_color if selection != "pressure" else "#E5F1FB",command=lambda:show_help("pressure"))
    btn_pressure.grid(row=1, column=0, sticky="nw", padx=5, pady=5)
    btn_decay = tk.Button(master=help_frame, text="Decay Profile", font = ("Arial",14), width = 14, background = bg_color if selection != "decay" else "#E5F1FB",command=lambda:show_help("decay"))
    btn_decay.grid(row=2, column=0, sticky="nw", padx=5, pady=5)
    help_frame.grid(row=0, column=0, sticky="nsw")
    if current_help == "help_about":
        show_about()
    elif current_help == "help_pressure":
        show_profile('Pressure')
    else:
        show_profile('Decay')


if __name__ == "__main__":
    # check if path variable is available from CIMation
    # From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory
    if len(sys.argv) > 1:
        source_path = str(sys.argv[1]).strip().replace('/', '\\')  # assign argv[1] value into source_path
        print("source_path: ", source_path)
    menu_bar_GUI()
    main_GUI()
    help_GUI()

    # start the event loop
    root.mainloop()
