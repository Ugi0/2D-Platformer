using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameWorld instance { get; private set; }

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject deathMenu;
    public static bool isPaused;

    private static float startTime;
    private static float endTime;
    public static float extraTime;
    public static bool dead = false;

    private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (instance != null && instance != this) { 
        Destroy(this); 
    } else { 
        instance = this; 
    } 
}
    void Start()
    {
        isPaused = false;
        extraTime = 0;
        startTime = Time.time;

        //AudioManager.Instance.PlaySFX("Collectable");
        AudioManager.Instance.PlayMusic("Theme");
    }

    public float getTime() {
        return endTime - startTime - extraTime;
    }

    public void stopTimer() {
        endTime = Time.time;
    }

    public void Death() {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
        dead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (dead) return;
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
