using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject startLimit;
    public GameObject endLimit;
    public float velocity = 1;

    private void Update()
    {
        Move();
        ChangePosition();
    }
    private void ChangePosition()
    {
        if (transform.position.x<=startLimit.transform.position.x)
        {
            transform.position= new Vector2(endLimit.transform.position.x, transform.position.y);
        }
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x-velocity,transform.position.y);
    }
}
