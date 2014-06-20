#!/usr/bin/env python
print "\n================================================"
print "             Serial Communication"
print "================================================"
from sys import stdout
from time import sleep
from Tkinter import *

'''try:
    import serial
except:
    print "Could not import serial!"
try:
    usbport = 'COM2'
    ser = serial.Serial(usbport, 9600, timeout=1)
except:
    print "Cannot read " + usbport
    SystemExit
    quit()'''

    
root = Tk()
root.minsize(300,300)
root.geometry("650x450")
var = StringVar()
label = Label(root,fg="white", textvariable = var, anchor=NW, width=100, height=20,bg="black")
label.grid(padx=0,pady=0)
var.set("Hey!? How are you doing?")
entry = Entry(root, width=70)
entry.grid(padx=1,pady=6)
def onok():
    #var.set(label.cget("text") + "\n" + entry.get())
    var.set(entry.get())
    #root.update_idletasks()
Button(root, text='OK', command=onok).grid(padx =12,pady=10)
root.mainloop()


'''while(1==1):
    y = ser.read()
    while(y != '~'):
        ser.write("~")
        ser.write(entry.get())
        ser.write("~")
    #print y
    if(y == '~'):
        x = ser.read()
        while(x != '~'):
            var.set(x)
            var.set("\n")'''
