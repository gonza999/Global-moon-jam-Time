using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    public float speed;
    private bool changeSpeed = false;
    
    private void Update()
    {
        if (changeSpeed)
        {
            if (speed>500)
            {
                speed = speed;
            }
            else
            {
                speed+=Time.deltaTime*speed;
            }
        }
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
    }
    public void ChangeSpeed(float moreSpeed)
    {
        //speed += moreSpeed;
        changeSpeed = true;
    }
}
