using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            Debug.Log("Collectable collected");
            Destroy(this.gameObject);
        }
    }
}
