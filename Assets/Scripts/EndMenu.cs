using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    private static int STAR3LIMIT = 45;
    private static int STAR2LIMIT = 60;
    private static int STAR1LIMIT = 75;
    [SerializeField] TextMeshProUGUI endMenuTime;
    [SerializeField] GameObject starContainer;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.StopLoopingSFX();
        if (GameWorld.instance == null) {
            endMenuTime.text = String.Format("{0:0.##} s", 60.04);
        } else {
            GameWorld.instance.stopTimer();
            endMenuTime.text = String.Format("{0:0.##} s", GameWorld.instance.getTime());
            starContainer.transform.GetChild(0).gameObject.GetComponent<CanvasRenderer>().cull = true;
            starContainer.transform.GetChild(1).gameObject.GetComponent<CanvasRenderer>().cull = true;
            starContainer.transform.GetChild(2).gameObject.GetComponent<CanvasRenderer>().cull = true;
            if (GameWorld.instance.getTime() < STAR1LIMIT) {
                starContainer.transform.GetChild(0).gameObject.GetComponent<CanvasRenderer>().cull = false;
            }
            if (GameWorld.instance.getTime() < STAR2LIMIT) {
                starContainer.transform.GetChild(1).gameObject.GetComponent<CanvasRenderer>().cull = false;
            }
            if (GameWorld.instance.getTime() < STAR3LIMIT) {
                starContainer.transform.GetChild(2).gameObject.GetComponent<CanvasRenderer>().cull = false;
            }
            if(GameWorld.instance.getTime()<HighScore.instance.LoadScore())
            {
                HighScore.instance.SaveScore(GameWorld.instance.getTime());
            }
        }
    }
}
