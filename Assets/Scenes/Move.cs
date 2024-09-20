using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpHeight;

    float horizontal;

    bool isGrounded;

    Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    void MoveObject() {
        horizontal = Input.GetAxis("Horizontal");
        myRigidbody.velocity = new Vector2(moveSpeed * horizontal, 0);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            myRigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag ("Ground")) {
            Debug.Log("Grounded");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D hit)
    {
            isGrounded = false;
    }
}
