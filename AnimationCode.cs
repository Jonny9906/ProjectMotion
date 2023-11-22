using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;


public class AnimationCode : MonoBehaviour
{
    public GameObject[] Body;
    List<string> lines;
    List<string> lines2;
    int counter = 1;
    
    void Start()
    {
        // Access the files contaning coordinates from the video(s)
        lines = System.IO.File.ReadLines("Assets/JonnySwing.txt").ToList();
        lines2 = System.IO.File.ReadLines("Assets/SwingFile.txt").ToList();
    }


    void Update()
    {
        // Splits coordniates into lists
        string[] points = lines[counter].Split(',');
        string[] points2 = lines2[counter].Split(',');

        // Iterates 16 times, each iteration is for an individual sphere
        for (int i = 0; i <= 16; i++)
        {
            // Assigns x, y, and z values the 
            float x = float.Parse(points[0 + (i * 2)]) / 100;
            float y = -float.Parse(points[1 + (i * 2)]) / 100;
            float z = -float.Parse(points2[0 + (i * 2)]) / 100;

            //Changes location of the indivdual sphere
            Body[i].transform.localPosition = new Vector3(x, y, z);
        }

        // Time inbetween frames
        counter += 1;
        if (counter == lines.Count) { counter = 0; }
        Thread.Sleep(30);
    }
}
