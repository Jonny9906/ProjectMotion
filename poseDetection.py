from ultralytics import YOLO
import numpy
import tensorflow as tf
import cv2

#Loads YOLO Computer Vision model
model = YOLO("yolov8l-pose.pt")
results = model(
    source="/Users/jonathannguyen/Desktop/Screen Recording 2023-11-17 at 1.11.43 PM.mov",
    show=True,
    stream=True,
    save=False,
)

#List that will holds x and y coordniates of pose
poslist = []
# Perform tracking with the model
coords = []
for r in results:
    kpt = r.keypoints.xy.cpu().numpy()
    temp = ""
    for i in range(tf.size(kpt) // 4 - 1):
        temp += f"{(kpt[0,i,0])}, {(kpt[0,i,1])}, "
    coords.append(temp)
    with open("SwingFile.txt", "w") as f:
        f.writelines(["%s\n " % item for item in coords])

print(poslist)
