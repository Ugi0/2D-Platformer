using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endMenuTime;
    // Start is called before the first frame update
    void Start()
    {
        if (GameWorld.instance == null) {
            endMenuTime.text = String.Format("{0:0.##} s", 60.04);
        } else {
            GameWorld.instance.stopTimer();
            endMenuTime.text = String.Format("{0:0.##} s", GameWorld.instance.getTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
