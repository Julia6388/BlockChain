from tkinter import *
from PIL import Image, ImageTk, ImageFont, ImageDraw
from tkinter import filedialog
import fitz

baseWindow = Tk()
pdf_document = fitz.open("D:\Учеба\3 курс\Курсач\DOC2")
for current_page in range(len(pdf_document)):
    for image in pdf_document.getPageImageList(current_page):
        xref = image[0]
    pix = fitz.Pixmap(pdf_document, xref)
    if pix.n < 5:
        pix.writePNG("page%s-%s.png" % (current_page, xref))
    else:
        pix1 = fitz.Pixmap(fitz.csRGB, pix)
        pix1.writePNG("page%s-%s.png" % (current_page, xref))
        pix1 = None
        pix = None
i=0
for im in xref :
    i+=1
    img = Image.open(im)
    img = img.resize((400, 400), Image.ANTIALIAS)
    img = ImageTk.PhotoImage(img)
    label = Label(baseWindow, image=img)
    label.image = img
    label.grid(column=1+i, row=1, rowspan=7, padx=20, sticky=N)
baseWindow.mainloop()