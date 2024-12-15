using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public static HighScore instance { get; private set; }
    public TextMeshProUGUI textMesh;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this) { 
            Destroy(this); 
        } else { 
            instance = this; 
        } 
    }
    private void Start()
    {
        DisplayScore();
    }
    private void DisplayScore()
    {
        textMesh.text = "High Score: " + String.Format("{0:0.##} s",LoadScore());
    }
    public void SaveScore(float score)
	{
        string path = Application.persistentDataPath + "/score";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(score);
        writer.Close();
        DisplayScore();
    }

    public float LoadScore()
    {
        float score = 9999;
        string path = Application.persistentDataPath + "/score";
        if(File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            score = float.Parse(reader.ReadLine());
            reader.Close();
        }
        return score;
    }
}
