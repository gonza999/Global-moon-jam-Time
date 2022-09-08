using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public Transform playerPosition;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject projectile;
    public Transform spawnPointRight;
    public Transform spawnPointLeft;
    private Vector2 positionToAttack;
    private float x;
    private float y;
    public static Transform playerPosToAttack;
    public void SetAttack(SelectAttack selectAttack)
    {
        playerPosition = GameObject.Find("Player").transform;
        playerPosToAttack = playerPosition;
        playerPosToAttack.position = playerPosition.position;
        gameObject.GetComponent<AIBasic>().enabled = false;
        Flip();
        switch (selectAttack)
        {
            case SelectAttack.Attack2:
                Attack2();
                break;
            case SelectAttack.Attack3:
                Attack3();
                break;
            default:
                break;
        }
    }

    private void Attack3()
    {
        animator.SetBool("Attack3",true);
        StartCoroutine(BackToNormal());
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attack3", false);
        animator.SetBool("Attack2", false);
        gameObject.GetComponent<AIBasic>().enabled = true;
    }
    public void InstanciateProjetile()
    {
        if (spriteRenderer.flipX)
        {
             Instantiate(projectile,spawnPointLeft.position,spawnPointLeft.rotation);
        }
        else
        {
            Instantiate(projectile, spawnPointRight.position, spawnPointRight.rotation);
        }
    }

    private void Flip()
    {
        if (playerPosition.localPosition.x < transform.localPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerPosition.localPosition.x > transform.localPosition.x)
        {
            spriteRenderer.flipX = false;

        }
    }

    private void Attack2()
    {
        animator.SetBool("Attack2", true);
        x = playerPosToAttack.position.x;
        y = playerPosToAttack.position.y;
        positionToAttack = new Vector2(x, y);
    }

    private void Update()
    {
        if (animator.GetBool("Attack2"))
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToAttack, (Enemy.instance.speed*3) * Time.deltaTime);
            if (Vector2.Distance(transform.position, positionToAttack) < 0.1f)
            {
                StartCoroutine(BackToNormal());
            }
        }
    }
}
