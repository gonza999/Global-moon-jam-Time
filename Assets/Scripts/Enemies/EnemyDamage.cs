using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Blink blink;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            animator.SetBool("Hit",true);
            Hit();
            StartCoroutine(Damager());
        }
    }

    public void Hit()
    {
        Enemy.instance.life -= Player.instance.attack;
        animator.gameObject.tag = "Invisible";
        animator.GetComponent<BoxCollider2D>().isTrigger = true;
        IsDead();
    }
    private void IsDead()
    {
        if (Enemy.instance.life <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        animator.SetBool("Dead", true);
    }
    IEnumerator Damager()
    {
        spriteRenderer.material = blink.blink;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.material = blink.original;
    }
}
