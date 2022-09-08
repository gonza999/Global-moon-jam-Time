using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float knockForceX = 2;
    public float knockForceY = 2;
    public Rigidbody2D rigidbody2D;
    public Blink blink;
    public SpriteRenderer spriteRenderer;
    public static bool damage;
    public static bool death;
    public CircleCollider2D attackCollider;
    public PlayerUI playerUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !Player.instance.inmunibility)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.left*knockForceX, ForceMode2D.Force);
            rigidbody2D.AddForce(Vector2.up*knockForceY, ForceMode2D.Force);
            damage = true;
            PlayerMovement.idle = true;
            StartCoroutine(Damager());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && !Player.instance.inmunibility)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.left * knockForceX, ForceMode2D.Force);
            rigidbody2D.AddForce(Vector2.up * knockForceY, ForceMode2D.Force);
            damage = true;
            PlayerMovement.idle = true;
            StartCoroutine(Damager());
        }
    }

    IEnumerator Damager()
    {
        Player.instance.life--;
        playerUI.GetDamage();
        attackCollider.enabled = false;
        spriteRenderer.material = blink.blink;
        IsDead();
        Player.instance.inmunibility = true;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.material = blink.original;
    }

    private void IsDead()
    {
        if (Player.instance.life<=0)
        {
            death = true;
        }
    }
}
