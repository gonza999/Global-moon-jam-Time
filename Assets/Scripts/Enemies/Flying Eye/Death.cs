using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public BoxCollider2D boxCollider2D;
    public Animator animator;
    public float speedDeath = 3;
    private bool dead = false;
    public void Dead()
    {
        dead = true;
        boxCollider2D.isTrigger = true;
    }

    private void Update()
    {
        if (dead)
        {
            rigidbody2D.velocity = Vector2.down * speedDeath;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            boxCollider2D.enabled = false;
            animator.SetBool("Finish", true);
            rigidbody2D.velocity = Vector2.zero;
            dead = false;
            Invoke("Destroy",1f);
        }
    }

    public void Destroy()
    {
        gameObject.GetComponentInParent<DestroyObject>().Destroy();
    }
}
