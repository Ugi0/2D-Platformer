using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public static PickUpManager Instance;
    public GameObject hudContainer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ActivatePickUp(PickUp pickUp, Player player)
    {
        pickUp.Activate(player, hudContainer);
    }
}