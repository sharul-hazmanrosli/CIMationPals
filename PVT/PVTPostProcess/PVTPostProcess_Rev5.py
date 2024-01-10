import tkinter as tk
from tkinter import ttk
from tkinter.font import Font
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
TEST_TYPE_COMP = 'Decay' # Test type for compare, can be 'Decay' or 'Pressure'
COMPARE_TYPE = 'Stations' # Compare type, can be 'Stations' or 'Serial Numbers' 'Run Numbers
CHANNEL = 'all'
CHANNEL_COMP = 'all'
CHANNEL_NAMES = ["magenta", "cyan", "yellow", "k (black)"]
SERIAL_NUMBER = "NA"
SERIAL_NUMBER_COMP = ["NA","NA","NA"]
RUN_NUMBER = "NA"
RUN_NUMBER_COMP = ["NA","NA","NA"]
STATION_NUMBER_COMP = ["NA","NA","NA"]
source_path = ""
destination_path = ""
log_file = ""
log_file_comp = []
serial_numbers_list = ["NA"]
serial_numbers_list_comp = [["NA"],["NA"],["NA"]]
station_list_comp = ["NA"]
run_numbers_list = ["NA"]
run_numbers_list_comp = [["NA"],["NA"],["NA"]]
new_log_file = True
info_label = None
btn_close = None
lbl_img = None
current_info = "info_about"
toggle_annotation = True
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
root.title("PVT Test")
# set window size
root.geometry("900x840")
# fix window drag size
root.resizable(False,False)
menubar = tk.Menu(root) # Create a new menu bar
root.config(menu=menubar) # Configure the root window to use the created menu bar

tab_style = ttk.Style()
tab_style.theme_use('winnative') #winnative(abit white and pop out tab)
tab_style.configure('TNotebook.Tab', font=('Arial', '12'), borderwidth = 2) # Configure the font of the tab text

tab_control = ttk.Notebook(root) # Create a tab control
home_tab = ttk.Frame(tab_control) # Create a tab
compare_tab = ttk.Frame(tab_control)
info_tab = ttk.Frame(tab_control)
current_tab = ttk.Frame()

# set minsize and weight for each row and column for home_tab
# root.rowconfigure(0,minsize=2,weight=1)
home_tab.rowconfigure(1, minsize=400, weight=1)
home_tab.rowconfigure(2, minsize=200, weight=1)
home_tab.columnconfigure(0, minsize=20, weight=1)
home_tab.columnconfigure(1, minsize=600, weight=1)
home_tab.columnconfigure(2, minsize=20, weight=1)

#set minsize and weight for each row and column for compare_tab
compare_tab.rowconfigure(0, minsize=20, weight=1)
compare_tab.rowconfigure(1, minsize=400, weight=1)
compare_tab.rowconfigure(2, minsize=200, weight=1)
compare_tab.columnconfigure(0, minsize=20, weight=1)
compare_tab.columnconfigure(1, minsize=600, weight=1)
compare_tab.columnconfigure(2, minsize=10, weight=1)

info_tab.columnconfigure(0, minsize=20, weight=1)
info_tab.columnconfigure(1, minsize=200, weight=1)
#info_tab.grid_rowconfigure(0, weight=1)

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
        elif btn_close != None:
            close_annotations()
        global source_path,SERIAL_NUMBER,RUN_NUMBER,SERIAL_NUMBER_COMP,RUN_NUMBER_COMP,STATION_NUMBER_COMP
        directory = filedialog.askdirectory(title=f"Select Source Directory")
        if directory != "":  # if user click cancel, directory will be empty string
            new_source_path = directory.replace('/', '\\')
            if source_path != new_source_path:
                source_path = new_source_path
                # reset SERIAL NUMBER and RUN NUMBER to NA
                SERIAL_NUMBER = "NA"
                RUN_NUMBER = "NA"
                # SERIAL_NUMBER_COMP = ["NA","NA","NA"]
                # RUN_NUMBER_COMP = ["NA","NA","NA"]
                # STATION_NUMBER_COMP = ["NA","NA","NA"]
            main_GUI()
            compare_charts_GUI()
    except Exception as e:
        print(f"An error occurred: {e}")

def exit_button_press():
    root.destroy()


def update_serial_numbers_list():
    try:
        global serial_numbers_list, station_list_comp
        # get all the file names from source_path
        files = os.listdir(source_path)
        # filter only .log files
        files = [file for file in files if file.endswith(".log")]
        # get the unique serial numbers from the files
        serial_numbers_list = list(set([file.split('_')[0] for file in files]))
        if len(serial_numbers_list) > 1:
            # sort ascending order
            serial_numbers_list.sort()
        # get the unique station numbers from the files
        station_list_comp = list(set([file.split('_')[2] for file in files]))
        if len(station_list_comp) > 1: 
            # sort ascending order
            station_list_comp.sort()           
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


def update_serial_numbers_list_comp():
    try:
        global serial_numbers_list_comp, STATION_NUMBER_COMP
        for i in range(3):
            # get all the file names from source_path
            files = os.listdir(source_path)            
            files = [file for file in files if STATION_NUMBER_COMP[i] in file]
            # get the unique serial numbers from the files
            serial_numbers_list_comp[i] = list(set([file.split('_')[0] for file in files]))
            if len(serial_numbers_list_comp[i]) > 1:
                # sort ascending order
                serial_numbers_list_comp[i].sort()
    except FileNotFoundError:
        print(f"Directory {source_path} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")

def update_run_numbers_list_comp():
    try:
        global run_numbers_list_comp, SERIAL_NUMBER_COMP
        for i in range(3):
            # from source_path, filter all the files start with serial_number
            files = os.listdir(source_path)            
            files = [file for file in files if file.startswith(SERIAL_NUMBER_COMP[i]) and STATION_NUMBER_COMP[i] in file]
            # check if files list is not empty to avoid IndexError
            if files:
                # get the first file in files, if after splitting by _ the items count is 9
                if len(files[0].split('_')) == 9:
                    # filter files that contain 9 items after splitting by _
                    files = [file for file in files if len(file.split('_')) == 9]
                    # get the unique run numbers from the files, run number is the 2nd part of the file name
                    run_numbers_list_comp[i] = list(set([file.split('_')[1] for file in files]))
                    #new_log_file = True
                else:
                    run_numbers_list_comp[i] = ["NA"]
                    #new_log_file = False

                if len(run_numbers_list_comp[i]) > 1:
                    # sort descending order
                    run_numbers_list_comp[i].sort(reverse=True)
            else:
                print("No files found with the given serial number.")
    except FileNotFoundError:
        print(f"Directory {source_path} not found.")
    except Exception as e:
        print(f"An error occurred: {e}")

def update_station_numbers_list_comp():
    global station_list_comp
    # get all the file names from source_path
    files = os.listdir(source_path)
    # filter only .log files
    files = [file for file in files if file.endswith(".log")]
    # get the unique station numbers from the files
    station_list_comp = list(set([file.split('_')[2] for file in files]))
    if len(station_list_comp) > 1: 
        # sort ascending order
        station_list_comp.sort()

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


def on_serial_number_selected_comp(*args):
    global run_numbers_list_comp, SERIAL_NUMBER_COMP, RUN_NUMBER_COMP
    index = int(args[1][-1])-1
    # Get the selected serial number from the first argument
    SERIAL_NUMBER_COMP[index] = args[0].get()
    print(f"The selected option is {SERIAL_NUMBER_COMP[index]}")
    # Update the list of run numbers based on the selected serial number
    update_run_numbers_list_comp() 
    RUN_NUMBER_COMP[index] = run_numbers_list_comp[index][0] # Set the current run number to the first run number in the list
    right_selection_compare_GUI() # Update the GUI
    #compare_charts_GUI()


def on_run_number_selected_comp(*args):
    global RUN_NUMBER_COMP, run_numbers_list_comp
    index = int(args[1][-1])-1
    # Get the selected run number from the first argument
    RUN_NUMBER_COMP[index] = args[0].get()
    print(f"The selected option is {RUN_NUMBER_COMP[index]}")
    #right_selection_compare_GUI() # Update the GUI


def on_station_number_selected_comp(*args):
    global STATION_NUMBER_COMP,SERIAL_NUMBER_COMP,RUN_NUMBER_COMP
    index = int(args[1][-1])-1
    # Get the selected station number from the first argument
    STATION_NUMBER_COMP[index] = args[0].get()
    print(f"The selected option is {STATION_NUMBER_COMP[index]}")
    # Update the list of run numbers based on the selected serial number
    update_serial_numbers_list_comp() 
    SERIAL_NUMBER_COMP[index] = serial_numbers_list_comp[index][0] # Set the current serial number to the first serial number in the list
    update_run_numbers_list_comp()
    RUN_NUMBER_COMP[index] = run_numbers_list_comp[index][0] # Set the current run number to the first run number in the list
    right_selection_compare_GUI() # Update the GUI


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

def on_option_selected_comp(*args): # *args is a tuple, args[0] is the selected_option, args[1] is the selector name
    global CHANNEL_COMP, TEST_TYPE_COMP, log_file_comp
    print(f"The selected option is {args[0].get()}")
    if args[1] == "Test":
        log_file_comp = []
        TEST_TYPE_COMP = args[0].get()
        load_log_file_compare(TEST_TYPE_COMP)
        plot_compare(CHANNEL_COMP)
    else: # if channel is selected
        plot_compare(args[0].get())

def on_compare_by_selected(*args):
    global COMPARE_TYPE
    print(f"The selected option is {args[0].get()}")
    COMPARE_TYPE = args[0].get()

def on_tab_change(event):
    global current_tab
    current_tab = get_current_tab()
    print(f"The current tab is {current_tab}")

def dropdown_menu(from_tab, select, options_input, frm_selection, row_index, col_index, callback_function):
    global CHANNEL, TEST_TYPE, SERIAL_NUMBER, RUN_NUMBER

    # Define the options for the dropdown
    options = options_input

    if select[-1].isdigit():
        index = int(select[-1])-1
    selected_option = tk.StringVar(frm_selection)
    if str(from_tab) == 'home_tab':
        if select == "Channel":
            selected_option.set(CHANNEL)
        elif select == "Test":
            selected_option.set(TEST_TYPE)
        elif select == "Serial Number":
            selected_option.set(SERIAL_NUMBER)
        elif select == "Run Number":
            selected_option.set(RUN_NUMBER)
    else:
        if select == "Channel":
            selected_option.set(CHANNEL_COMP)
        elif select == "Test":
            selected_option.set(TEST_TYPE_COMP)       
        elif "Station" in select:
            selected_option.set(STATION_NUMBER_COMP[index])
        elif "Serial Number" in select:
            selected_option.set(SERIAL_NUMBER_COMP[index])
        elif "Run Number" in select:
            selected_option.set(RUN_NUMBER_COMP[index])

    # Call the callback function when the value of the selected option changes
    selected_option.trace_add("write", lambda *args: callback_function(selected_option, select))
    # Create the dropdown
    dropdown_channel = tk.OptionMenu(frm_selection, selected_option, *options)
    dropdown_channel.grid(row=row_index, column=col_index, sticky="nw")
    if str(from_tab) == 'compare_tab':
        dropdown_channel.config(font=("Arial", 13), width=14)
    else:
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

def load_log_file_compare(test_type=TEST_TYPE_COMP):
    try:
        global log_file_comp, STATION_NUMBER_COMP, SERIAL_NUMBER_COMP, RUN_NUMBER_COMP
        # get the files from source_path      
        files = glob.glob(os.path.join(source_path, '*'+test_type+'Test.log'))
        files.sort(key=os.path.getmtime, reverse=True) # Sort files by modified time
        if len(log_file_comp) < 1:   
            log_file_comp = files[:3] # get the latest 3 files
            for i in range(3):
                # loop through and extract f1_station, f1_serial_number, f1_run_number
                STATION_NUMBER_COMP[i] = log_file_comp[i].split('\\')[-1].split('_')[2]
                SERIAL_NUMBER_COMP[i] = log_file_comp[i].split('\\')[-1].split('_')[0]
                RUN_NUMBER_COMP[i] = log_file_comp[i].split('\\')[-1].split('_')[1]
            plot_compare(CHANNEL_COMP)
        else:
            for i in range(3):
                file_name = SERIAL_NUMBER_COMP[i]+'_'+RUN_NUMBER_COMP[i]+'_'+STATION_NUMBER_COMP[i]+'*'+test_type+'Test.log'
                log_file_comp[i] = glob.glob(os.path.join(source_path, file_name))


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
    canvas = FigureCanvasTkAgg(fig, master=home_tab)
    canvas.draw()

    # create the toolbar
    toolbar_frm = tk.Frame(home_tab)
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
    btn_toggle = tk.Button(master=home_tab, text="Toggle Annotation", font = ("Arial",12), command=on_toggle_annotation_click)
    btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def plot_compare(channel=CHANNEL):
    global log_file_comp,TEST_TYPE_COMP
    for i in range(3):
        data = np.loadtxt(log_file_comp[i], skiprows=54, dtype=float, delimiter=',')
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

        # plot selected channel
        ax.plot(x_data, y_data, label=channel, color=color_name_to_hex(channel))

        # Get the maximum y value and its index
        ymax = max(y_data)
        # format ymax to 1 decimal place
        ymax = round(ymax, 1)
        xmax = x_data[y_data.argmax()]

    # labels and legend
    ax.set_xlabel('No. of Samples')
    ax.set_ylabel('Pressure')
    ax.legend(loc='upper right')

    # create tkinter canvas
    canvas = FigureCanvasTkAgg(fig, master=compare_tab)
    canvas.draw()

    # create the toolbar
    toolbar_frm = tk.Frame(compare_tab)
    toolbar = NavigationToolbar2Tk(canvas, toolbar_frm)
    toolbar.update()

    # place the canvas and toolbar on the tkinter root
    canvas.get_tk_widget().grid(row=1, column=1, sticky="nw")
    toolbar.grid(row=0, column=0, sticky="nw")
    toolbar_frm.grid(row=1, column=1, sticky="nw")

    # update the global variables
    global CHANNEL_COMP
    CHANNEL_COMP = channel


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
    if current_tab == home_tab:
        main_GUI()
    else:
        compare_charts_GUI()


def close_annotations():
    global lbl_img, btn_close
    # Destroy the annotations labels and the button
    lbl_img.grid_forget()
    btn_close.grid_forget()
    # Restore the grid options
    if current_tab == home_tab:
        main_GUI()
    else:
        compare_charts_GUI()

def get_current_tab():
    global current_tab
    selected_tab = tab_control.select() # get current tab
    #print("selected_tab",type(selected_tab))
    # print("compare with",type(tab_control.nametowidget(tab_control.tabs()[0])))
    # print("compare result",select_directory == tab_control.nametowidget(tab_control.tabs()[0]))
    if selected_tab == str(tab_control.nametowidget(tab_control.tabs()[0])):     
        return home_tab
    elif selected_tab == str(tab_control.nametowidget(tab_control.tabs()[1])):
        return compare_tab
    else:
        return info_tab
    

def about_info():
    global info_label, btn_close, current_tab
    # Hide right_selection_GUI, test_result_GUI, bottom_bar_GUI
    for widget in current_tab.winfo_children():
        widget.grid_forget()

    # Create the label and button
    info_label = tk.Label(master=current_tab, text="PVT Test Post Process\nVersion 1.0\nCreated by: HP CIMation", font=("Arial", 16))
    btn_close = tk.Button(master=current_tab, text="Close", font = ("Arial",16))

    # Set the command of the button to the close_label function
    btn_close.config(command=close_label)

    # Display the label and button on the screen
    info_label.grid(row=1, column=1, sticky="nsew", padx=10, pady=10)
    btn_close.grid(row=2, column=2, sticky="e", padx=10, pady=10)


def left_padding_GUI():
    frm_left_padding = tk.Frame(master=home_tab, borderwidth=2, width=20)
    frm_left_padding.grid(row=1, column=0, sticky="nw", rowspan=5)
    configure_grid(frm_left_padding)

def right_selection_GUI():
    paddings = {'padx': 5, 'pady': 5} # Define the padding for the widgets
    frm_selection = tk.Frame(master=home_tab, borderwidth=2)
    lbl_select_test = tk.Label(master=frm_selection, text="Select Test:", width=13, font=("Arial", 16), background="light grey")
    lbl_toggle_channel = tk.Label(master=frm_selection, text="Toggle Channel:", width=13, font=("Arial", 16), background="light grey")
    lbl_serial_number = tk.Label(master=frm_selection, text="Serial Number:", width=13, font=("Arial", 16), background="light grey")
    lbl_run_number = tk.Label(master=frm_selection, text="Run Number:", width=13, font=("Arial", 16), background="light grey")

    if source_path != "":
        if new_log_file:
            if test_result['Mech2TestPrimingPressure'] == 'True':
                lbl_test_result = tk.Label(master=frm_selection, text="Pass", background="light green", width=9, font=("Arial", 16))
            else:
                lbl_test_result = tk.Label(master=frm_selection, text="Fail", background="light coral", width=9, font=("Arial", 16))
        else:
            lbl_test_result = tk.Label(master=frm_selection, text="NA", background="light grey", width=9, font=("Arial", 16))
        lbl_test_result.grid(row=0, column=0, sticky="w", **paddings)
    else:
        #create empty label at row 0 and column 0
        tk.Label(frm_selection, width=9, text="").grid(row=0, column=0, sticky="w", **paddings) #remove height = 1
        
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
    dropdown_menu("home_tab", "Test", ["Decay", "Pressure"], frm_selection, 3, 0, on_option_selected)
    dropdown_menu("home_tab", "Channel", ["all", "magenta", "cyan", "yellow", "k (black)"], frm_selection, 5, 0, on_option_selected)
    dropdown_menu("home_tab", "Serial Number", serial_numbers_list, frm_selection, 7, 0, on_serial_number_selected)
    dropdown_menu("home_tab", "Run Number", run_numbers_list, frm_selection, 9, 0, on_run_number_selected)
    configure_grid(frm_selection)

    frm_exit = tk.Frame(master=home_tab, borderwidth=2)
    # Insert empty lbl before btn_exit
    tk.Label(frm_exit, height=11, width=8, text="").grid(row=0, column=0, sticky="nsew", padx=5)
    btn_exit = tk.Button(frm_exit, height=2, width=10, font=("Arial", 16), text="Exit", background="light coral", command=exit_button_press)
    btn_exit.grid(row=1, column=0, sticky="nsew")
    frm_exit.grid(row=2, column=2, sticky="nsew", rowspan=5, padx=(50, 5))


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
        lbl_max_pressure_value = tk.Label(master=frm_max_pressures, text=f"{value}", font=("Arial", 16), background="white")
        lbl_max_pressure.grid(row=index, column=0, sticky="nw", pady=5)
        lbl_max_pressure_value.grid(row=index, column=1, sticky="nw", pady=5)
        index += 1

    if test_result['maxP_within_range'] == '1':
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="Pass", background="light green", width=15, font=("Arial", 16))
    elif test_result['maxP_within_range'] == '0':
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="Fail", background="light coral", width=15, font=("Arial", 16))
    else:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures, text="NA", background="light grey", width=15, font=("Arial", 16))
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
        lbl_pressure_test_limit = tk.Label(master=frm_pressure_test_result, text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", foreground ="grey", width=15, font=("Arial", 12))
        lbl_pressure_test_result = tk.Label(master=frm_pressure_test_result, text=f"{value}", background=background, width=15, font=("Arial", 16))
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
        lbl_decay_test_limit = tk.Label(master=frm_decay_test_result, text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", width=15, font=("Arial", 12), foreground ="grey")
        lbl_decay_test_result = tk.Label(master=frm_decay_test_result, text=f"{value}", background=background, width=15, font=("Arial", 16))
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
    for widget in home_tab.grid_slaves():
        if int(widget.grid_info()["row"]) == 3 and int(widget.grid_info()["column"]) == 1:
            widget.destroy()
    # bottom bar to show the log file name
    frm_bottom_bar = tk.Frame(master=home_tab, borderwidth=2)
    filename = log_file.split('\\')[-1]
    lbl_log_file = tk.Label(master=frm_bottom_bar, text=f"Log File:{filename}", font=("Arial", 13))
    lbl_log_file.grid(row=0, column=0, sticky="nw", padx=5, pady=5)
    frm_bottom_bar.grid(row=3, column=1, sticky="nw", columnspan=2)


def top_selection_compare_GUI():
    paddings = {'padx': 5} # Define the padding for the widgets
    frm_top = tk.Frame(master=compare_tab, borderwidth=2)
    lbl_select_test_comp = tk.Label(master=frm_top, text="Select Test:", width=10, font=("Arial", 14), background="light grey")
    lbl_toggle_channel_comp = tk.Label(master=frm_top, text="Toggle Channel:", width=13, font=("Arial", 14), background="light grey")
    btn_refresh = tk.Button(master=frm_top, text="Refresh", width=10, font=("Arial", 14), background="light blue", command=refresh_button_press)    
    #lbl_compare_by = tk.Label(master=frm_top, text="Compare By:", width=10, font=("Arial", 14), background="light grey")
    lbl_select_test_comp.grid(row=0, column=0, sticky="w", **paddings)   
    lbl_toggle_channel_comp.grid(row=0, column=2, sticky="w", **paddings)
    tk.Label(frm_top, width=11, text="").grid(row=0, column=4, sticky="w", **paddings)
    btn_refresh.grid(row=0, column=5, sticky="w", **paddings)
    #lbl_compare_by.grid(row=0, column=4, sticky="w", **paddings)

    frm_top.grid(row=0, column=0, sticky="nw", columnspan=3)

    # Create dropdown menus for "Test", "Channel", "Compare By"
    dropdown_menu("compare_tab", "Test", ["Decay", "Pressure"], frm_top, 0, 1, on_option_selected_comp)
    dropdown_menu("compare_tab", "Channel", ["all", "magenta", "cyan", "yellow", "k (black)"], frm_top, 0, 3, on_option_selected_comp)
    #dropdown_menu("compare_tab", "Compare By", ["Stations","Serial Numbers","Run Numbers"], frm_top, 0, 5, on_compare_by_selected)


def refresh_button_press():
    #right_selection_compare_GUI()
    plot_compare(CHANNEL_COMP)


def right_selection_compare_GUI():
    paddings = {'padx': 2, 'pady': 5} # Define the padding for the widgets
    frm_select = tk.Frame(master=compare_tab, borderwidth=2)
    frm_file1 = tk.Frame(master=frm_select, borderwidth=2, highlightbackground="black", highlightthickness=1)
    frm_file2 = tk.Frame(master=frm_select, borderwidth=2, highlightbackground="black", highlightthickness=1)
    frm_file3 = tk.Frame(master=frm_select, borderwidth=2, highlightbackground="black", highlightthickness=1)
    lbl_file1 = tk.Label(master=frm_file1, text="File 1:", width=18, font=("Arial", 13), background="light grey")
    lbl_file2 = tk.Label(master=frm_file2, text="File 2:", width=18, font=("Arial", 13), background="light grey")
    lbl_file3 = tk.Label(master=frm_file3, text="File 3:", width=18, font=("Arial", 13), background="light grey")

    lbl_file1.grid(row=0, column=0, sticky="n")
    lbl_file2.grid(row=0, column=0, sticky="n")
    lbl_file3.grid(row=0, column=0, sticky="n") 
    frm_select.grid(row=1, column=2, sticky="ne")
    frm_file1.grid(row=0, column=0, sticky="nw", **paddings)
    frm_file2.grid(row=1, column=0, sticky="nw", **paddings)
    frm_file3.grid(row=2, column=0, sticky="nw", **paddings)

    # Create dropdown menus for "File 1", "File 2", and "File 3"  
    dropdown_menu("compare_tab", "Station1", station_list_comp, frm_file1, 2, 0, on_station_number_selected_comp)
    dropdown_menu("compare_tab", "Station2", station_list_comp, frm_file2, 2, 0, on_station_number_selected_comp)
    dropdown_menu("compare_tab", "Station3", station_list_comp, frm_file3, 2, 0, on_station_number_selected_comp)
    dropdown_menu("compare_tab", "Serial Number1", serial_numbers_list_comp[0], frm_file1, 4, 0, on_serial_number_selected_comp)
    dropdown_menu("compare_tab", "Serial Number2", serial_numbers_list_comp[1], frm_file2, 4, 0, on_serial_number_selected_comp)
    dropdown_menu("compare_tab", "Serial Number3", serial_numbers_list_comp[2], frm_file3, 4, 0, on_serial_number_selected_comp)    
    dropdown_menu("compare_tab", "Run Number1", run_numbers_list_comp[0], frm_file1, 6, 0, on_run_number_selected_comp)
    dropdown_menu("compare_tab", "Run Number2", run_numbers_list_comp[1], frm_file2, 6, 0, on_run_number_selected_comp)
    dropdown_menu("compare_tab", "Run Number3", run_numbers_list_comp[2], frm_file3, 6, 0, on_run_number_selected_comp)

    lbl_station1 = tk.Label(master=frm_file1, text="Station", width=18, font=("Arial", 11))
    lbl_station2 = tk.Label(master=frm_file2, text="Station", width=18, font=("Arial", 11))
    lbl_station3 = tk.Label(master=frm_file3, text="Station", width=18, font=("Arial", 11))
    lbl_SN1 = tk.Label(master=frm_file1, text="Serial Number", width=18, font=("Arial", 11))
    lbl_SN2 = tk.Label(master=frm_file2, text="Serial Number", width=18, font=("Arial", 11))
    lbl_SN3 = tk.Label(master=frm_file3, text="Serial Number", width=18, font=("Arial", 11))
    lbl_RN1 = tk.Label(master=frm_file1, text="Run Number", width=18, font=("Arial", 11))
    lbl_RN2 = tk.Label(master=frm_file2, text="Run Number", width=18, font=("Arial", 11))
    lbl_RN3 = tk.Label(master=frm_file3, text="Run Number", width=18, font=("Arial", 11))
    lbl_station1.grid(row=1, column=0, sticky="sw")
    lbl_station2.grid(row=1, column=0, sticky="sw")
    lbl_station3.grid(row=1, column=0, sticky="sw")
    lbl_SN1.grid(row=3, column=0, sticky="sw")
    lbl_SN2.grid(row=3, column=0, sticky="sw")
    lbl_SN3.grid(row=3, column=0, sticky="sw")
    lbl_RN1.grid(row=5, column=0, sticky="sw")
    lbl_RN2.grid(row=5, column=0, sticky="sw")
    lbl_RN3.grid(row=5, column=0, sticky="sw")

def show_info(input):
    global current_info
    current_info = "info_"+input
    info_GUI()

def show_annotations(test_type='Decay'):
    global btn_close, lbl_img, current_tab 

    if test_type == 'Pressure':
        img_file = "PressureTestAnnotations_orig.png"
    else:
        img_file = "DecayTestAnnotations_orig.png"

    #root.columnconfigure(1, minsize=535, weight=1)
    # display picture in tk
    img = ImageTk.PhotoImage(Image.open(img_file).resize((533,390)))
    lbl_img = tk.Label(master=current_tab, image=img)
    lbl_img.image = img
    lbl_img.grid(row=1, column=1, sticky="w", padx=5, pady=5)


def menu_bar_GUI():
    menu_f = tk.Menu(menubar,tearoff=0) # file menu
    menu_f.add_command(label="Open Folder", command=select_directory)
    # menu_t = tk.Menu(menubar,tearoff=0) # tools menu
    # menu_t.add_command(label="Compare Charts", command=compare_charts_GUI)
    menu_i = tk.Menu(menubar,tearoff=0) # info menu
    menu_i.add_command(label="About", command=about_info)
    menu_i.add_command(label="Pressure Graph Info", command=lambda:show_annotations('Pressure'))
    menu_i.add_command(label="Decay Graph Info", command=lambda:show_annotations('Decay'))


    #edit this select_directory command
    menubar.add_cascade(label="File", menu=menu_f, font = ("Arial", 12)) # Top Line
    # menubar.add_cascade(label="Tools", menu=menu_t) 
    #menubar.add_cascade(label="Info", menu=menu_i)
    

def toggle_annotation_GUI():
    # button to toggle annotation
    btn_toggle = tk.Button(master=home_tab, text="Toggle Annotation", font = ("Arial",16),command=on_toggle_annotation_click)
    btn_toggle.grid(row=1, column=1, sticky="en", padx=5, pady=5)


def tab_control_GUI():
    tab_control.add(home_tab, text='Home') # Add Home tab
    tab_control.add(compare_tab, text='Compare Charts') # Add Compare Charts tab
    tab_control.add(info_tab, text='Info') # Add Info tab
    tab_control.grid(row=0, column=0, sticky="nsew", columnspan=3)

    # tk.Label(tab1, text="Tab 1").grid(row=0, column=0, sticky="nw")
    # tk.Label(tab2, text="Tab 2").grid(row=0, column=0, sticky="nw")
    # trigger a callback when the tab is changed
    tab_control.bind("<<NotebookTabChanged>>", on_tab_change)

def main_GUI():
    if source_path != '':
        # load log_file, default is decay test
        load_log_file(TEST_TYPE)
        # plot the graph
        plot(CHANNEL)
        update_serial_numbers_list()  # get the unique serial numbers from the source_path
        update_run_numbers_list()  # get the run numbers from the source_path
        #toggle_annotation_GUI()
    else:
        # add label ask user to click file button and select source directory
        lbl_select_source = tk.Label(master=home_tab, text="     Please click File and open a source directory", font=("Arial", 16), fg ="red")
        lbl_select_source.grid(row=1, column=1, sticky="nw", padx=5, pady=5)

    tab_control_GUI()
    left_padding_GUI()
    right_selection_GUI()
    test_result_GUI()
    bottom_bar_GUI()
    
    configure_grid(home_tab)


def compare_charts_GUI():
    if source_path != '':
        load_log_file_compare(TEST_TYPE_COMP)
        plot_compare(CHANNEL_COMP)
        update_station_numbers_list_comp()
        update_serial_numbers_list_comp()
        update_run_numbers_list_comp()
    else:
        # add label ask user to select a log file to compare
        lbl_select_file = tk.Label(master=compare_tab, text="     Please select log files to compare and click refresh", font=("Arial", 16), fg ="red")
        lbl_select_file.grid(row=1, column=1, sticky="nw", padx=5, pady=5)

    top_selection_compare_GUI()    
    right_selection_compare_GUI()


def info_GUI():
    for widget in info_tab.winfo_children():
        widget.grid_forget()
    info_frame = tk.Frame(master=info_tab, borderwidth=2, background="light grey", height=840)
    btn_about = tk.Button(master=info_frame, text="About", font = ("Arial",14), command=lambda:show_info("about"))
    btn_about.grid(row=0, column=0, sticky="nw", padx=5, pady=5)
    btn_pressure = tk.Button(master=info_frame, text="Pressure Graph Info", font = ("Arial",14), command=lambda:show_info("pressure"))
    btn_pressure.grid(row=1, column=0, sticky="nw", padx=5, pady=5)
    btn_decay = tk.Button(master=info_frame, text="Decay Graph Info", font = ("Arial",14), command=lambda:show_info("decay"))
    btn_decay.grid(row=2, column=0, sticky="nw", padx=5, pady=5)
    info_frame.grid(row=0, column=0, sticky="nw", columnspan=3)
    if current_info == "info_about":
        # Create the label and button
        info_label = tk.Label(master=info_tab, text="PVT Test Post Process\nVersion 1.0\nCreated by: HP CIMation", font=("Arial", 16))

        # Display the label and button on the screen
        info_label.grid(row=1, column=1, sticky="nw", padx=10, pady=10)
    elif current_info == "info_pressure":
        show_annotations('Pressure')
    else:
        show_annotations('Decay')

if __name__ == "__main__":
    # check if path variable is available from CIMation
    # From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory
    if len(sys.argv) > 1:
        source_path = str(sys.argv[1]).strip().replace('/', '\\')  # assign argv[1] value into source_path
        print("source_path: ", source_path)
    menu_bar_GUI()
    main_GUI()
    compare_charts_GUI()
    info_GUI()

    # start the event loop
    root.mainloop()
