using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] int jumpHeight;

    [SerializeField] LayerMask _groundMask;

    float horizontal;

    //bool isGrounded;
    bool isFacingLeft;
    Animator animator;

    Rigidbody2D myRigidbody;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControls();
 
        animator.SetFloat("xVelocity", Math.Abs(myRigidbody.velocity.x));
        animator.SetFloat("yVelocity", myRigidbody.velocity.y);

        //Jump is not working with this, there is some problem
        //animator.SetBool("isJumping", !isGrounded());
    }

    void MoveControls() {
        horizontal = Input.GetAxis("Horizontal");
        if ((horizontal < 0 && !isFacingLeft) || (horizontal > 0 && isFacingLeft)) {
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
        RaycastHit2D leftHit = Physics2D.Raycast(player.position - Vector3.right * 0.45f, 
            Vector2.down, 0.6f, _groundMask);
        RaycastHit2D rightHit = Physics2D.Raycast(player.position + Vector3.right * 0.45f, 
            Vector2.down, 0.6f, _groundMask);
        //Debug.DrawRay(player.position + Vector3.right * 0.45f, Vector2.down * 0.6f, Color.green, 1f);
        //Debug.DrawRay(player.position - Vector3.right * 0.45f, Vector2.down * 0.6f, Color.green, 1f);
        return leftHit && rightHit;
    }

    void Turn() {
        if (isFacingLeft) {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingLeft = !isFacingLeft;
        } else {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingLeft = !isFacingLeft;
        }
    }

}
