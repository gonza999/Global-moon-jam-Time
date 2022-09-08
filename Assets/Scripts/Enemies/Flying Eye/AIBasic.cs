using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private float waitTime;
    public bool splitX = true;
    public bool isActive = true;
    public float startWaitTime = 2f;
    public static bool isDead = false;

    private int i = 0;

    private Vector2 positionActual;

    public Transform[] moveSpots;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Update()
    {
        if (isActive && !isDead)
        {
            Movement();
        }
    }

    private void Movement()
    {
        StartCoroutine(CheckEnemyMove());
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, Enemy.instance.speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMove()
    {
        positionActual = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > positionActual.x)
        {
            spriteRenderer.flipX = !splitX;
        }
        else if (transform.position.x < positionActual.x)
        {
            spriteRenderer.flipX = splitX;
        }
    }
}
