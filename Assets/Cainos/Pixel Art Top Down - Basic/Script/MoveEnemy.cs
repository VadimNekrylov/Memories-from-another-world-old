using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    Vector2 startPos;
    public float distanceRage;
    private float distance;
    void Start()
    {
        startPos = transform.position;
    }
   
    void Update()
    {
        if (player == null) return;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(distance<distanceRage)
        {
            if (transform.position.x < player.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }

        }
        if(distance > distanceRage || System.Math.Abs(startPos.x - transform.position.x) > 8 || System.Math.Abs(startPos.y - transform.position.y) > 8)
        {
                if (transform.position.x < startPos.x)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.position = Vector2.MoveTowards(this.transform.position, startPos, speed * Time.deltaTime);


                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.position = Vector2.MoveTowards(this.transform.position, startPos, speed * Time.deltaTime);
                }
        }
    }
}
