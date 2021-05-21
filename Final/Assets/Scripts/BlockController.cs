using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject rightBorder;
    public GameObject leftBorder;
    public float moveSpeed;
    public float floatSpeed;

    float step;
    Vector3 target;
    bool moving = false;
    bool floating = false;

    void Update()
    {
        step = floatSpeed * Time.deltaTime;
        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else if(floating)
        {

            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        if(Vector3.Distance(transform.position, target) < 0.001f)
        {
            moving = false;
            floating = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "RedBullet")
        {
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "BlueBullet")
        {
            if (col.gameObject.transform.position.x < leftBorder.transform.position.x)
            {
                target = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);
            }
            else if (col.gameObject.transform.position.x > rightBorder.transform.position.x)
            {
                target = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
            }
            moving = true;
        }
        else if(col.gameObject.tag == "YellowBullet")
        {
            target = transform.position + (Vector3.up * moveSpeed * Time.deltaTime);
            floating = true;
        }
    }
}
