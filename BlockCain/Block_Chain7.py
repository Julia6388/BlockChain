from tkinter import *
from tkinter import scrolledtext
from tkinter import filedialog
import tkinter.messagebox as mb
from functools import partial
from PIL import ImageTk, Image
import hashlib

class BlockChain:
    def __init__(self):
        self.chain = [self.createGenesisBlock()]

    def createGenesisBlock(self):
        return Block(0, 0, "", "", "", "", "", "", 0, 0 )

    def getLatestBlock(self):
        return self.chain[len(self.chain)-1]

    def addBlock(self, newBlock):
        newBlock.PastHash =self.getLatestBlock().Hash
        newBlock.Hash = newBlock.calculateHash()
        if newBlock.Hash != 0 :
            self.chain.append(newBlock)
            return True
        else :
            del newBlock
            return False

    def isChainValid(self):
        for i in range (1, len(self.chain)):
            currentBlock= self.chain[i]
            previouseBlock = self.chain[i-1]
            if currentBlock.Hash != currentBlock.calculateHash():
                return False
            if currentBlock.PastHash != previouseBlock.Hash:
                return False
        return True

class Block(object):

    def __init__(self, type, num, DOC1, DOC2, DOC3,DOC4, DOC5, DOC6, Hash, PastHash):
        """Constructor"""
        self.type =type
        self.num = num
        self.DOC1 = DOC1
        self.DOC2 = DOC2
        self.DOC3 = DOC3
        self.DOC4 = DOC4
        self.DOC5 = DOC5
        self.DOC6 = DOC6
        self.Hash = Hash
        self.PastHash = PastHash

    def calculateHash (self):
        if self.type == 1 and self.DOC1 != "" and self.DOC2 != "" and self.DOC3 != "" \
                and self.DOC4 != "" and self.DOC5 != "":
            str1 = str(self.type)+ str(self.num) + self.DOC1 + self.DOC2 + self.DOC3 \
                   + self.DOC4 + self.DOC5 +self.DOC6 + str(self.PastHash) # добавить связку с предыдущим блоком
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 2 and self.DOC1 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 3 and self.DOC1 != "" and self.DOC2 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 +self.DOC2 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 4 and self.DOC1 != "" and self.DOC2 != ""\
                and self.DOC3 != "" and self.DOC4 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 +self.DOC2 +\
                   +self.DOC3 + self.DOC4 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 5 and self.DOC1 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 6 and self.DOC1 != "" and self.DOC2 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 +self.DOC2 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        elif self.type == 7 and self.DOC1 != "" and self.DOC2 != "" :
            str1 = str(self.type) + str(self.num) +self.DOC1 +self.DOC2 + str(self.PastHash)
            return hashlib.sha256(str1.encode()).hexdigest()
        else :
            msg2 = "Не все поля заполнены! Невозможно сохранить блок"
            show_error(msg2)
            return 0

def addFile (block, doc):
    global txt3, label
    if 'txt3' in globals():
        txt3.grid_remove()
    if 'label' in globals():
        label.grid_remove()
    file1 = filedialog.askopenfile(mode ='rb', filetypes=(("all files", "*.*"),("Text files", "*.txt"),
                                                          ('Image Files', [".jpeg", ".jpg", ".png", ".gif",".tiff", ".tif", ".bmp"]),
                                                          ("PDF files", "*.pdf")))
    if file1 is not None:
        strname=str(file1)
        h = file1.read()
        str1=""
        for c in h:
            str1=str1+str(c)
        if selected.get() == 1 :
            if doc==1:
                block.DOC1=str1
            elif doc==2:
                block.DOC2=str1
            elif doc==3:
                block.DOC3=str1
            elif doc==4:
                block.DOC4=str1
            elif doc==5:
                block.DOC5=str1
            elif doc==6:
                block.DOC6=str1
        if selected.get() == 2 :
            block.DOC1 = str1
        if selected.get() == 3 :
            if doc == 1:
                block.DOC1 = str1
            elif doc == 2:
                block.DOC2 = str1
        if selected.get() == 4:
            if doc == 1:
                block.DOC1 = str1
            elif doc == 2:
                block.DOC2 = str1
            elif doc == 3:
                block.DOC3 = str1
            elif doc == 4:
                block.DOC4 = str1
        if selected.get() == 5:
            block.DOC1 = str1
        if selected.get() == 6:
            if doc == 1:
                block.DOC1 = str1
            elif doc == 2:
                block.DOC2 = str1
        if selected.get() == 7:
            if doc == 1:
                block.DOC1 = str1
            elif doc == 2:
                block.DOC2 = str1
        # предпросмотр
        list=strname.split("'")
        strname2=list[1]
        if strname2[-3:]=="txt":
            f = open(strname2, 'r')
            txt3 = scrolledtext.ScrolledText(window, width=30, height=20)
            txt3.grid(column=5, row=1, rowspan=7, padx=20, sticky=N)
            txt3.insert(INSERT, f.read())
        elif strname2[-3:] !="pdf":
            img = Image.open(file1)
            img = img.resize((400, 400), Image.ANTIALIAS)
            img = ImageTk.PhotoImage(img)
            label = Label(window, image=img)
            label.image = img
            label.grid(column=5, row=1, rowspan=7, padx=20, sticky=N)

def show_error(msg):
    mb.showerror("Ошибка", msg)

def show_info(msg):
    mb.showinfo("Информация", msg)

def SaveBlock(MyChain, block):
    if MyChain.addBlock(block) == True:
        show_info("Блок успешно сохранен")
        if selected.get()==1:
            txt.insert(INSERT," Номер блока: " + str(block.num) +"\n ПТС: " +block.DOC1[:20] + "\n Свидетельство о регистрации ТС: "+block.DOC2[:20] +
                       "\n ОСАГО: "+block.DOC3[:20] +"\n Сервисная книжка: "+block.DOC4[:20] +
                       "\n Диагностическая карта: " + block.DOC5[:20] +"\n КАСКО: "+block.DOC6[:20] +
                       "\n Hash: "+str(block.Hash) +"\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==2:
            txt.insert(INSERT," Номер блока: " +str(block.num) + "\n Сервисная книжка: " +block.DOC1[:20]
                       + "\n Hash: "+str(block.Hash) +"\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==3:
            txt.insert(INSERT," Номер блока: " +str(block.num) + "\n Справка о ДТП: " +block.DOC1[:20]
                       +"\n Пробег ТС: " + block.DOC2[:20] + "\n Hash: "+str(block.Hash) +"\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==4:
            txt.insert(INSERT," Номер блока: " + str(block.num) +"\n Акт приема-передачи имущества: " +block.DOC1[:20]
                       + "\n Догвор купли-продажи: "+block.DOC2[:20] +
                       "\n Обновленные записи в документах : "+block.DOC3[:20] +"\n Пробег авто: "+block.DOC4[:20] +
                       "\n Hash: "+str(block.Hash) +"\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==5:
            txt.insert(INSERT," Номер блока: " +str(block.num) + "\n Залоговый билет: " +block.DOC1[:20]
                       + "\n Hash: "+str(block.Hash) +"\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==6:
            txt.insert(INSERT," Номер блока: " +str(block.num) + "\n Кредитный договор: " +block.DOC1[:20]
                       +"\n Договор о залоге ТС: " + block.DOC2[:20] + "\n Hash: "+str(block.Hash) +
                       "\n PastHash: "+str(block.PastHash)+"\n")
        elif selected.get()==7:
            txt.insert(INSERT," Номер блока: " +str(block.num) + "\n ПТС: " +block.DOC1[:20]
                       +"\n Справка о снятии с учета в ГИБДД: " + block.DOC2[:20] + "\n Hash: "+str(block.Hash) +
                       "\n PastHash: "+str(block.PastHash)+"\n")
        if (MyChain.isChainValid()):
            txt.insert(INSERT, "OK \n")
        else:
            txt.insert(INSERT, "Not OK \n")
    if 'btn1' in globals():
        btn1.grid_remove()
    if 'btn2' in globals():
        btn2.grid_remove()
    if 'btn3' in globals():
        btn3.grid_remove()
    if 'btn4' in globals():
        btn4.grid_remove()
    if 'btn5' in globals():
        btn5.grid_remove()
    if 'btn6' in globals():
        btn6.grid_remove()
    if 'btn7' in globals():
        btn7.grid_remove()
    if 'txt3' in globals():
        txt3.grid_remove()
    if 'label' in globals():
        label.grid_remove()


def clicked(MyBlockChain):
    global btn1, btn2,btn3,btn4, btn5, btn6, btn7
    block = Block( selected.get(), len(MyBlockChain.chain), "", "", "", "", "", "", 0, 0)
    if selected.get()==1:
        btn1 = Button(window, text="Добавить ПТС", command=partial(addFile, block, 1))
        btn2 = Button(window, text="Добавить свидетельство о регистрации ТС", command=partial(addFile, block, 2))
        btn3 = Button(window, text="Добавить полис ОСАГО", command=partial(addFile, block, 3))
        btn4 = Button(window, text="Добавить сервисную книжку", command=partial(addFile, block, 4))
        btn5 = Button(window, text="Добавить диагностическую карту", command=partial(addFile, block, 5))
        btn6 = Button(window, text="Добавить полис КАСКО", command=partial(addFile, block, 6))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn2.grid(column=4, row=2)
        btn3.grid(column=4, row=3)
        btn4.grid(column=4, row=4)
        btn5.grid(column=4, row=5)
        btn6.grid(column=4, row=6)
        btn7.grid(column=4, row=7)
    elif selected.get()==2 :
        btn1 = Button(window, text="Фиксация изменения записей в сервисной книжке", command=partial(addFile, block, 1))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn7.grid(column=4, row=2)
    elif selected.get()==3 :
        btn1 = Button(window, text="Справка из ГАИ о ДТП", command=partial(addFile, block, 1))
        btn2 = Button(window, text="Пробег ТС на момент ДТП", command=partial(addFile, block, 2))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn2.grid(column=4, row=2)
        btn7.grid(column=4, row=3)
    elif selected.get()==4 :
        btn1 = Button(window, text="Акт приема-передачи имущества", command=partial(addFile, block, 1))
        btn2 = Button(window, text="Догвор купли-продажи", command=partial(addFile, block, 2))
        btn3 = Button(window, text="Обновленные записи в документах на авто ", command=partial(addFile, block, 3))
        btn4 = Button(window, text="Пробег авто", command=partial(addFile, block, 4))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn2.grid(column=4, row=2)
        btn3.grid(column=4, row=3)
        btn4.grid(column=4, row=4)
        btn7.grid(column=4, row=5)
    elif selected.get()==5 :
        btn1 = Button(window, text="Залоговый билет", command=partial(addFile, block, 1))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn7.grid(column=4, row=2)
    elif selected.get()==6 :
        btn1 = Button(window, text="Кредитный договор", command=partial(addFile, block, 1))
        btn2 = Button(window, text="Договор о залоге ТС", command=partial(addFile, block, 2))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn2.grid(column=4, row=2)
        btn7.grid(column=4, row=3)
    elif selected.get()==7 :
        btn1 = Button(window, text="ПТС с отметкой о сдаче ТС в утиль", command=partial(addFile, block, 1))
        btn2 = Button(window, text="Справка о снятии ТС с учета в ГИБДД", command=partial(addFile, block, 2))
        btn7 = Button(window, text="Сохранить блок", command=partial(SaveBlock, MyBlockChain, block))
        btn1.grid(column=4, row=1)
        btn2.grid(column=4, row=2)
        btn7.grid(column=4, row=3)

global txt, window, selected
window = Tk()
window.title("Blockchain")
window.geometry('1400x600')
MyBlockChain =BlockChain()
btn = Button(window, text="Добавить блок", command=partial(clicked,MyBlockChain))
btn.grid(column=0, row=0, sticky=NW)
lbl = Label(window, text="Проверка целостности блоков", font=("Arial", 12))
lbl.grid(column=1, row=0, padx=20, sticky=NW)
txt = scrolledtext.ScrolledText(window, width=30, height=20)
txt.grid(column=1, row=1, rowspan=8, padx=20, sticky=N)
selected = IntVar()
rad1 = Radiobutton(window, text='Покупка ТС', value=1, variable=selected)
rad2 = Radiobutton(window, text='Прохождение ТО/ремонтные работы', value=2, variable=selected)
rad3 = Radiobutton(window, text='Регистрация ДТП', value=3, variable=selected)
rad4 = Radiobutton(window, text='Смена владельца (покупка/продажа ТС)', value=4, variable=selected)
rad5 = Radiobutton(window, text='Залог ТС', value=5, variable=selected)
rad6 = Radiobutton(window, text='Автокредит', value=6, variable=selected)
rad7 = Radiobutton(window, text='Утилизация', value=7, variable=selected)
rad1.grid(column=0, row=1, sticky=NW)
rad2.grid(column=0, row=2, sticky=NW)
rad3.grid(column=0, row=3, sticky=NW)
rad4.grid(column=0, row=4, sticky=NW)
rad5.grid(column=0, row=5, sticky=NW)
rad6.grid(column=0, row=6, sticky=NW)
rad7.grid(column=0, row=7, sticky=NW)

window.mainloop()
