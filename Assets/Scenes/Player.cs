using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpHeight;

    float horizontal;

    bool isGrounded;
    bool isFacingRight;

    Rigidbody2D myRigidbody;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControls();
    }

    void MoveControls() {
        horizontal = Input.GetAxis("Horizontal");
        if ((horizontal < 0 && isFacingRight) || (horizontal > 0 && !isFacingRight)) {
            Turn();
        }
        Vector2 newVel = myRigidbody.velocity;
        newVel.x = moveSpeed * horizontal;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            newVel.y = jumpHeight;
        }
        myRigidbody.velocity = newVel;
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

    void Turn() {
        if (isFacingRight) {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        } else {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }

}
