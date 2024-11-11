using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    public GameObject hudContainer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ActivatePowerUp(PowerUp powerUp, Player player)
    {
        powerUp.Activate(player, hudContainer);
    }
}