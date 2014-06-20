#!/usr/bin/env python
print "\n================================================"
print "             Serial Communication"
print "================================================"
from sys import stdout
from time import sleep

try:
    import serial
except:
    print "Could not import serial!"
try:
    usbport = 'COM1'
    ser = serial.Serial(usbport, 9600, timeout=1)
except:
    print "Cannot read " + usbport
    SystemExit
    quit()
#myList[:]
while(1==1):
    y = ser.read()
    while(y != "~"):
        var = raw_input("Enter Something: ")
        ser.write("~")
        ser.write(var)
        ser.write("~")
    #print y
    while(y == '~'):
        x = ser.read()
        while(x != '~'):
            stdout.write(x)
            #print '\r'x
            stdout.flush()
            x = ser.read()
        stdout.write("\n")
