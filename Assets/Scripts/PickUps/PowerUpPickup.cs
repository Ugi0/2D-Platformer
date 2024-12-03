using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public PickUp powerUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpManager.Instance.ActivatePickUp(powerUp, other.GetComponent<Player>());
            Destroy(gameObject);
        }
    }
}