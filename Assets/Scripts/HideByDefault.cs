using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideByDefault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

}
