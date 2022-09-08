using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public float gravityFall=2;
    private float gravityDefault = 1;
    private bool isDead = false;
    private void Start()
    {
        gravityDefault = rigidbody2D.gravityScale;
    }
    private void FixedUpdate()
    {
        if (!isDead)
        {
            animator.SetBool("Idle", PlayerMovement.idle);
            animator.SetBool("Walk", PlayerMovement.walk);
            animator.SetBool("Run", PlayerMovement.run);
            animator.SetBool("Jump", PlayerMovement.jump);
            animator.SetBool("Fall", PlayerMovement.fall);
            animator.SetBool("Fast", PlayerMovement.fast);
            animator.SetBool("Crounch", PlayerMovement.crounch);
            animator.SetBool("Slide", PlayerMovement.slide);
            animator.SetBool("Damage", Damage.damage);
            animator.SetBool("Death", Damage.death);
            animator.SetBool("Punch1", PlayerAttack.punch1);
            animator.SetBool("Punch2", PlayerAttack.punch2);
            animator.SetBool("Punch3", PlayerAttack.punch3);
            animator.SetBool("Kick1", PlayerAttack.kick1);
            animator.SetBool("Kick2", PlayerAttack.kick2);
            animator.SetBool("DropKick", PlayerAttack.dropKick);
            animator.SetBool("DropKick2", PlayerAttack.dropKick2);
            DropKick();
            Dead(); 
        }
    }

    private void DropKick()
    {
        if (PlayerAttack.dropKick2)
        {
            rigidbody2D.gravityScale = gravityFall;
            if (rigidbody2D.velocity.x<0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x-gravityFall,rigidbody2D.velocity.y);
            }
            else if (rigidbody2D.velocity.x > 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x+ gravityFall, rigidbody2D.velocity.y);
            }
        }
        else
        {
            rigidbody2D.gravityScale = gravityDefault;
        }
    }

    private void Dead()
    {
        if (Damage.death)
        {
            isDead = true;
            animator.GetComponent<PlayerMovement>().enabled = false;
            animator.GetComponent<PlayerAttack>().enabled = false;
            animator.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Invoke("GameOver",1f);
        }
    }

    private void GameOver()
    {
        gameObject.GetComponentInParent<DestroyObject>().Destroy();
    }
}
