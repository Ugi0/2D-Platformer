using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class SceneSwitch : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player")) {
            SceneManager.LoadScene(2);
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlaySFX("Levelcomplete");

        }
    }
}
