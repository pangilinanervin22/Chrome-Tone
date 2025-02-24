using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 4f;

    private bool movingToA = true;

    private void Update()
    {
        if (movingToA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToA = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToA = true;
            }
        }
    }
}
