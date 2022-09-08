using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2;

    public Animator animator;
    private Vector2 positionToAttack;
    private float x;
    private float y;
    
    private void Start()
    {
        x = Attacks.playerPosToAttack.position.x;
        y = Attacks.playerPosToAttack.position.y;
        positionToAttack = new Vector2(x,y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positionToAttack, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, positionToAttack) < 0.1f)
        {
            animator.SetBool("Hit",true);
            Destroy(gameObject, 0.3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Hit", true);
            Destroy(gameObject, 0.3f);
        }
    }

}
