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

#initialize empty dictionary test_result
test_result = {}

#data to input to log file
# test_result = {'test_result':0,'PVT_status':0,'sampling_rate':1000,'serial_number':'TH36936123085Z', \
#                'maxP_magenta':98.51,'maxP_cyan':98.26,'maxP_yellow':98.54,'maxP_black':98.33,'maxP_within_range':1, \
#                'pressure_vent_delay':20,'pressure_vent_rate':1500,'pressure_vent_delay_result':1,'pressure_vent_rate_result':0, \
#                'pressure_vent_delay_UL':50,'pressure_vent_delay_LL':-75,'pressure_vent_rate_UL':1434,'pressure_vent_rate_LL':784, \
#                'decay_rate':-0.5,'decay_vent_rate':500,'decay_rate_result':1,'decay_vent_rate_result':1, \
#                'decay_UL':0,'decay_LL':-5.57,'decay_vent_rate_UL':1000,'decay_vent_rate_LL':200}

#Global variables
TEST_TYPE = 'pressure'
CHANNEL = 'all'
CHANNEL_NAMES = ["magenta", "cyan","yellow","k (black)"]
source_path = ""
destination_path = ""
log_file = ""
serial_numbers_list = ["default"]

#main window 
root = tk.Tk()
root.title("PVT Test")
#set window size
root.geometry("920x750") 
#fix window drag size
#root.resizable(False,False)
#hide the root window until pop up window is closed
root.withdraw()   

#configure the grid
def configure_grid(widget):
    print(str(widget)+"grid_szie()",widget.grid_size())
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

def prompt_user_for_directory():
    global txt_source
    #pop up window to prompt user to select source directory
    prompt_window = tk.Toplevel(root)
    prompt_window.grab_set()    #make the prompt_window modal, disable the root window
    prompt_window.title("Select Project Directory")
    #set window size
    prompt_window.geometry("900x180")    
    #create a frame to hold the prompt widgets
    frm_prompt = tk.Frame(master=prompt_window,borderwidth=2)  #relief=tk.RAISED
    txt_source = tk.Text(frm_prompt,height=1,width=60,font=(7))
    btn_select_source = tk.Button(frm_prompt,width=17,font=(1),text="Select Source Dir",command=lambda:select_directory(txt_source,"source"))
    btn_next = tk.Button(frm_prompt,height=2,width=8,font=(12),text="Next",command=lambda:on_close(prompt_window,txt_source))
    btn_cancel = tk.Button(frm_prompt,height=2,width=8,font=(12),text="Cancel",command=lambda:on_cancel(prompt_window))

    btn_select_source.grid(row=0,column=0,sticky="w",padx=5,pady=5)
    txt_source.grid(row=0,column=1,sticky="nw",padx=5,pady=5,columnspan=2)
    btn_next.grid(row=2,column=2,sticky="e",padx=5,pady=5)
    if source_path != "":
        btn_cancel.grid(row=2,column=1,sticky="e",padx=5,pady=5)
    frm_prompt.grid(row=0,column=0,sticky="nw",rowspan=5)
    frm_prompt.columnconfigure(1,minsize=20,weight=1)
    #call on_close function when the window is closed
    prompt_window.protocol("WM_DELETE_WINDOW",lambda:on_close(txt_source))    

def select_directory(txt_output,type="source"):
    directory = filedialog.askdirectory(title=f"Select {type.capitalize()} Directory")
    txt_output.delete("1.0",tk.END)
    txt_output.insert(tk.END,directory)
    txt_output.xview_moveto(1)  #move the cursor to the end of the text widget, not working!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

def on_cancel(window):
    window.destroy()
    root.deiconify()   #show the root window

def on_close(window,txt_source):
    global source_path
    source_path = txt_source.get("1.0",tk.END).strip().replace('/','\\')
    print(f"source_path: {source_path}")
    if not os.path.isdir(source_path):
        messagebox.showerror("Error", "Source Directory does not exist")
    else:
        root.deiconify()   #show the root window
        window.destroy()   #destroy the pop up window
        manual_SN_selection() #get the serial numbers from the source_path
        main_GUI()
        
def exit_button_press():
    root.destroy()

def manual_SN_selection():
    global serial_numbers_list
    exists = os.path.exists(source_path)
    #get all the file names from source_path
    files = os.listdir(source_path)
    #filter only .log files
    files = [file for file in files if file.endswith(".log")]
    #get the unique serial numbers from the files
    serial_numbers_list = list(set([file.split('_')[0] for file in files]))

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
        # sys.exit()

# function to be called when an option is selected
def on_option_selected(*args):  #*args is a tuple, args[0] is the selected_option, args[1] is the selector name
    print(f"The selected option is {args[0].get()}")
    if args[1] == "Serial Number":             ########################to delete
        return
    elif args[1] == "Test":
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
    dropdown_channel.config(font=(11),width=15)

def open_file():
    '''
    filepath = askopenfilename(filetypes=[("Text Files","*.txt"),("All Files","*.*")]) 
    if not filepath:
        return
    #txt_editor.delete("1.0",tk.END)
    with open(filepath,mode="r",encoding="utf-8") as input_file:
        text = input_file.read()
        #txt_editor.insert(tk.END,text)
    root.title(f"Simple Text Editor - {filepath}")
    '''

def save_file(lbl_SN):
    filepath = asksaveasfilename(defaultextension=".txt",filetypes=[("Text Files","*.txt"),("All Files","*.*")])
    if not filepath:
        return
    with open(filepath,mode="w",encoding="utf-8") as output_file:
        #text = txt_editor.get("1.0",tk.END)
        # get text from lbl_SN
        text = lbl_SN.cget("text")
        output_file.write(text)
    root.title(f"Simple Text Editor - {filepath}")

def setup():
    #pop up window or message box to ask user to enter serial number
    serial_number = "TH36936123085Z"
    #only show files that start with serial_number

    filepath = askopenfilename(filetypes=[("Text Files","*.log"),("All Files","*.*")]) 
    if not filepath:
        return

def plot(test_type=TEST_TYPE,channel = CHANNEL):
    global serial_numbers_list,log_file
    #check the log file to load
    if test_type.lower() == 'pressure':
        log_file = obtain_latest_file('pressure')
    else:
        log_file = obtain_latest_file('decay')

    #load the log file
    data = np.loadtxt(log_file,skiprows=28,dtype=float,delimiter=',')
    #data = pd.read_csv(log_file, delimiter=',', skiprows=3, header=None)

    # Get channel names from Row 3 of log file
    with open(log_file, 'r') as file:
        lines = file.readlines()
        channel_names_raw = lines[27].strip()
        #loop through log_file row 1 to row 27 and assign the values into test_result dictionary, text before : is key and text after : is value
        for i in range(27):
            line = lines[i].strip()
            key = line.split(':')[0].strip()
            value = line.split(':')[1].strip()
            test_result[key] = value
    if len(sys.argv) > 1: 
        serial_numbers_list.clear()
        serial_numbers_list.append(test_result['serial_number'])

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
            #y_data = data[CHANNEL_NAMES.index(column)+1]
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
    TEST_TYPE=test_type
    
def main_GUI():
    #plot the graph, default is decay test
    plot("decay")     
    ########################## Left ToolBar ##########################
    frm_left_bar = tk.Frame(master=root,borderwidth=2,relief=tk.RAISED)

    btn_setup = tk.Button(frm_left_bar,height=4,width=8,font=(10),text="Set Up",command=prompt_user_for_directory)
    btn_exit = tk.Button(frm_left_bar,height=4,width=8,font=(12),text="Exit",bg = "light coral",command=exit_button_press)

    btn_setup.grid(row=1,column=0,sticky="ew",padx=5)
    tk.Label(frm_left_bar,height=15).grid(row=3,column=0)  # Empty label with desired height
    btn_exit.grid(row=4,column=0,sticky="nw",padx=5)
    frm_left_bar.grid(row=1,column=0,sticky="nw",rowspan=5)

    ######################### Top Test Info ##########################
    frm_labels = tk.Frame(master=root,borderwidth=2)
    lbl_SN = tk.Label(master=frm_labels,text=f"Serial No: {test_result['serial_number']}",height= 2, font= 11)
    lbl_sampling_rate = tk.Label(master=frm_labels,text=f"Sampling Rate: {test_result['sampling_rate']}",height= 2, font= 11)

    if test_result['test_result']:
        lbl_test_result = tk.Label(master=frm_labels,text="Pass",bg = "light green", height= 2, width= 9, font= 11)
    else:
        lbl_test_result = tk.Label(master=frm_labels,text="Fail",bg = "light coral", height= 2, width= 9, font= 11)

    #paddings for the labels
    paddings = {'padx': 5, 'pady': 5}

    lbl_SN.grid(row=0,column=0,**paddings)
    lbl_test_result.grid(row=0,column=1,**paddings)
    lbl_sampling_rate.grid(row=0,column=2,**paddings)
    frm_labels.grid(row=0,column=1,sticky="nw",columnspan=2)

    # #plot the graph, default is decay test
    # plot("decay") 

    ########################## Right Filter ##########################
    frm_selection = tk.Frame(master=root,borderwidth=2)
    lbl_select_test = tk.Label(master=frm_selection,text="Select Test:", width= 13, font= 8,bg = "light grey")
    lbl_toggle_channel = tk.Label(master=frm_selection,text="Toggle Channel:", width= 13, font= 7,bg = "light grey")
    lbl_serial_number = tk.Label(master=frm_selection,text="Serial Number:", width= 13, font= 7,bg = "light grey")

    lbl_select_test.grid(row=0,column=0,sticky="w",**paddings)
    lbl_toggle_channel.grid(row=2,column=0,sticky="w",**paddings)
    lbl_serial_number.grid(row=4,column=0,sticky="w",**paddings)
    frm_selection.grid(row=1,column=2,sticky="nw",rowspan=5)

    dropdown_menu("Channel",["all","magenta", "cyan","yellow","k (black)"],frm_selection,3,on_option_selected)
    dropdown_menu("Test",["Decay", "Pressure"],frm_selection,1,on_option_selected)
    dropdown_menu("Serial Number",serial_numbers_list,frm_selection,5,on_option_selected)
    ########################## Test Result ###########################
    # test results frame
    frm_result = tk.Frame(master=root,borderwidth=2)
    frm_max_pressures = tk.Frame(master=frm_result,borderwidth=2,highlightbackground="black", highlightthickness=2,height=2000)
    frm_pressure_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)
    frm_decay_test_result = tk.Frame(master=frm_result,borderwidth=2, highlightbackground="black", highlightthickness=2)

    frm_result.grid(row=2,column=1,sticky="nw",columnspan=2)
    frm_max_pressures.grid(row=0,column=0,sticky="nw",**paddings)
    frm_pressure_test_result.grid(row=0,column=1,sticky="nw",**paddings)
    frm_decay_test_result.grid(row=0,column=2,sticky="nw",**paddings)

    # set titles for each test result frames
    lbl_max_pressure_title = tk.Label(master=frm_max_pressures,text="Max Pressures", font= (None, 16, "bold"))
    lbl_max_pressure_title.grid(row=0,column=0,sticky="w", pady=3.3, columnspan=2)

    lbl_pressure_test_title = tk.Label(master=frm_pressure_test_result,text="Pressure Test", font= (None, 16, "bold"))
    lbl_pressure_test_title.grid(row=0,column=0,sticky="w",pady=1)

    lbl_decay_test_title = tk.Label(master=frm_decay_test_result,text="Decay Test", font=(None, 16, "bold"))
    lbl_decay_test_title.grid(row=0,column=0,sticky="w",pady=1)

    # test result for max pressures
    index = 1
    for key,value in islice(test_result.items(),6,10):
        #lbl_max_pressure = tk.Label(master=frm_max_pressures,text=f"{CHANNEL_NAMES[max_pressures.index(channel)].capitalize()}:", font= 9)
        lbl_max_pressure = tk.Label(master=frm_max_pressures,text= key.split('_')[1].capitalize(), font= 9)
        lbl_max_pressure_value = tk.Label(master=frm_max_pressures,text=f"{value}", font= 9,bg="white")
        lbl_max_pressure.grid(row=index,column=0,sticky="nw",pady=5)
        lbl_max_pressure_value.grid(row=index,column=1,sticky="nw",pady=5)
        index += 1

    maxP_within_range = test_result['maxP_within_range']
    if maxP_within_range:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Pass",bg = "light green", width= 15, font= 9)
    else:
        lbl_max_pressure_result = tk.Label(master=frm_max_pressures,text="Fail",bg = "light coral", width= 15, font= 9)
    lbl_max_pressure_result.grid(row=5,column=0,sticky="nw",**paddings,columnspan=2)

    # test result for Pressure Test
    row_increment = 0
    for key,value in islice(test_result.items(),11,13):
        background = "light green" if test_result[key+'_result'] == 1 else "light coral"
        #extract the string vent_delay or vent_rate from the key
        lbl_pressure_test = tk.Label(master=frm_pressure_test_result, text=f"{key.split('pressure_')[1].replace('_', ' ').title()}", width= 15, font= 9)
        lbl_pressure_test_limit = tk.Label(master=frm_pressure_test_result,text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", fg="grey", width= 15, font=(None, 12))
        lbl_pressure_test_result = tk.Label(master=frm_pressure_test_result,text=f"{value}",bg = background, width= 15, font= 9)
        lbl_pressure_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3) 
        lbl_pressure_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_pressure_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
        row_increment += 3

    # test result for Decay Test
    row_increment = 0
    for key,value in islice(test_result.items(),19,21):
        background = "light green" if test_result[key+'_result'] == 1 else "light coral"
        lbl_decay_test = tk.Label(master=frm_decay_test_result,text = "Decay Rate" if key == 'decay_rate' else "Vent Rate", width= 15, font= 9)
        lbl_decay_test_limit = tk.Label(master=frm_decay_test_result,text=f"UL: {test_result[key+'_UL']}  LL: {test_result[key+'_LL']}", width= 15, font= (None, 12), fg="grey")
        lbl_decay_test_result = tk.Label(master=frm_decay_test_result,text=f"{value}",bg = background, width= 15, font= 9)
        lbl_decay_test.grid(row=2+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_decay_test_limit.grid(row=3+row_increment,column=0,sticky="nw",padx=5,pady=3)
        lbl_decay_test_result.grid(row=4+row_increment,column=0,sticky="nw",padx=5,pady=3)
        row_increment += 3

    ########################## Bottom Bar ###########################
    #bottom bar to show the log file name
    frm_bottom_bar = tk.Frame(master=root,borderwidth=2)
    filename = log_file.split('\\')[-1]
    lbl_log_file = tk.Label(master=frm_bottom_bar,text=f"Log File:{filename}",font= ('Arial',13))
    lbl_log_file.grid(row=0,column=0,sticky="nw",padx=5,pady=5)
    frm_bottom_bar.grid(row=3,column=1,sticky="nw",columnspan=2)

    configure_grid(root)
    configure_grid(frm_left_bar)
    configure_grid(frm_labels)
    configure_grid(frm_selection)
    configure_grid(frm_result)
    configure_grid(frm_max_pressures)
    configure_grid(frm_pressure_test_result)
    configure_grid(frm_decay_test_result)
    ##################################################################

if __name__ == "__main__":
    #'''
    #check if path variable is available from CIMation
    if len(sys.argv) > 1:                    #From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory    
        source_path = str(sys.argv[1]).strip().replace('/','\\')      #assign argv[1] value into source_path  
        #destination_path = str(sys.argv[2]).strip().replace('/','\\') #assign argv[2] value into destination_path  
        print("source_path: ",source_path)
        root.deiconify()   #show the root window
        main_GUI()
    else:
        #light up a button that prompts user to select a sourceDirectory
        prompt_user_for_directory()
    #'''    
    #start the event loop
    root.mainloop()    
   
    