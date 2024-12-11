using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public int maxY;
    public int minY;
    private Vector2 velocity;
    public Vector2 direction = Vector2.up;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    public float speed = 1f;
    // Start is called before the first frame update

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        enabled = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            enabled = true;
        }
    }

    void FixedUpdate()
    {
        if(_transform.localPosition.y >= maxY || _transform.localPosition.y <= minY)
        {
            direction = -direction;
        }
        velocity.x = direction.x * speed;
        velocity.y = direction.y * speed;
        _rigidbody.MovePosition(_rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
