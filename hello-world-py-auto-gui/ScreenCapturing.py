
import sys
# used to point to the location of the PyAutoGui library
sys.path.append('C:\\Users\\MSI\\Desktop\\module')
import pyautogui
import socket

import threading
import queue
import socket
import time


windows = pyautogui.getAllTitles()


'''
ourQueue = queue.Queue()

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print("trying to connect")
s.connect(('127.0.0.1', 30303))
#s.connect(('10.152.210.13', 30303)) # krystof ip
print('connect sucessfull')

def threadCaptureScreen():
    print("Capture screen thread started")
    while(True):
        for i in range(100):
            fileName = str(i) + ".jpg"
            pyautogui.screenshot( fileName )
            pyautogui.screenshot()
            ourQueue.put(fileName)
            print("added file name to queue: " + fileName)


def threadSendToClient():
    print("Send to client thread started")
    while(True):
        while(0 == ourQueue.qsize()):
            time.sleep(0.01)
            print("sleeping because there are no images in the queue")
        while(ourQueue.qsize() > 2):
            ourQueue.get()
            print("dumping images because queue is too big")
        fileName = ourQueue.get()
        print("file name read from queue:" + fileName)
        in_file = open(fileName, "rb")  # opening for [r]eading as [b]inary
        data = in_file.read()  # if you only wanted to read 512 bytes, do .read(512)
        in_file.close()
        print("image size is: " + str(len(data)))
        theImageSize = (len(data)).to_bytes(4, byteorder="little", signed=True)
        print("image size in bytes: " + str(theImageSize))
        s.send(theImageSize)
        s.send(data)
        print("finished sending a file to the client")


threading.Thread(target=threadCaptureScreen).start()
threading.Thread(target=threadSendToClient).start()

print("\nstarted worker threads and putting main thread to sleep in a loop")

while(True):
    time.sleep(0.1)
'''



