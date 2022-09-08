using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectAttack
{
    Attack2,
    Attack3
}
public class RadioZone : MonoBehaviour
{
    public SelectAttack selectAttack;
    public Attacks attacks;
    public static bool active = true;
    public float waitTime = 2;
    private float time = 0;
    public bool isActive = true;
    public Transform enemyPosition;
    private void Update()
    {
        transform.position = enemyPosition.position;
        if (isActive && !AIBasic.isDead)
        {
            TimeToWaitToAttack();
        }
    }

    private void TimeToWaitToAttack()
    {
        if (!active)
        {
            time += Time.deltaTime;
        }
        if (time >= waitTime)
        {
            time = 0;
            active = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && active)
        {
            active = false;
            attacks.SetAttack(selectAttack);
        }
    }
}
