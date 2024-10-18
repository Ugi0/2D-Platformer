using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class SceneSwitch : MonoBehaviour
{
    [SerializeField] Object scene;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene(scene.name);
        Debug.Log("OnCollisionEnter2D");
    }
}
