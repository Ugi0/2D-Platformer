using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 1f;
    private bool isMoving;
    public Vector2 direction = Vector2.left;
    private Rigidbody2D _rigidbody;
    private Vector2 velocity;
    private Animator animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        Debug.Log("Enemy became visible");
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Enemy became invisible");
        enabled = false;
    }

    private void OnEnable()
    {
        _rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.Sleep();
    }

    private void Animate()
    {
        if (isMoving == true) 
        {
            animator.SetBool("isMoving", true);
        }
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.fixedDeltaTime);
        if (velocity.x == 0)
        {
            isMoving = false;
        }
        else 
        {
            isMoving = true;
        }

        Animate();
        // Debug.Log("Moving");

        if (_rigidbody.Raycast2(direction)){
            direction = -direction;
            Debug.Log("Changed direction");

        }

        if (_rigidbody.Raycast2(Vector2.down)) {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }

}
