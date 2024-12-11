using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectFall : MonoBehaviour
{
    public float gravityScale = 10;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider2D;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = gravityScale;
        }
        if(col.collider.CompareTag("Death Barrier"))
        {
            _boxCollider2D.enabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            _boxCollider2D.enabled = false;
        }
    }
}
