using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    private float responseTime;

    public float startResponseTime;

    public Transform[] patrolPoints;

    private int randomPoint;

    private bool looksLeft = true;

    void Start()
    {
        randomPoint = Random.Range(0, patrolPoints.Length);
        responseTime = startResponseTime;
    }


    void Update()
    {
        if (transform.position.x < patrolPoints[randomPoint].position.x && looksLeft)
        {
            looksLeft = !looksLeft;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (transform.position.x > patrolPoints[randomPoint].position.x && !looksLeft)
        {
            looksLeft = !looksLeft;
            transform.Rotate(0f, 180f, 0f);
        }
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f)
        {
            if (responseTime <= 0)
            {
                randomPoint = Random.Range(0, patrolPoints.Length);

                responseTime = startResponseTime;
            }
            else 
            {
                responseTime -= Time.deltaTime; 
            }

        }
    
    }
}
