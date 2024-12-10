using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject patrolPointA;
    public GameObject patrolPointB;
    private Rigidbody2D body;
    private Animator animator;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = patrolPointB.transform;
        flip();
        animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == patrolPointB.transform){
            body.velocity = new UnityEngine.Vector2(speed, 0);
        }
        else{
            body.velocity = new UnityEngine.Vector2(-speed, 0);
        }

        if(UnityEngine.Vector2.Distance(transform.position, currentPoint.position) < 2.5f
        && currentPoint == patrolPointB.transform)
        {
            flip();
            currentPoint = patrolPointA.transform;
        }
        if(UnityEngine.Vector2.Distance(transform.position, currentPoint.position) < 2.5f
        && currentPoint == patrolPointA.transform)
        {
            flip();
            currentPoint = patrolPointB.transform;
        }
    }
    private void flip()
    {
        UnityEngine.Vector3 localScale = transform.localScale;
        localScale.x =  localScale.x * (-1);
        transform.localScale = localScale;
    }

}
