# -*- coding: utf-8 -*-
"""
Created on Wed Oct  9 16:14:22 2019

@author: MinchunHuang
"""
import openpyxl 
import visa
import string
import numpy as np
import time
from struct import unpack

punc=string.punctuation
rm = visa.ResourceManager()
scope = rm.open_resource('USB::0x0699::0x0401::C010077::INSTR')
scope.write('HORizontal:RECOrdlength 10000')
scope.write('HORizontal:SCAle 0.1')
scope.write('dat:star 0')
scope.write('dat:stop 10000')
savedataname="DPOraw.xlsx"

Graylevel = []
f = open('Settingcount.ini','r')
for line in f.readlines():
    Graylevel.append(line.strip())
f.close()
c=Graylevel[1]
cc=c[-3:]
if cc[0] in punc:        #找Start gray level
    count = int(c[-2:])
elif cc[1] in punc:
    count = int(c[-1:])
else:
    count = int(c[-3:])
#----------------Draw----------------#    
def Draw():
    #samplerate = scope.ask('HORizontal:SAMPLERate?')
    #length = scope.ask('HORizontal:RECOrdlength?')
    #scale = scope.ask('HORizontal:SCAle?')
    global ADC_wave_list,Volts
    ymult = float(scope.ask('WFMPRE:YMULT?'))  #Returns the vertical scale factor per digitizing level for the outgoing waveform
    yzero = float(scope.ask('WFMPRE:YZERO?'))  #Returns the vertical offset for the outgoing waveform
    yoff = float(scope.ask('WFMPRE:YOFF?'))  #Returns the vertical position in digitizing levels for the outgoing waveform
    #xincr = float(scope.ask('WFMPRE:XINCR?')) 
    #ver = scope.query('CH1:SCAle?')
    scope.write('CURVE?')
    data = scope.read_raw()
    headerlen = 2 + int(data[1])
    #header = data[:headerlen]
    ADC_wave = data[headerlen:-1]
    ADC_wave = np.array(unpack('%sB' % len(ADC_wave),ADC_wave))
    ADC_wave_list = ADC_wave.tolist()
    Volts = (ADC_wave - yoff) * ymult  + yzero
    #Time = np.arange(0, xincr * len(Volts), xincr)
    #pylab.plot(Time, Volts)
    #pylab.show()
#-------------------------------------#
#------------------Save to Excel-----------------------#

Draw()
wb=openpyxl.load_workbook(savedataname)
sheet = wb.active         
for t in range(9952):
    sheet.cell(row=1+t,column=1+count,value=Volts[t])
count = count + 1
wb.save(savedataname)
wb.close()
   


#--------------------------------------- --------------------#    
   

                
            
        

#--------------------------------------- #

     
 #except IOError:
    #print('ERROR!')
    #sys.exit('No file')