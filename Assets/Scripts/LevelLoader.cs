using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool LoadOnStart;
    public Animator transition;
    public GameObject fade;
    public float transitionTime = 1f;

    private void Start()
    {
        if(!LoadOnStart)
        {
            fade.SetActive(false);
        }
        else
        {
            fade.SetActive(true);
        }
    }

    public void Load()
    {
        fade.SetActive(true);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(transitionTime);

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
