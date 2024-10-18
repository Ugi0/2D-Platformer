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

    private static float playerWidth = 1f;
    private float playerHeight;

    float horizontal;

    //bool isGrounded;
    bool isFacingLeft;
    Animator animator;

    BoxCollider2D jumpCollider;

    Rigidbody2D myRigidbody;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;

        jumpCollider = GameObject.FindWithTag("Player").GetComponents<BoxCollider2D>()[0];

        animator = GetComponent<Animator>();

        playerHeight = GetComponent<SpriteRenderer>().size.y;

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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            newVel.y = jumpHeight;
        }
        myRigidbody.velocity = newVel;
    }

    bool IsGrounded() {
        RaycastHit2D leftHit = Physics2D.Raycast(jumpCollider.bounds.center - Vector3.right * playerWidth, 
            Vector2.down, 1f, _groundMask);
        RaycastHit2D rightHit = Physics2D.Raycast(jumpCollider.bounds.center + Vector3.right * playerWidth, 
            Vector2.down, 1f, _groundMask);
        //Debug.DrawRay(jumpCollider.bounds.center - Vector3.right * playerWidth, Vector2.down, Color.green, 1f);
        //Debug.DrawRay(jumpCollider.bounds.center + Vector3.right * playerWidth, Vector2.down, Color.green, 1f);
        return leftHit || rightHit;
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
