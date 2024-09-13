from ultralytics import YOLO
import numpy
import tensorflow as tf

# Loads YOLO Computer Vision model
model = YOLO("yolov8l-pose.pt")
results = model(
    source="/Users/jonathannguyen/Downloads/IMG_5079.mov",
    show=True,
    stream=True,
    save=False,
)

# List that will holds x and y coordniates of pose
poslist = []
# Perform tracking with the model
coords = []
for r in results:
    kpt = r.keypoints.xy.cpu().numpy()
    temp = ""
    print(tf.size(kpt))
    for i in range(tf.size(kpt) // 2):
        temp = ",".join(f"{kpt[0, i, 0]},{kpt[0, i, 1]}" for i in range(kpt.shape[1]))
        # temp += f"{(kpt[0,i,0])},{(kpt[0,i,1])},"
    coords.append(temp)
    with open("Coords.txt", "w") as f:
        f.writelines(["%s\n " % item for item in coords])
