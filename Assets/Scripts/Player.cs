using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpHeight;
    [SerializeField] public float climbSpeed;

    [SerializeField] LayerMask _platformMask;
    [SerializeField] LayerMask _ladderMask;

    [SerializeField] LayerMask _enemiesMask;
    private static float playerWidth = 1.5f;
    private static int RaycastNumber = 5;
    private static float rayCastLength = 1f;

    private static int defaultHealth = 3;
    public int playerHealth;
    float horizontal;
    bool isFacingLeft;
    Animator animator;

    bool isClimbing;
    bool isJumping;
    bool isGrounded;

    BoxCollider2D jumpCollider;

    Rigidbody2D myRigidbody;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = defaultHealth;
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
            Animate();
        }
    }

    void MoveControls() {
        horizontal = Input.GetAxis("Horizontal");
        if ((horizontal < 0 && !isFacingLeft) || (horizontal > 0 && isFacingLeft)) {
            Turn();
        }
        Vector2 newVel = myRigidbody.velocity;
        Vector2 newPos = myRigidbody.position;
        newVel.x = moveSpeed * horizontal;
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            newVel.y = jumpHeight;
            isJumping = true;
            isGrounded = false;
            isClimbing = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && IsOnALadder()) {
            newVel.y = climbSpeed;
            isClimbing = true;
            isGrounded = false;
            isJumping = false;
        }
        myRigidbody.velocity = newVel;
        myRigidbody.position = newPos;
    }

    bool IsOnALadder() {
        for (int i = 0; i < RaycastNumber; i++) {
            //Debug.DrawRay(jumpCollider.bounds.center + Vector3.right * (playerWidth/RaycastNumber) * (2 * i - RaycastNumber + 1), Vector2.down * rayCastLength, Color.green, 1f);
            if (Physics2D.Raycast(jumpCollider.bounds.center + Vector3.right * (playerWidth / RaycastNumber) * (2 * i - RaycastNumber + 1),
            Vector2.down, rayCastLength, _ladderMask)) {
                return true;
            }
        }
        return false;
    }

    bool IsGrounded() {
        for (int i = 0; i < RaycastNumber; i++) {
            //Debug.DrawRay(jumpCollider.bounds.center + Vector3.right * (playerWidth/RaycastNumber) * (2 * i - RaycastNumber + 1), Vector2.down * rayCastLength, Color.green, 1f);
            if (Physics2D.Raycast(jumpCollider.bounds.center + Vector3.right * (playerWidth / RaycastNumber) * (2 * i - RaycastNumber + 1),
            Vector2.down, rayCastLength, _platformMask)) {
                return true;
            }
        }
        return false;
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

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision == null) return;
        if ((_enemiesMask.value & (1 << collision.gameObject.layer)) != 0) {
            if (collision.gameObject.tag.Equals("Death Barrier")) {
                playerHealth = 0;
            } else {
                playerHealth -= 1;
            }
            if (playerHealth <= 0) {
                GameWorld.instance.Reset();
                playerHealth = defaultHealth;
            }
        }
    }

    void Animate() {
        animator.SetFloat("xVelocity", Math.Abs(myRigidbody.velocity.x));
        float yVel = myRigidbody.velocity.y;
        animator.SetFloat("yVelocity", yVel);
        
        isGrounded = IsGrounded();
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded == true){
            animator.SetBool("isJumping", false);
            animator.SetBool("isClimbing", false);
        }
        else{
            if (isJumping == true) {
                animator.SetBool("isJumping", true);
                animator.SetBool("isClimbing", false);
            }
            else if (yVel < 0) {
                animator.SetBool("isJumping", true);
                animator.SetBool("isClimbing", false);
            }
            else if (isClimbing == true && yVel > 0){
                animator.SetBool("isClimbing", true);
                animator.SetBool("isJumping", false);
            }
        }
    }

}
