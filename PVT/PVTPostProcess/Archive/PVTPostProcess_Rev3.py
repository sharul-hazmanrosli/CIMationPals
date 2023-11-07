import sys
import os
from turtle import color
import pandas as pd
import matplotlib.pyplot as plt
import glob
from itertools import islice

import webcolors
import plotly.graph_objs as go
import plotly.offline as offline

import tkinter as tk

def main():

    create_GUI()  # Get the input values from the GUI after the GUI close
     
    # Step 1: Import text file into a pandas DataFrame
    # Replace with the path to your text file & location to save graph image
      
    
     # To use the latest modified PressureTest.txt in the folder
    
    #results_file_path = r"C:\Program Files (x86)\CIMProjects.Net\Marconi\Results\Mech2TestPrimingPressure_Marconi"
    #graph_screenshot_path = r"C:\Users\TangH76\OneDrive - HP Inc\Automation\Python_Graphs\TextFileToGraph\Data_and_PostProcessImage\Image"

    #latest_test_file = obtain_data_files(results_file_path)

    # Step 2: Generate the graph
    #generated_graph = interactive_graph(latest_test_file, graph_screenshot_path)
    #print(f"Graph saved in {generated_graph}") 


def create_GUI():
    # Create the main window
    root = tk.Tk()
    root.title("Graph Generator")

    # Labels and Entry widgets
    label_display = ["Path of Log files:","Path for generated graph:", "Test Type:"]
    labels = ["Directory","Results"]

    # Create a Text widget
    text_display = tk.Text(root, height=10, width=40)  # Set the height and width as needed
    text_display.pack()

    def update_text_display():
        # Get the text from entry widgets
        directory = entry_widgets["Directory"].get()
        results = entry_widgets["Results"].get()

        # Perform some operation (for example, concatenation)
        result_text = f"Directory: {directory}\nResults: {results}"

        # Clear existing text and insert new text
        text_display.delete("1.0", tk.END)  # Clear existing text
        text_display.insert(tk.END, result_text)  # Insert new text
        
    # Create labels and entry widgets, and store them in a dictionary
    entry_widgets = {}
    for i in range(len(labels)):
        label = tk.Label(root, text=label_display[i])
        label.pack()

        #Entry widget (text box), stores label as key & entry_widgets as value in dictionary
        entry = tk.Entry(root)          
        entry.pack(fill=tk.BOTH, expand=True)
        entry.pack()
                
        # Store label as key and entry widget as value in the dictionary
        entry_widgets[labels[i]] = entry

        #From CIMation, argv[1] = sourceDirectory, argv[2] = destinationDirectory
        if len(sys.argv) == 3:    
            j = i + 1
            entry_widgets[labels[i]] = entry.insert("end", sys.argv[j])   #insert argv value into entry (text box)
            entry_widgets[labels[i]] = entry.get()                        #update entry_widgets value with argv value
        else:
            pass
             
    # Dropdown menu options
    test_types = ["DecayTest", "PressureTest"]
    selected_test_type = tk.StringVar()
    selected_test_type.set(test_types[0])  # Default value
        
    # Create dropdown menu
    dropdown_menu = tk.OptionMenu(root, selected_test_type, *test_types)
    dropdown_menu.pack()
    
    # Create an error label
    error_label = tk.Label(root, fg="red")  # Set the text color to red for error messages
    error_label.pack()  # Pack the label below the entry widgets
        
    def on_submit():
        file_paths = get_inputs(entry_widgets)
        results_file_path = r"{}".format(file_paths["Directory"])
        graph_screenshot_path = r"{}".format(file_paths["Results"])
        
        print("graph_screenshot_path:", graph_screenshot_path)
        print(check_graph_path(graph_screenshot_path))

        selected_type = selected_test_type.get()
            
        print("Results File Path (raw string):", results_file_path)
        print("Graph Screenshot Path (raw string):", graph_screenshot_path)
        print("Selected Test Type:", selected_type)
        
        # instead of printing values, create the interactive graph
        valid_data = obtain_data_files(results_file_path, selected_type)
        valid_graph = check_graph_path(graph_screenshot_path)
        
        if valid_data and valid_graph:
            error_label.config(text="")
            # Create the interactive graph here
            graph_path = interactive_graph(valid_data, graph_screenshot_path)
            return graph_path
        
       
        if not valid_data and valid_graph:
            entry_widgets["Directory"].delete(0, tk.END)
            error_label.config(text= "No log file found or invalid directory")
        elif valid_data and not valid_graph :
            entry_widgets["Results"].delete(0, tk.END)
            error_label.config(text= "Invalid directory")
        else:
            # clear both entry widgets if both are invalid
            error_label.config(text= "Invalid directories and no log files found")
            entry_widgets["Directory"].delete(0, tk.END)
            entry_widgets["Results"].delete(0, tk.END)                       
        
        
    def exit_gui():
        root.destroy()

    submit_button = tk.Button(root, text="Submit", command=lambda: on_submit())
    submit_button.pack()

    exit_button = tk.Button(root, text="Exit", command=exit_gui)
    exit_button.pack()

    root.mainloop()
    
    # Return an empty dictionary if the window is closed without submitting
    return {}
       
    
# Function to be called when the button is clicked
def get_inputs(entry_widgets):
    input_values = {label: entry.get() for label, entry in entry_widgets.items()}
    return input_values

# Check that graph_screenshot_path is valid
def check_graph_path(graph_screenshot_path):
    if os.path.exists(graph_screenshot_path):
        return True
    else:
        print(f"Error: {graph_screenshot_path} is not a valid path")
        return False


def obtain_data_files(results_file_path, selected_type):
    # Use glob to find files matching the pattern '*PressureTest.log'
    desired_graph = selected_type
    test_name = '*' + desired_graph + '.log'
    files = glob.glob(os.path.join(results_file_path, test_name))

    # If test file exist, use latest ; else exit  
    if files:
        # Sort files based on modification time (latest file first)
        latest_test_file = max(files, key=os.path.getmtime)
        return latest_test_file
    else:
        print(f"Error: No {desired_graph} file found")
        # sys.exit()

def interactive_graph(latest_test_file, graph_screenshot_path):
    
    # Read data starting from the 4th line, without a header, and reset the index
    df = pd.read_csv(latest_test_file, delimiter=',', skiprows=3, header=None)
    df.reset_index(drop=True, inplace=True)

    # Get label names from Row 3 of data file
    with open(latest_test_file, 'r') as file:
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
        title=latest_test_file.split('\\')[-1].split('.')[0],
        xaxis=dict(title='No. of Samples'),
        yaxis=dict(title='Pressure'),
        showlegend=True  # Show legend to allow toggling columns
    )

    # Create the figure
    fig = go.Figure(data=traces, layout=layout)

    # Save the graph as an HTML file (offline interactive graph)
    image_name = latest_test_file.split('\\')[-1].split('.')[0] + '.html' # Extract the file name from the path
    graph_path = graph_screenshot_path + '\\' + image_name # Rename the plot pic name
    offline.plot(fig, filename=graph_path, auto_open=False)
    return graph_path

    '''

    #-------------------- Normal Graph --------------------
    # Generate a stacked line plot using all columns
    plt.figure(figsize=(8, 6))  # Adjust the figure size as needed
    
    for column in range(1,5):   # Columns 2 to 5 (Python uses 0-based indexing)
        plt.plot(df[column], label=sample_names[column-1] )  # Plot each column with respective label
    
    plt.title(desired_graph)
    plt.xlabel('No. of Samples')
    plt.ylabel('Pressure')    
    plt.legend(loc='upper right')  # Add a legend to label the lines

    # Save a screenshot of the generated graph
    image_name = latest_test_file.split('\\')[-1].split('.')[0] + '.png' # Extract the file name from the path
    graph_screenshot_path = graph_screenshot_path + '\\' + image_name # Rename the plot pic name
    plt.savefig(graph_screenshot_path)

    # Show the graph (optional)
    plt.show()

    print(f"Graph screenshot saved as {graph_screenshot_path}")

    '''

def color_name_to_hex(color_name):
    try:
        # Get the hexadecimal representation of the color name
        hex_value = webcolors.name_to_hex(color_name)
        return hex_value
    except ValueError:
        # Handle the case when the color name is not valid
        return None
    
if __name__ == '__main__':
    main()

