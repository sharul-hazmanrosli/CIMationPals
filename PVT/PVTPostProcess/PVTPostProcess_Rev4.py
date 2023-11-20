import tkinter as tk
from tkinter import filedialog,messagebox
from tkinter.filedialog import askopenfilename,asksaveasfilename
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import (FigureCanvasTkAgg,NavigationToolbar2Tk)
import numpy as np
import webcolors
import pandas as pd
import glob
import os
from itertools import islice
import sys
import inspect
from idlelib.tooltip import Hovertip

#initialize dictionary test_result
# test_result = {}
test_result = {'SamplingHz':'NA','Number Samples':'NA','test_result':-1,'sampling_rate':'NA','serial_number':'NA', \
               'run_number':'NA','maxP_magenta':'NA','maxP_cyan':'NA','maxP_yellow':'NA','maxP_black':'NA','maxP_within_range':-1, \
               'pressure_vent_delay':'NA','pressure_vent_rate':'NA','pressure_vent_delay_result':-1,'pressure_vent_rate_result':-1, \
               'pressure_vent_delay_UL':'NA','pressure_vent_delay_LL':'NA','pressure_vent_rate_UL':'NA','pressure_vent_rate_LL':'NA', \
               'decay_rate':'NA','decay_vent_rate':'NA','decay_rate_result':-1,'decay_vent_rate_result':-1, \
               'decay_rate_UL':'NA','decay_rate_LL':'NA','decay_vent_rate_UL':'NA','decay_vent_rate_LL':'NA'}

#Global variables
TEST_TYPE = 'Decay'
CHANNEL = 'all'
CHANNEL_NAMES = ["magenta", "cyan","yellow","k (black)"]
run_numbers_list = [0]
RUN_NUMBER = 0
source_path = ""
destination_path = ""
log_file = ""
serial_numbers_list = ["NA"]
SERIAL_NUMBER = "NA"


#main window 
root = tk.Tk()
root.title("PVT Test")
#set window size
root.geometry("850x750") 
#fix window drag size
#root.resizable(False,False) 

#set minsize and weight for each row and column
root.rowconfigure(0,minsize=2,weight=1)
root.rowconfigure(1,minsize=400,weight=1)
root.rowconfigure(2,minsize=200,weight=1)
root.columnconfigure(0,minsize=20,weight=1)
root.columnconfigure(1,minsize=600,weight=1)
root.columnconfigure(2,minsize=20,weight=1)

#configure the grid
def configure_grid(widget):
    #print(str(widget)+"grid_szie()",widget.grid_size())
    rows,columns = widget.grid_size()
    for row in range(rows):
        widget.rowconfigure(row,weight=1)
    for column in range(columns):
        widget.columnconfigure(column,weight=1)
    # If the widget is a frame, also configure its children
    if isinstance(widget, tk.Frame):
        for child in widget.winfo_children():
            child.grid(sticky='nsew')
            # rows, columns = child.grid_size()
            # configure_grid(child)   

def select_directory():
    global source_path
    directory = filedialog.askdirectory(title=f"Select Source Directory")
    if directory != "": #if user click cancel, directory will be empty string
        source_path = directory.replace('/','\\')
    main_GUI()    
        
def exit_button_press():
    root.destroy()

def update_serial_numbers_list():
    global serial_numbers_list
    #get all the file names from source_path
    files = os.listdir(source_path)
    #filter only .log files
    files = [file for file in files if file.endswith(".log")]
    #get the unique serial numbers from the files
    serial_numbers_list = list(set([file.split('_')[0] for file in files]))
    if len(serial_numbers_list) > 1:
        #sort ascending order
        serial_numbers_list.sort()

def update_run_numbers_list():
    global run_numbers_list,SERIAL_NUMBER 
    #from source_path, filter all the files start with serial_number
    files = os.listdir(source_path)
    files = [file for file in files if file.startswith(SERIAL_NUMBER)]
    #filter files that contain 10 items after splitting by _
    files = [file for file in files if len(file.split('_')) == 10]
    #get the unique run numbers from the files, run number is the 2nd part of the file name
    run_numbers_list = list(set([file.split('_')[1] for file in files]))
    if len(run_numbers_list) > 1:
        #sort descending order
        run_numbers_list.sort(reverse=True)

def on_serial_number_selected(*args):
    global run_numbers_list,SERIAL_NUMBER,RUN_NUMBER
    SERIAL_NUMBER = args[0].get()
    print(f"The selected option is {SERIAL_NUMBER}")
    update_run_numbers_list() #get the run numbers from the source_path
    RUN_NUMBER = run_numbers_list[0]
    load_log_file()
    plot()
    top_test_info_GUI()
    right_selection_GUI()
    test_result_GUI()
    bottom_bar_GUI()

def on_run_number_selected(*args):
    global RUN_NUMBER,run_numbers_list
    RUN_NUMBER = args[0].get()
    print(f"The selected option is {RUN_NUMBER}")
    load_log_file()
    plot()
    top_test_info_GUI()
    right_selection_GUI()
    test_result_GUI()
    bottom_bar_GUI()

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
    # Use glob to find files matching the pattern '*PressureTest.log'
    test_type = test_type.capitalize()+ 'Test' # capitialize the first letter of test_type
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
def on_option_selected(*args):  #*args is a tuple, args[0] is the selected_option, args[1] is the selector name
    global CHANNEL,TEST_TYPE
    print(f"The selected option is {args[0].get()}")
    if args[1] == "Test":
        load_log_file(args[0].get())
        plot(CHANNEL) 
    else:
        plot(args[0].get())

def dropdown_menu(select,options_input,frm_selection,row_index,callback_function):
    global CHANNEL,TEST_TYPE,SERIAL_NUMBER,RUN_NUMBER

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

    selected_option.trace("w", lambda *args: callback_function(selected_option,select))
    # Create the dropdown
    dropdown_channel = tk.OptionMenu(frm_selection, selected_option, *options)
    dropdown_channel.grid(row=row_index,column=0,sticky="nw")
    dropdown_channel.config(font=("Arial",16),width=15)

    # Get the button component of the OptionMenu
    menubutton = dropdown_channel.nametowidget(dropdown_channel.menuname)

    # add color to the dropdown when mouse hover
    menubutton.bind("<Enter>",lambda event, h=menubutton: h.configure(bg="#CCE8FF"))
    menubutton.bind("<Leave>",lambda event, h=menubutton: h.configure(bg="SystemButtonFace"))

def load_log_file(test_type=TEST_TYPE):
    global log_file,SERIAL_NUMBER,RUN_NUMBER
    if SERIAL_NUMBER == "NA": #first time load log_file
        #load latest log file
        if test_type.lower() == 'pressure':
            log_file = obtain_latest_file('pressure')
        else:
            log_file = obtain_latest_file('decay')
    else:
        # Use glob to find files matching the pattern 'SERIAL_NUMBER+'_'+RUN_NUMBER+*PressureTest.log'
        test_type = test_type.capitalize()+ 'Test' # capitialize the first letter of test_type
        test_name = SERIAL_NUMBER+'_'+str(RUN_NUMBER)+'*' + test_type + '.log'
        files = glob.glob(os.path.join(source_path, test_name))
        # If test file exist, use latest ; else exit  
        if files:
            # Sort files based on modification time (latest file first)
            log_file = max(files, key=os.path.getmtime)   
        else:
            print(f"Error: No {test_name} file found")      
    with open(log_file, 'r') as file:
        lines = file.readlines()
        #loop through log_file row 1 to row 27 and assign the values into test_result dictionary, text before : is key and text after : is value
        for i in range(27):
            line = lines[i].strip()
            key = line.split(':')[0].strip()
            value = line.split(':')[1].strip()
            test_result[key] = value   
        if SERIAL_NUMBER == "NAv":
            SERIAL_NUMBER = test_result['serial_number']
            RUN_NUMBER = test_result['run_number'] 
        # serial_numbers_list.clear()
        # serial_numbers_list.append(test_result['serial_number'])
        # run_numbers_list.clear()
        # run_numbers_list.append(test_result['run_number'])

def plot(channel = CHANNEL):
    global log_file
    data = np.loadtxt(log_file,skiprows=28,dtype=float,delimiter=',')
    # Get channel names from Row 3 of log file
    with open(log_file, 'r') as file:
        lines = file.readlines()
        channel_names_raw = lines[27].strip()
    CHANNEL_NAMES = (str(channel_names_raw.split(':')[1]).strip().lower()).split(',') 

    #plot the data
    fig = plt.figure(figsize=(6,4),dpi=100)
    ax = fig.add_subplot()
    
    x_data = data[:,0]    
    #x_data = data[0]
    if channel == 'all':
        #plot all channels
        for column in CHANNEL_NAMES:
            y_data = data[:,CHANNEL_NAMES.index(column)+1]
            ax.plot(x_data,y_data,label=column,color=color_name_to_hex(column))
    else: 
        #plot selected channel
        y_data = data[:,CHANNEL_NAMES.index(channel)+1]
        ax.plot(x_data,y_data,label=channel,color=color_name_to_hex(channel))

        # Get the maximum y value and its index
        ymax = max(y_data)
        xpos = np.where(y_data == ymax)
        xmax = xpos[0][0]

        # Annotate the maximum point
        plt.annotate('maxP', xy=(xmax, ymax), xytext=(xmax, ymax+0.05),
                    arrowprops=dict(facecolor='black', shrink=0.05))
        
        # Annotate the maximum point with label and number
        # plt.annotate(f'maxP: {ymax}', xy=(xmax, ymax), xytext=(xmax, ymax+0.05),
        #      arrowprops=dict(facecolor='black', shrink=0.05))
        
        # Annotate the maximum point with a line
        # plt.annotate(f'maxP: {ymax}', xy=(xmax, ymax), xytext=(xmax, ymax+0.05),        
        #      arrowprops=dict(facecolor='black', shrink=0.05, arrowstyle='-'))

    #labels and legend
    ax.set_xlabel('No. of Samples')
    ax.set_ylabel('Pressure')
    ax.legend(loc='upper right')

    #create tkinter canvas
    canvas = FigureCanvasTkAgg(fig,master=root)
    canvas.draw()

    #create the toolbar
    toolbar_frm = tk.Frame(root)
    toolbar = NavigationToolbar2Tk(canvas,toolbar_frm)
    toolbar.update()

    #place the canvas and toolbar on the tkinter root
    canvas.get_tk_widget().grid(row=1,column=1,sticky="nw")
    toolbar.grid(row=0,column=0,sticky="nw")
    toolbar_frm.grid(row=1,column=1,sticky="nw")

    #update the global variables
    global CHANNEL,TEST_TYPE
    CHANNEL=channel

def top_test_info_GUI():
    #paddings for the labels
    paddings = {'padx': 5, 'pady': 5}
    
    frm_top_bar = tk.Frame(master=root,borderwidth=2)
    if source_path != "":
        lbl_sampling_rate = tk.Label(master=frm_top_bar,text=f"Sampling Rate: {test_result['sampling_rate']}",height= 2, font= ("Arial",16))
        if test_result['test_result']:
            lbl_test_result = tk.Label(master=frm_top_bar,text="Pass",bg = "light green", height= 2, width= 9, font= ("Arial",16))
        else:
            lbl_test_result = tk.Label(master=frm_top_bar,text="Fail",bg = "light coral", height= 2, width= 9, font= ("Arial",16))
        #insert empty label before lbl_test_result
        tk.Label(frm_top_bar,height=2,width=5,font=("Arial",16),text="").grid(row=0,column=2,sticky="nw",padx=5)
        lbl_test_result.grid(row=0,column=3,**paddings)
        lbl_sampling_rate.grid(row=0,column=4,**paddings)

    btn_file = tk.Button(frm_top_bar,width=5,font=("Arial",16),text="File",command=select_directory)
    btn_help = tk.Button(frm_top_bar,width=5,font=("Arial",16),text="Help")

    #add color to the buttons when mouse hover
    btn_file.bind("<Enter>",lambda event, h=btn_file: h.configure(bg="#CCE8FF"))
    btn_file.bind("<Leave>",lambda event, h=btn_file: h.configure(bg="SystemButtonFace"))
    btn_help.bind("<Enter>",lambda event, h=btn_help: h.configure(bg="#CCE8FF"))
    btn_help.bind("<Leave>",lambda event, h=btn_help: h.configure(bg="SystemButtonFace"))

    btn_file.grid(row=0,column=0,sticky="ew",padx=(10,2))
    btn_help.grid(row=0,column=1,sticky="ew",padx=(0,10))

    frm_top_bar.grid(row=0,column=1,sticky="nw",columnspan=2)
    configure_grid(frm_top_bar)

def right_selection_GUI():
    paddings = {'padx': 5, 'pady': 5}
    frm_selection = tk.Frame(master=root,borderwidth=2)
    lbl_select_test = tk.Label(master=frm_selection,text="Select Test:", width= 13, font= ("Arial",16),bg = "light grey")
    lbl_toggle_channel = tk.Label(master=frm_selection,text="Toggle Channel:", width= 13, font= ("Arial",16),bg = "light grey")
    lbl_serial_number = tk.Label(master=frm_selection,text="Serial Number:", width= 13, font= ("Arial",16),bg = "light grey")
    lbl_run_number = tk.Label(master=frm_selection,text="Run Number:", width= 13, font= ("Arial",16),bg = "light grey")

    lbl_select_test.grid(row=0,column=0,sticky="w",**paddings)
    lbl_toggle_channel.grid(row=2,column=0,sticky="w",**paddings)
    lbl_serial_number.grid(row=4,column=0,sticky="w",**paddings)
    lbl_run_number.grid(row=6,column=0,sticky="w",**paddings)
    frm_selection.grid(row=1,column=2,sticky="nw",rowspan=5)

    dropdown_menu("Channel",["all","magenta", "cyan","yellow","k (black)"],frm_selection,3,on_option_selected)
    dropdown_menu("Test",["Decay", "Pressure"],frm_selection,1,on_option_selected)
    dropdown_menu("Serial Number",serial_numbers_list,frm_selection,5,on_serial_number_selected)
    dropdown_menu("Run Number",run_numbers_list,frm_selection,7,on_run_number_selected)
    configure_grid(frm_selection)

    frm_exit = tk.Frame(master=root,borderwidth=2)
    #insert empty lbl before btn_exit
    tk.Label(frm_exit,height=11,width=8,text="").grid(row=0,column=0,sticky="nsew",padx=5)
    btn_exit = tk.Button(frm_exit,height=2,width=10,font=("Arial",16),text="Exit",bg = "light coral",command=exit_button_press)
    btn_exit.grid(row=1,column=0,sticky="nsew")
    frm_exit.grid(row=2,column=2,sticky="nsew",rowspan=5,padx=(50,5))

def test_result_GUI():
    # test results frame
    frm_result = tk.Frame(master=root,borderwidth=2)
    frm_max_pressures = tk.Frame(master=frm_result,borderwidth=2,highlightbackground="black", highlightthickness=2,height=2000)
    frm_pressure_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)
    frm_decay_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)

    paddings = {'padx': 5, 'pady': 5}
    frm_result.grid(row=2,column=1,sticky="nw",columnspan=2)
    frm_max_pressures.grid(row=0,column=0,sticky="nw",**paddings)
    frm_pressure_test_result.grid(row=0,column=1,sticky="nw",**paddings)
    frm_decay_test_result.grid(row=0,column=2,sticky="nw",**paddings)

    # set titles for each test result frames
    lbl_max_pressure_title = tk.Label(master=frm_max_pressures,text="Max Pressures", font= ("Arial", 16, "bold"))
    lbl_max_pressure_title.grid(row=0,column=0,sticky="w", pady=3.3, columnspan=2)

    lbl_pressure_test_title = tk.Label(master=frm_pressure_test_result,text="Pressure Test", font= ("Arial", 16, "bold"))
    lbl_pressure_test_title.grid(row=0,column=0,sticky="w",pady=1)

    lbl_decay_test_title = tk.Label(master=frm_decay_test_result,text="Decay Test", font=("Arial", 16, "bold"))
    lbl_decay_test_title.grid(row=0,column=0,sticky="w",pady=1)

    # test result for max pressures
    index = 1
    for key,value in islice(test_result.items(),6,10):
        lbl_max_pressure = tk.Label(master=frm_max_pressures,text= key.split('_')[1].capitalize(), font= ("Arial",16))
        lbl_max_pressure_value = tk.Label(master=frm_max_pressures,text=f"{value}", font= ("Arial",16),bg="white")
        lbl_max_pressure.grid(row=index,column=0,sticky="nw",pady=5)
        lbl_max_pressure_value.grid(row=index,column=1,sticky="nw",pady=5)
        index += 1

    maxP_within_range = test_result['maxP_within_range']
    if maxP_within_range==1:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Pass",bg = "light green", width= 15, font= ("Arial",16))
    elif maxP_within_range==0:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Fail",bg = "light coral", width= 15, font= ("Arial",16))
    else:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="NA",bg = "light grey", width= 15, font= ("Arial",16))
    lbl_max_pressure_result.grid(row=5,column=0,sticky="nw",**paddings,columnspan=2)

    # test result for Pressure Test
    row_increment = 0
    for key,value in islice(test_result.items(),11,13):
        background = 'light green'
        # #split key by _ and replace the last item with result
        # temp = '_'.join(key.split('_')[:-1] + ['result'])
        temp = key+'_result'
        #if temp is in test_result
        if temp in test_result:
            background = "light green" if test_result[temp] == '1' else "light coral" if test_result[temp] == '0' else "light grey"
        #extract the string vent_delay or vent_rate from the key
        lbl_pressure_test = tk.Label(master=frm_pressure_test_result, text=f"{key.split('pressure_')[1].replace('_', ' ').title()}", width= 15, font= ("Arial",16))
        lbl_pressure_test_limit = tk.Label(master=frm_pressure_test_result,text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", fg="grey", width= 15, font=("Arial", 12))
        lbl_pressure_test_result = tk.Label(master=frm_pressure_test_result,text=f"{value}",bg = background, width= 15, font= ("Arial",16))
        lbl_pressure_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3) 
        lbl_pressure_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_pressure_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
        row_increment += 3

    # test result for Decay Test
    row_increment = 0
    for key,value in islice(test_result.items(),19,21):
        background = 'light green'
        # #split key by _ and replace the last item with result
        # temp = '_'.join(key.split('_')[:-1] + ['result'])      
        temp = key+'_result'  
        #if temp is in test_result
        if temp in test_result:
            background = "light green" if test_result[temp] == '1' else "light coral" if test_result[temp] == '0' else "light grey"
        lbl_decay_test = tk.Label(master=frm_decay_test_result,text = "Decay Rate" if key == 'decay_rate' else "Vent Rate", width= 15, font= ("Arial",16))
        lbl_decay_test_limit = tk.Label(master=frm_decay_test_result,text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", width= 15, font= ("Arial", 12), fg="grey")
        lbl_decay_test_result = tk.Label(master=frm_decay_test_result,text=f"{value}",bg = background, width= 15, font= ("Arial",16))
        lbl_decay_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_decay_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_decay_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
        row_increment += 3

    configure_grid(frm_result)
    configure_grid(frm_max_pressures)
    configure_grid(frm_pressure_test_result)
    configure_grid(frm_decay_test_result)

def bottom_bar_GUI():
    if source_path == "":
        return
    #bottom bar to show the log file name
    frm_bottom_bar = tk.Frame(master=root,borderwidth=2)
    filename = log_file.split('\\')[-1]
    lbl_log_file = tk.Label(master=frm_bottom_bar,text=f"Log File:{filename}",font= ("Arial",13))
    lbl_log_file.grid(row=0,column=0,sticky="nw",padx=5,pady=5)
    frm_bottom_bar.grid(row=3,column=1,sticky="nw",columnspan=2)

def main_GUI():
    if source_path != '':
        #load log_file, default is decay test
        load_log_file(TEST_TYPE)
        #plot the graph
        plot()     
        update_serial_numbers_list() #get the unique serial numbers from the source_path
        update_run_numbers_list() #get the run numbers from the source_path
    else:
        #add label ask user to click file button and select source directory
        lbl_select_source = tk.Label(master=root,text="     Please click File button and select source directory!",font= ("Arial",16),fg="red")
        lbl_select_source.grid(row=1,column=1,sticky="nw",padx=5,pady=5)
    ########################## Left Padding ##########################
    frm_left_padding = tk.Frame(master=root,borderwidth=2,width=20)
    frm_left_padding.grid(row=1,column=0,sticky="nw",rowspan=5)

    top_test_info_GUI()
    right_selection_GUI()
    test_result_GUI()
    bottom_bar_GUI()    

    configure_grid(root)
    configure_grid(frm_left_padding)


if __name__ == "__main__":
    #'''
    #check if path variable is available from CIMation
    # if len(sys.argv) > 1:                    #From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory    
    #     source_path = str(sys.argv[1]).strip().replace('/','\\')      #assign argv[1] value into source_path  
    #     print("source_path: ",source_path)
    #     main_GUI()
    # else:

    main_GUI()
    #'''    
    #start the event loop
    root.mainloop()    
   
    