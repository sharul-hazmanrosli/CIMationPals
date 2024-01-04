import tkinter as tk
from tkinter import filedialog, messagebox
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import (FigureCanvasTkAgg, NavigationToolbar2Tk)
import numpy as np
import webcolors
import glob
import os
import sys
from adjustText import adjust_text
from PIL import Image,ImageTk

# Global variables
TEST_TYPE = 'Decay' # Test type, can be 'Decay' or 'Pressure'
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
info_label = None
global btn_close
lbl_img = None
lbl_img1 = None
toggle_annotation = True
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
root.title("PVT Test")
# set window size
root.geometry("900x800")
# fix window drag size
root.resizable(False,False)
menubar = tk.Menu(root) # Create a new menu bar
root.config(menu=menubar) # Configure the root window to use the created menu bar

# set minsize and weight for each row and column
# root.rowconfigure(0,minsize=2,weight=1)
root.rowconfigure(1, minsize=400, weight=1)
root.rowconfigure(2, minsize=200, weight=1)
root.columnconfigure(0, minsize=20, weight=1)
root.columnconfigure(1, minsize=600, weight=1)
root.columnconfigure(2, minsize=20, weight=1)


# configure the grid
def configure_grid(widget):
    rows, columns = widget.grid_size()
    for row in range(rows):
        # Configure the row to expand equally when the widget is resized
        widget.rowconfigure(row, weight=1)
    for column in range(columns):
        # Configure the column to expand equally when the widget is resized
        widget.columnconfigure(column, weight=1)
    # If the widget is a frame, also configure its children
    if isinstance(widget, tk.Frame):
        for child in widget.winfo_children():
             # Make the child widget expand to fill its grid cell
            child.grid(sticky='nsew')
            # rows, columns = child.grid_size()
            # configure_grid(child)


def select_directory():
    try:
        if info_label != None:
            close_label()
        global source_path,SERIAL_NUMBER,RUN_NUMBER
        directory = filedialog.askdirectory(title=f"Select Source Directory")
        if directory != "":  # if user click cancel, directory will be empty string
            new_source_path = directory.replace('/', '\\')
            if source_path != new_source_path:
                source_path = new_source_path
                # reset SERIAL NUMBER and RUN NUMBER to NA
                SERIAL_NUMBER = "NA"
                RUN_NUMBER = "NA"
            main_GUI()
    except Exception as e:
        print(f"An error occurred: {e}")

def exit_button_press():
    root.destroy()


def update_serial_numbers_list():
    try:
        global serial_numbers_list
        # get all the file names from source_path
        files = os.listdir(source_path)
        # filter only .log files
        files = [file for file in files if file.endswith(".log")]
        # get the unique serial numbers from the files
        serial_numbers_list = list(set([file.split('_')[0] for file in files]))
        if len(serial_numbers_list) > 1:
            # sort ascending order
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
        files = [file for file in files if file.startswith(SERIAL_NUMBER)]
        # check if files list is not empty to avoid IndexError
        if files:
            # get the first file in files, if after splitting by _ the items count is 9
            if len(files[0].split('_')) == 9:
                # filter files that contain 9 items after splitting by _
                files = [file for file in files if len(file.split('_')) == 9]
                # get the unique run numbers from the files, run number is the 2nd part of the file name
                run_numbers_list = list(set([file.split('_')[1] for file in files]))
                new_log_file = True
            else:
                run_numbers_list = ["NA"]
                new_log_file = False

            if len(run_numbers_list) > 1:
                # sort descending order
                run_numbers_list.sort(reverse=True)
        else:
            print("No files found with the given serial number.")
    except FileNotFoundError:
        print(f"Directory {source_path} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")


def on_serial_number_selected(*args):
    global run_numbers_list, SERIAL_NUMBER, RUN_NUMBER
    # Get the selected serial number from the first argument
    SERIAL_NUMBER = args[0].get()
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
    # capitialize the first letter of test_type
    test_type = test_type.capitalize() + 'Test'
    # Use glob to find files matching the pattern '*PressureTest.log'
    test_name = '*' + test_type + '.log'
    files = glob.glob(os.path.join(source_path, test_name))

    # If test file exist, use latest ; else exit
    if files:
        # Sort files based on modification time (latest file first)
        latest_test_file = max(files, key=os.path.getmtime)
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


def dropdown_menu(select, options_input, frm_selection, row_index, callback_function):
    global CHANNEL, TEST_TYPE, SERIAL_NUMBER, RUN_NUMBER

    # Define the options for the dropdown
    options = options_input

    selected_option = tk.StringVar(frm_selection)
    if select == "Channel":
        selected_option.set(CHANNEL)
    elif select == "Test":
        selected_option.set(TEST_TYPE)
    elif select == "Serial Number":
        selected_option.set(SERIAL_NUMBER)
    else:
        selected_option.set(RUN_NUMBER)

    # Call the callback function when the value of the selected option changes
    selected_option.trace("w", lambda *args: callback_function(selected_option, select))
    # Create the dropdown
    dropdown_channel = tk.OptionMenu(frm_selection, selected_option, *options)
    dropdown_channel.grid(row=row_index, column=0, sticky="nw")
    dropdown_channel.config(font=("Arial", 16), width=15)


def extract_test_result(test_type=TEST_TYPE):
    global test_result
    pressure_test_file = ""
    decay_test_file = ""
    if SERIAL_NUMBER == "NA" and RUN_NUMBER == "NA":  # first time load log_file
        # get latest result from both pressure and decay test
        pressure_test_file = obtain_latest_file('pressure')
        decay_test_file = obtain_latest_file('decay')
    else:
        if RUN_NUMBER == "NA":
            # get latest result for that serial number
            pressure_test_file = SERIAL_NUMBER+'_' +'*' + 'PressureTest.log'
            decay_test_file = SERIAL_NUMBER+'_' +'*' + 'DecayTest.log'
        else:
            # capitialize the first letter of test_type
            pressure_test_file = SERIAL_NUMBER+'_' + str(RUN_NUMBER)+'*' + 'PressureTest.log'
            decay_test_file = SERIAL_NUMBER+'_' + str(RUN_NUMBER)+'*' + 'DecayTest.log'
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
    

def load_log_file(test_type=TEST_TYPE):
    try:
        global log_file, SERIAL_NUMBER, RUN_NUMBER, new_log_file,test_result
        # extract test_result from log_file
        log_file = extract_test_result(test_type)    
        # check if log_file is logging test result
        if len(log_file.split('_')) < 9:
            new_log_file = False
        else:
            new_log_file = True
        if new_log_file:
            if SERIAL_NUMBER == "NA":
                RUN_NUMBER = log_file.split('\\')[-1].split('_')[1]
        else:
            test_result = test_result_default.copy() # set test_result to default

        # get serial number from log_file name
        SERIAL_NUMBER = log_file.split('\\')[-1].split('_')[0]
    except IndexError:
        print("Error: Unable to split log file name.")
    except Exception as e:
        print(f"An error occurred: {e}")


def plot(channel=CHANNEL):
    global log_file,TEST_TYPE
    texts = []
    data = np.loadtxt(log_file, skiprows=54, dtype=float, delimiter=',')
    # Get channel names from Row 3 of log file
    with open(log_file, 'r') as file:
        lines = file.readlines()
        # find index of line that starts with Colors:
        channel_index = [i for i, line in enumerate(lines) if line.startswith('Colors:')][0]
    CHANNEL_NAMES = (str(lines[channel_index].strip().split(':')[1]).strip().lower()).split(',')

    # plot the data
    fig = plt.figure(figsize=(6.5, 5), dpi=100)
    #plt.clf()
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
                if y == start_decay:
                    start_decay_time = int(x)
                if y == stop_decay:
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
    canvas = FigureCanvasTkAgg(fig, master=root)
    canvas.draw()

    # create the toolbar
    toolbar_frm = tk.Frame(root)
    toolbar = NavigationToolbar2Tk(canvas, toolbar_frm)
    toolbar.update()

    if toggle_annotation and channel != 'all': # call adjust_text to avoid annotations overlap
        #adjust_text(texts, arrowprops=dict(arrowstyle='->'),expand_points=(1.3,1.1))  1.2,1.8 optimal, 1.9,1.6 with no \n 1.9,2.9
        adjust_text(texts, arrowprops=dict(arrowstyle='->'),expand_points=(1.9,2.9))

    # place the canvas and toolbar on the tkinter root
    canvas.get_tk_widget().grid(row=1, column=1, sticky="nw")
    toolbar.grid(row=0, column=0, sticky="nw")
    toolbar_frm.grid(row=1, column=1, sticky="nw")

    # update the global variables
    global CHANNEL
    CHANNEL = channel

    # button to toggle annotation   
    btn_toggle = tk.Button(master=root, text="Toggle Annotation", font=("Arial", 12),command=on_toggle_annotation_click)
    btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def on_toggle_annotation_click():
    global toggle_annotation
    toggle_annotation = not toggle_annotation # toggle toggle_annotation
    plot(CHANNEL)


def close_label():
    global info_label, btn_close
    # Destroy the label and the button
    info_label.grid_forget()
    btn_close.grid_forget()
    # Restore the grid options
    main_GUI()


def close_annotations():
    global lbl_img, lbl_img1, btn_close
    # Destroy the annotations labels and the button
    lbl_img.grid_forget()
    lbl_img1.grid_forget()
    btn_close.grid_forget()
    # Restore the grid options
    main_GUI()


def about_info():
    global info_label, btn_close
    # Hide right_selection_GUI, test_result_GUI, bottom_bar_GUI
    for widget in root.winfo_children():
        widget.grid_forget()

    # Create the label and button
    info_label = tk.Label(master=root, text="PVT Test Post Process\nVersion 1.0\nCreated by: HP CIMation", font=("Arial", 16))
    btn_close = tk.Button(master=root, text="Close", font=("Arial", 16))

    # Set the command of the button to the close_label function
    btn_close.config(command=close_label)

    # Display the label and button on the screen
    info_label.grid(row=1, column=1, sticky="nsew", padx=10, pady=10)
    btn_close.grid(row=2, column=2, sticky="e", padx=10, pady=10)


def left_padding_GUI():
    frm_left_padding = tk.Frame(master=root, borderwidth=2, width=20)
    frm_left_padding.grid(row=1, column=0, sticky="nw", rowspan=5)
    configure_grid(frm_left_padding)

def right_selection_GUI():
    paddings = {'padx': 5, 'pady': 5} # Define the padding for the widgets
    frm_selection = tk.Frame(master=root, borderwidth=2)
    lbl_select_test = tk.Label(master=frm_selection, text="Select Test:", width=13, font=("Arial", 16), bg="light grey")
    lbl_toggle_channel = tk.Label(master=frm_selection, text="Toggle Channel:", width=13, font=("Arial", 16), bg="light grey")
    lbl_serial_number = tk.Label(master=frm_selection, text="Serial Number:", width=13, font=("Arial", 16), bg="light grey")
    lbl_run_number = tk.Label(master=frm_selection, text="Run Number:", width=13, font=("Arial", 16), bg="light grey")

    if source_path != "":
        if new_log_file:
            if test_result['Mech2TestPrimingPressure'] == True:
                lbl_test_result = tk.Label(master=frm_selection, text="Pass", bg="light green", width=9, font=("Arial", 16))
            else:
                lbl_test_result = tk.Label(master=frm_selection, text="Fail", bg="light coral", width=9, font=("Arial", 16))
        else:
            lbl_test_result = tk.Label(master=frm_selection, text="NA", bg="light grey", width=9, font=("Arial", 16))
        lbl_test_result.grid(row=0, column=0, sticky="w", **paddings)

    # Create a label for the sampling rate
    lbl_sampling_rate = tk.Label(master=frm_selection,text=f"Sampling Rate: {test_result['SamplingHz']}",width = 9, font= ("Arial", 16))
    lbl_sampling_rate.grid(row=1, column=0, sticky="w", **paddings)
    
    # Place the labels and frames in the grid
    lbl_select_test.grid(row=2, column=0, sticky="w", **paddings)
    lbl_toggle_channel.grid(row=4, column=0, sticky="w", **paddings)
    lbl_serial_number.grid(row=6, column=0, sticky="w", **paddings)
    lbl_run_number.grid(row=8, column=0, sticky="w", **paddings)
    frm_selection.grid(row=1, column=2, sticky="nw", rowspan=5)

    # Create dropdown menus for "Test", "Channel", "Serial Number", and "Run Number"
    dropdown_menu("Test", ["Decay", "Pressure"], frm_selection, 3, on_option_selected)
    dropdown_menu("Channel", ["all", "magenta", "cyan", "yellow", "k (black)"], frm_selection, 5, on_option_selected)
    dropdown_menu("Serial Number", serial_numbers_list, frm_selection, 7, on_serial_number_selected)
    dropdown_menu("Run Number", run_numbers_list, frm_selection, 9, on_run_number_selected)
    configure_grid(frm_selection)

    frm_exit = tk.Frame(master=root, borderwidth=2)
    # Insert empty lbl before btn_exit
    tk.Label(frm_exit, height=11, width=8, text="").grid(row=0, column=0, sticky="nsew", padx=5)
    btn_exit = tk.Button(frm_exit, height=2, width=10, font=("Arial", 16), text="Exit", bg="light coral", command=exit_button_press)
    btn_exit.grid(row=1, column=0, sticky="nsew")
    frm_exit.grid(row=2, column=2, sticky="nsew", rowspan=5, padx=(50, 5))


def test_result_GUI():
    # test results frame
    frm_result = tk.Frame(master=root, borderwidth=2)
    frm_max_pressures = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2, height=2000)
    frm_pressure_test_result = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2)
    frm_decay_test_result = tk.Frame(master=frm_result, borderwidth=2, highlightbackground="black", highlightthickness=2)

    paddings = {'padx': 5, 'pady': 5} # Define the padding for the widgets
    frm_result.grid(row=2, column=1, sticky="nw", columnspan=2)
    frm_max_pressures.grid(row=0, column=0, sticky="nw", **paddings)
    frm_pressure_test_result.grid(row=0, column=1, sticky="nw", **paddings)
    frm_decay_test_result.grid(row=0, column=2, sticky="nw", **paddings)

    # set titles for each test result frames
    lbl_max_pressure_title = tk.Label(master=frm_max_pressures, text="Max Pressures", font=("Arial", 16, "bold"))
    lbl_max_pressure_title.grid(row=0, column=0, sticky="w", pady=3.3, columnspan=2)

    lbl_pressure_test_title = tk.Label(master=frm_pressure_test_result, text="Pressure Test", font=("Arial", 16, "bold"))
    lbl_pressure_test_title.grid(row=0, column=0, sticky="w", pady=1)

    lbl_decay_test_title = tk.Label(master=frm_decay_test_result, text="Decay Test", font=("Arial", 16, "bold"))
    lbl_decay_test_title.grid(row=0, column=0, sticky="w", pady=1)

    # test result for max pressures
    index = 1
    result = ['maxP_magenta', 'maxP_cyan', 'maxP_yellow', 'maxP_black']
    for key in result:
        try:
            value = round(float(test_result[key]), 2)
        except:
            value = test_result[key]
        lbl_max_pressure = tk.Label(master=frm_max_pressures, text=key.split('_')[1].capitalize(), font=("Arial", 16))
        lbl_max_pressure_value = tk.Label(master=frm_max_pressures, text=f"{value}", font=("Arial", 16), bg="white")
        lbl_max_pressure.grid(row=index, column=0, sticky="nw", pady=5)
        lbl_max_pressure_value.grid(row=index, column=1, sticky="nw", pady=5)
        index += 1

    if test_result['maxP_within_range'] == '1':
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="Pass", bg="light green", width=15, font=("Arial", 16))
    elif test_result['maxP_within_range'] == '0':
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="Fail", bg="light coral", width=15, font=("Arial", 16))
    else:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="NA", bg="light grey", width=15, font=("Arial", 16))
    lbl_max_pressure_result.grid(row=5, column=0, sticky="nw", **paddings, columnspan=2)

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
        # if temp is in test_result
        if Upperbound in test_result and Lowerbound in test_result:
            try:
                background = "light grey" if test_result[Upperbound] == 'NA' else "light green" if float(test_result[Lowerbound]) < float(test_result[key]) < float(test_result[Upperbound]) else "light coral"
            except Exception as e:
                background = "light grey"
        # extract the string vent_delay or vent_rate from the key
        lbl_pressure_test = tk.Label(master=frm_pressure_test_result, text=f"{key.split('pressure_')[1].replace('_', ' ').title()}", width=15, font=("Arial", 16))
        lbl_pressure_test_limit = tk.Label(master=frm_pressure_test_result, text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", fg="grey", width=15, font=("Arial", 12))
        lbl_pressure_test_result = tk.Label(master=frm_pressure_test_result, text=f"{value}", bg=background, width=15, font=("Arial", 16))
        lbl_pressure_test.grid(row=2+row_increment, column=0, sticky="nw", padx=5, pady=3)
        lbl_pressure_test_limit.grid(row=3+row_increment, column=0, sticky="nw", padx=5, pady=3)
        lbl_pressure_test_result.grid(row=4+row_increment, column=0, sticky="nw", padx=5, pady=3)
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
                background = "light grey" if test_result[Upperbound] == 'NA' else "light green" if float(test_result[Lowerbound]) < float(test_result[key]) < float(test_result[Upperbound]) else "light coral"
            except Exception as e:
                background = "light grey"
        lbl_decay_test = tk.Label(master=frm_decay_test_result, text="Decay Rate" if key == 'decay_rate' else "Vent Rate", width=15, font=("Arial", 16))
        lbl_decay_test_limit = tk.Label(master=frm_decay_test_result, text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", width=15, font=("Arial", 12), fg="grey")
        lbl_decay_test_result = tk.Label(master=frm_decay_test_result, text=f"{value}", bg=background, width=15, font=("Arial", 16))
        lbl_decay_test.grid(row=2+row_increment, column=0, sticky="nw", padx=5, pady=3)
        lbl_decay_test_limit.grid(row=3+row_increment, column=0, sticky="nw", padx=5, pady=3)
        lbl_decay_test_result.grid(row=4+row_increment, column=0, sticky="nw", padx=5, pady=3)
        row_increment += 3

    configure_grid(frm_result)
    configure_grid(frm_max_pressures)
    configure_grid(frm_pressure_test_result)
    configure_grid(frm_decay_test_result)


def bottom_bar_GUI():
    if source_path == "":
        return
    # Erase bottom_bar before creating new label
    for widget in root.grid_slaves():
        if int(widget.grid_info()["row"]) == 3 and int(widget.grid_info()["column"]) == 1:
            widget.destroy()
    # bottom bar to show the log file name
    frm_bottom_bar = tk.Frame(master=root, borderwidth=2)
    filename = log_file.split('\\')[-1]
    lbl_log_file = tk.Label(master=frm_bottom_bar, text=f"Log File:{filename}", font=("Arial", 13))
    lbl_log_file.grid(row=0, column=0, sticky="nw", padx=5, pady=5)
    frm_bottom_bar.grid(row=3, column=1, sticky="nw", columnspan=2)


def show_annotations():
    global btn_close, lbl_img, lbl_img1
    # Hide right_selection_GUI, test_result_GUI, bottom_bar_GUI
    for widget in root.winfo_children():
        widget.grid_forget()    

    root.columnconfigure(1, minsize=535, weight=1)
    # display picture in tk
    img = ImageTk.PhotoImage(Image.open("DecayTestAnnotations_orig.png").resize((533,390)))
    lbl_img = tk.Label(image=img)
    lbl_img.image = img
    lbl_img.grid(row=1, column=1, sticky="nw", padx=5, pady=5)

    img1 = ImageTk.PhotoImage(Image.open("PressureTestAnnotations_orig.png").resize((533,390)))
    lbl_img1 = tk.Label(image=img1)
    lbl_img1.image = img1
    lbl_img1.grid(row=2, column=1, sticky="nw", padx=5, pady=5)

    btn_close = tk.Button(master=root, text="Close", font=("Arial", 16))
    btn_close.config(command=close_annotations)
    btn_close.grid(row=2, column=2, sticky="ws", padx=10, pady=10)

def menu_bar_GUI():
    menu_f = tk.Menu(menubar,tearoff=0) # file menu
    menu_f.add_command(label="Open",command=select_directory)
    menu_h = tk.Menu(menubar,tearoff=0) # help menu
    menu_h.add_command(label="About", command=about_info)
    menu_h.add_command(label="Annotations", command=show_annotations)

    #edit this select_directory command
    menubar.add_cascade(label="File", menu=menu_f) # Top Line
    menubar.add_cascade(label="Help", menu=menu_h) 


def toggle_annotation_GUI():
    # button to toggle annotation
    btn_toggle = tk.Button(master=root, text="Toggle Annotation", font=("Arial", 12),command=on_toggle_annotation_click)
    btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def main_GUI():
    if source_path != '':
        # load log_file, default is decay test
        load_log_file(TEST_TYPE)
        # plot the graph
        plot()
        update_serial_numbers_list()  # get the unique serial numbers from the source_path
        update_run_numbers_list()  # get the run numbers from the source_path
        #toggle_annotation_GUI()
    else:
        # add label ask user to click file button and select source directory
        lbl_select_source = tk.Label(master=root, text="     Please click File and open a source directory", font=("Arial", 16), fg="red")
        lbl_select_source.grid(row=1, column=1, sticky="nw", padx=5, pady=5)

    left_padding_GUI()
    right_selection_GUI()
    test_result_GUI()
    bottom_bar_GUI()
    
    configure_grid(root)


if __name__ == "__main__":
    # check if path variable is available from CIMation
    # From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory
    if len(sys.argv) > 1:
        source_path = str(sys.argv[1]).strip().replace('/', '\\')  # assign argv[1] value into source_path
        print("source_path: ", source_path)
    menu_bar_GUI()
    main_GUI()

    # start the event loop
    root.mainloop()
