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
    // Start is called before the first frame update
    void Start()
    {
        lines = System.IO.File.ReadLines("Assets/JonnySwing.txt").ToList();
        lines2 = System.IO.File.ReadLines("Assets/SwingFile.txt").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        print(lines2);
        string[] points = lines[counter].Split(',');
        string[] points2 = lines2[counter].Split(',');
        for (int i = 0; i <= 16; i++)
        {
            float x = float.Parse(points[0 + (i * 2)]) / 100;
            float y = -float.Parse(points[1 + (i * 2)]) / 100;
            float z = -float.Parse(points2[0 + (i * 2)]) / 100;
            Body[i].transform.localPosition = new Vector3(x, y, z);

        }


        counter += 1;
        if (counter == lines.Count) { counter = 0; }
        Thread.Sleep(30);
    }
}