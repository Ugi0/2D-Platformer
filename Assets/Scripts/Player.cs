using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpHeight;

    [SerializeField] LayerMask _groundMask;

    private static float playerWidth = 10f;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameWorld.isPaused) {
            MoveControls();
        }
 
        animator.SetFloat("xVelocity", Math.Abs(myRigidbody.velocity.x));
        animator.SetFloat("yVelocity", myRigidbody.velocity.y);
        animator.SetBool("isJumping", !IsGrounded());
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
            Vector2.down, 10f, _groundMask);
        RaycastHit2D rightHit = Physics2D.Raycast(jumpCollider.bounds.center + Vector3.right * playerWidth, 
            Vector2.down, 10f, _groundMask);
        //Debug.DrawRay(jumpCollider.bounds.center + Vector3.right * playerWidth, Vector2.down * 10f, Color.green, 1f);
        //Debug.DrawRay(jumpCollider.bounds.center - Vector3.right * playerWidth, Vector2.down * 10f, Color.green, 1f);
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
