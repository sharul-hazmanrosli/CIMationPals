import tkinter as tk
from tkinter.filedialog import askopenfilename,asksaveasfilename
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import (FigureCanvasTkAgg,NavigationToolbar2Tk)
import numpy as np
import webcolors
import plotly.graph_objs as go
import plotly.offline as offline
import pandas as pd
import glob
import os
from itertools import islice
import sys

#check if path variable is available from CIMation
if len(sys.argv) > 1:                    #From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory    
    project_path = str(sys.argv[1])      #assign argv value into project_path    
else:
    #light up a button that prompts user to select a sourceDirectory and a destinationDirectory 
    project_path = r'C:\Program Files (x86)\CIMProjects.Net\Marconi\Marconi Result Sample'

#data to input to log file
test_info = {'test_result':0,'PVT_status':1,'sampling_rate':1000,'serial_number':'TH36936123085Z'}
max_pressures = {'maxP_magenta':98.51,'maxP_cyan':98.26,'maxP_yellow':98.54,'maxP_black':98.33,'maxP_within_range':1}
pressure_test_result = {'Vent Delay':20,'Vent Rate':1500,'Vent Delay Result':1,'Vent Rate Result':0}
pressure_test_limits = {'Vent Delay UL':50,'Vent Delay LL':-75,'Vent Rate UL':1434,'Vent Rate LL':784}
decay_test_result = {'Decay':-0.5,'Vent Rate':500,'Decay Result':1,'Vent Rate Result':1}
decay_test_limits = {'Decay UL':0,'Decay LL':-5.57,'Vent Rate UL':1000,'Vent Rate LL':200}

#Global variables
TEST_TYPE = 'pressure'
CHANNEL = 'all'
CHANNEL_NAMES = ["magenta", "cyan","yellow","k (black)"]

testing_path = r'C:\Users\ThKy029\OneDrive - HP Inc\Python\Image'

root = tk.Tk() 
root.title("PVT Test")
#set window size
root.geometry("900x750") 
#fix window drag size
root.resizable(False,False)

def exit_button_press():
    root.destroy()

def plot(test_type=TEST_TYPE,channel = CHANNEL):
    #check the log file to load
    if test_type.lower() == 'pressure':
        log_file = obtain_latest_file('pressure')
    else:
        log_file = obtain_latest_file('decay')
    #load the log file
    data = np.loadtxt(log_file,skiprows=3,dtype=float,delimiter=',')

    # Get channel names from Row 3 of log file
    with open(log_file, 'r') as file:
            channel_names_raw = file.readlines()[2].strip()
   
    CHANNEL_NAMES = (str(channel_names_raw.split(':')[1]).strip().lower()).split(',') 
    
    #plot the data
    fig = plt.figure(figsize=(6,4),dpi=100)
    ax = fig.add_subplot()
    
    x_data = data[:,0]    
    if channel == 'all':
        #plot all channels
        for column in CHANNEL_NAMES:
            y_data = data[:,CHANNEL_NAMES.index(column)+1]
            ax.plot(x_data,y_data,label=column,color=color_name_to_hex(column))
    else: 
        #plot selected channel
        y_data = data[:,CHANNEL_NAMES.index(channel)+1]
        ax.plot(x_data,y_data,label=channel,color=color_name_to_hex(channel))

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
    TEST_TYPE=test_type

def interactive_plot(test_type=TEST_TYPE,channel = CHANNEL):
    if test_type.lower() == 'pressure':
        log_file = obtain_latest_file('pressure')
    else:
        log_file = obtain_latest_file('decay')

    # Read data starting from the 4th line, without a header, and reset the index
    df = pd.read_csv(log_file, delimiter=',', skiprows=3, header=None)
    df.reset_index(drop=True, inplace=True)

    # Get label names from Row 3 of data file
    with open(log_file, 'r') as file:
        # Read only the third line from the log file
        sample_names_raw = file.readlines()[2].strip()
   
    sample_names = (str(sample_names_raw.split(':')[1]).strip()).split(',')   

    '''---------- Interactive Graph ----------------------------'''
    # Create a trace for each column
    traces = []
    for column in range(1,5):   # Columns 2 to 5 (Python uses 0-based indexing)
        trace = go.Scatter(
            x=df[0],
            y=df[column],
            mode='lines+markers',
            name= sample_names[column-1],    
            line = dict(color=color_name_to_hex(sample_names[column-1]))
        )
        traces.append(trace)
        
    # Create the layout for the graph
    layout = go.Layout(
        title=log_file.split('\\')[-1].split('.')[0],
        xaxis=dict(title='No. of Samples'),
        yaxis=dict(title='Pressure'),
        showlegend=True  # Show legend to allow toggling columns
    )

    # Create the figure
    fig = go.Figure(data=traces, layout=layout)

    #create tkinter canvas
    canvas = FigureCanvasTkAgg(fig,master=root)
    canvas.draw()

    #place the canvas on the tkinter root
    canvas.get_tk_widget().grid(row=1,column=1,sticky="nw")

    # Save the graph as an HTML file (offline interactive graph)
    image_name = log_file.split('\\')[-1].split('.')[0] + '.html' # Extract the file name from the path
    graph_path = testing_path + '\\' + image_name # Rename the plot pic name
    offline.plot(fig, filename=graph_path, auto_open=False)

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
    files = glob.glob(os.path.join(project_path, test_name))

    # If test file exist, use latest ; else exit  
    if files:
        # Sort files based on modification time (latest file first)
        latest_test_file = max(files, key=os.path.getmtime)
        return latest_test_file
    else:
        print(f"Error: No {test_name} file found")
        # sys.exit()

# function to be called when an option is selected
def on_option_selected(*args):  #*args is a tuple, args[0] is the selected_option, args[1] is the selector name
    print(f"The selected option is {args[0].get()}")
    if args[1] == "Test":
        plot(args[0].get(),CHANNEL) 
    else:
        plot(TEST_TYPE,args[0].get())

def dropdown_menu(select,options_input,frm_selection,row_index,callback_function):
    # Define the options for the dropdown
    options = options_input

    # Create a variable to store the current selection
    selected_option = tk.StringVar(frm_selection)
    selected_option.set(options[0])  # Set the default value
    selected_option.trace("w", lambda *args: callback_function(selected_option,select))

    # Create the dropdown
    dropdown_channel = tk.OptionMenu(frm_selection, selected_option, *options)
    dropdown_channel.grid(row=row_index,column=0,sticky="nw")
    dropdown_channel.config(font=(11),width=9)

def open_file():
    filepath = askopenfilename(filetypes=[("Text Files","*.txt"),("All Files","*.*")]) 
    if not filepath:
        return
    #txt_editor.delete("1.0",tk.END)
    with open(filepath,mode="r",encoding="utf-8") as input_file:
        text = input_file.read()
        #txt_editor.insert(tk.END,text)
    root.title(f"Simple Text Editor - {filepath}")

def save_file():
    filepath = asksaveasfilename(defaultextension=".txt",filetypes=[("Text Files","*.txt"),("All Files","*.*")])
    if not filepath:
        return
    with open(filepath,mode="w",encoding="utf-8") as output_file:
        #text = txt_editor.get("1.0",tk.END)
        # get text from lbl_SN
        text = lbl_SN.cget("text")
        output_file.write(text)
    root.title(f"Simple Text Editor - {filepath}")
# root.columnconfigure(0,minsize=20,weight=1)   #changing the minsize does not change anyth
# root.columnconfigure(1,minsize=500,weight=1)
# root.columnconfigure(2,minsize=20,weight=1)

########################## Left ToolBar ##########################
frm_left_bar = tk.Frame(master=root,borderwidth=2,relief=tk.RAISED)

if test_info['PVT_status']:
    display_text = "Ready"
    background = "light green"
else:
    display_text = "Not Connected"
    background = "light coral"

lbl_status = tk.Label(frm_left_bar,height=4,width=8,font=(12),text=display_text,bg = background)
btn_save = tk.Button(frm_left_bar,height=4,width=8,font=(10),text="Save",command=save_file)
btn_plot = tk.Button(frm_left_bar,height=4,width=8,font=(12),text="Plot",command=interactive_plot)  #change plot to interactive_plot to use plotly
btn_exit = tk.Button(frm_left_bar,height=4,width=8,font=(12),text="Exit",bg = "light coral",command=exit_button_press)

lbl_status.grid(row=1,column=0,sticky="ew",padx=5,pady=5)
btn_save.grid(row=2,column=0,sticky="ew",padx=5)
btn_plot.grid(row=3,column=0,sticky="ew",padx=5)
btn_exit.grid(row=4,column=0,sticky="nw",padx=5)
frm_left_bar.grid(row=1,column=0,sticky="nw",rowspan=5)

######################### Top Test Info ##########################
frm_labels = tk.Frame(master=root,borderwidth=2)
lbl_SN = tk.Label(master=frm_labels,text=f"Serial No: {test_info['serial_number']}",height= 2, font= 11)
lbl_sampling_rate = tk.Label(master=frm_labels,text=f"Sampling Rate: {test_info['sampling_rate']}",height= 2, font= 11)

if test_info['test_result']:
    lbl_test_result = tk.Label(master=frm_labels,text="Pass",bg = "light green", height= 2, width= 9, font= 11)
else:
    lbl_test_result = tk.Label(master=frm_labels,text="Fail",bg = "light coral", height= 2, width= 9, font= 11)

#paddings for the labels
paddings = {'padx': 5, 'pady': 5}

lbl_SN.grid(row=0,column=0,**paddings)
lbl_test_result.grid(row=0,column=1,**paddings)
lbl_sampling_rate.grid(row=0,column=2,**paddings)
frm_labels.grid(row=0,column=1,sticky="nw",columnspan=2)

#plot the graph, default is decay test
plot("decay") 

########################## Right Filter ##########################
frm_selection = tk.Frame(master=root,borderwidth=2)
lbl_select_test = tk.Label(master=frm_selection,text="Select Test:", width= 13, font= 8,bg = "light grey")
lbl_toggle_channel = tk.Label(master=frm_selection,text="Toggle Channel:", width= 13, font= 7,bg = "light grey")

lbl_select_test.grid(row=0,column=0,sticky="w",**paddings)
lbl_toggle_channel.grid(row=2,column=0,sticky="w",**paddings)
frm_selection.grid(row=1,column=2,sticky="nw",rowspan=5)

dropdown_menu("Channel",["all","magenta", "cyan","yellow","k (black)"],frm_selection,3,on_option_selected)
dropdown_menu("Test",["Decay", "Pressure"],frm_selection,1,on_option_selected)

frm_result = tk.Frame(master=root,borderwidth=2)
frm_max_pressures = tk.Frame(master=frm_result,borderwidth=2,highlightbackground="black", highlightthickness=2,height=2000)
frm_pressure_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)
frm_decay_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)

frm_result.grid(row=2,column=1,sticky="nw",columnspan=2)
frm_max_pressures.grid(row=0,column=0,sticky="nw",**paddings)
frm_pressure_test_result.grid(row=0,column=1,sticky="nw",**paddings)
frm_decay_test_result.grid(row=0,column=2,sticky="nw",**paddings)

########################## Test Result ###########################
# set titles for each test result frames
lbl_max_pressure_title = tk.Label(master=frm_max_pressures,text="Max Pressures", font= (None, 16, "bold"))
lbl_max_pressure_title.grid(row=0,column=0,sticky="w", pady=3.3, columnspan=2)
#tk.Label(frm_max_pressures, height=4).grid(row=5,column=0)  # Empty label with desired height

lbl_pressure_test_title = tk.Label(master=frm_pressure_test_result,text="Pressure Test", font= (None, 16, "bold"))
lbl_pressure_test_title.grid(row=0,column=0,sticky="w",pady=1)

lbl_decay_test_title = tk.Label(master=frm_decay_test_result,text="Decay Test", font=(None, 16, "bold"))
lbl_decay_test_title.grid(row=0,column=0,sticky="w",pady=1)

# test result for max pressures
index = 1
for key,value in islice(max_pressures.items(),4):
    #lbl_max_pressure = tk.Label(master=frm_max_pressures,text=f"{CHANNEL_NAMES[max_pressures.index(channel)].capitalize()}:", font= 9)
    lbl_max_pressure = tk.Label(master=frm_max_pressures,text= key.split('_')[1].capitalize(), font= 9)
    lbl_max_pressure_value = tk.Label(master=frm_max_pressures,text=f"{value}", font= 9,bg="white")
    lbl_max_pressure.grid(row=index,column=0,sticky="nw",pady=5)
    lbl_max_pressure_value.grid(row=index,column=1,sticky="nw",pady=5)
    index += 1

maxP_within_range = max_pressures['maxP_within_range']
if maxP_within_range:
    lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Pass",bg = "light green", width= 15, font= 9)
else:
    lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Fail",bg = "light coral", width= 15, font= 9)
lbl_max_pressure_result.grid(row=5,column=0,sticky="nw",**paddings,columnspan=2)

# test result for Pressure Test
row_increment = 0
for key,value in islice(pressure_test_result.items(),2):
    background = "light green" if pressure_test_result[key+' Result'] == 1 else "light coral"
    lbl_pressure_test = tk.Label(master=frm_pressure_test_result,text=f"{key}", width= 15, font= 9)
    lbl_pressure_test_limit = tk.Label(master=frm_pressure_test_result,text=f"UL: {pressure_test_limits[key+' UL']}  LL: {pressure_test_limits[key+' LL']}", fg="grey", width= 15, font=(None, 12))
    lbl_pressure_test_result = tk.Label(master=frm_pressure_test_result,text=f"{value}",bg = background, width= 15, font= 9)
    lbl_pressure_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3) 
    lbl_pressure_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
    lbl_pressure_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
    row_increment += 3

# test result for Decay Test
row_increment = 0
for key,value in islice(decay_test_result.items(),2):
    background = "light green" if decay_test_result[key+' Result'] == 1 else "light coral"
    lbl_decay_test = tk.Label(master=frm_decay_test_result,text=f"{key}", width= 15, font= 9)
    lbl_decay_test_limit = tk.Label(master=frm_decay_test_result,text=f"UL: {decay_test_limits[key+' UL']}  LL: {decay_test_limits[key+' LL']}", width= 15, font= (None, 12), fg="grey")
    lbl_decay_test_result = tk.Label(master=frm_decay_test_result,text=f"{value}",bg = background, width= 15, font= 9)
    lbl_decay_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3)
    lbl_decay_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
    lbl_decay_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
    row_increment += 3

##################################################################
#start the event loop
root.mainloop()
