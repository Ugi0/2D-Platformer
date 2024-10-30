using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TextMeshPro endMenuTime;
    // Start is called before the first frame update
    void Start()
    {
        GameWorld.instance.stopTimer();
        endMenuTime.text = String.Format("{0}s", GameWorld.instance.getTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
