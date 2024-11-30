using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandling : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        GameWorld.dead = false;
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        GameWorld.dead = false;
    }
}
