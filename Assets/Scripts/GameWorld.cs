using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject pauseMenu;
    public static bool isPaused;
    void Start()
    {
        isPaused = false;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            } else {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

}
