using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplySpeedBoost(other));
        }
    }

    private IEnumerator ApplySpeedBoost(Collider2D playerCollider)
    {
        Player controller = playerCollider.GetComponent<Player>();
        controller.moveSpeed *= speedMultiplier;
        gameObject.SetActive(false);

        yield return new WaitForSeconds(duration);

        controller.moveSpeed /= speedMultiplier;
        Destroy(gameObject);
    }
}