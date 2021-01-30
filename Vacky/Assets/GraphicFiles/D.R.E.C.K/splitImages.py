# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""

from PIL import Image
import os

infile = 'Dreck5.png'
basename = infile[:-4]
if not os.path.isdir(basename):
    os.mkdir(basename)

img = Image.open(infile)

imgwidth, imgheight = img.size

height = 16
width  = 16

for x, i in enumerate(range(0,imgheight,height)):
    for y, j in enumerate(range(0,imgwidth,width)):
        box = (j, i, j+width, i+height)
        a = img.crop(box)
        a.save(f'{basename}/{x}_{y}.png')