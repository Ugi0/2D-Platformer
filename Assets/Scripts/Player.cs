using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpHeight;

    [SerializeField] LayerMask _groundMask;

    float horizontal;

    //bool isGrounded;
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
        if (!GameWorld.isPaused) {
            MoveControls();
        }
    }

    void MoveControls() {
        horizontal = Input.GetAxis("Horizontal");
        if ((horizontal < 0 && isFacingRight) || (horizontal > 0 && !isFacingRight)) {
            Turn();
        }
        Vector2 newVel = myRigidbody.velocity;
        newVel.x = moveSpeed * horizontal;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            newVel.y = jumpHeight;
        }
        myRigidbody.velocity = newVel;
    }

    bool isGrounded() {
        RaycastHit2D leftHit = Physics2D.Raycast(player.position - Vector3.right * 30f, 
            Vector2.down, 10f, _groundMask);
        RaycastHit2D rightHit = Physics2D.Raycast(player.position + Vector3.right * 5f, 
            Vector2.down, 10f, _groundMask);
        Debug.DrawRay(player.position + Vector3.right * 5f, Vector2.down * 10f, Color.green, 1f);
        Debug.DrawRay(player.position - Vector3.right * 5f, Vector2.down * 10f, Color.green, 1f);
        return leftHit && rightHit;
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
