using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static bool punch1 = false;
    public static bool punch2 = false;
    public static bool punch3 = false;
    public static bool kick1 = false;
    public static bool kick2 = false;
    public static bool dropKick = false;
    public static bool dropKick2 = false;
    public static bool isAttacking = false;
    public Rigidbody2D rigidbody2D;
    public ChangeCollider changeCollider;
    private void Update()
    {
        Punchs();
        Kicks();
    }

    private void Kicks()
    {
        if (IsCheckGround.IsGrounded)
        {
            dropKick = false;
            dropKick2 = false;
            changeCollider.DisabledAttackCollider();
        }
        if (IsCheckGround.IsGrounded && Input.GetKeyDown(KeyCode.D))
        {
            if (!isAttacking)
            {
                Kick1();
            }
            else
            {
                if (!kick2)
                {
                    Kick2();
                }
            }
        }
        if (!IsCheckGround.IsGrounded && Input.GetKeyDown(KeyCode.D))
        {
            if (!isAttacking)
            {
                DropKick();
            }
        }
    }

    private void DropKick()
    {
        dropKick = true;
        dropKick2 = true;
        rigidbody2D.velocity = Vector2.zero;
        kick1 = true;
        isAttacking = true;
    }

    private void Kick2()
    {
        kick2 = true;
        PlayerMovement.idle = true;
        rigidbody2D.velocity = Vector2.zero;
    }

    private void Kick1()
    {
        PlayerMovement.idle = true;
        rigidbody2D.velocity = Vector2.zero;
        kick1 = true;
        isAttacking = true;
    }

    private void Punchs()
    {
        if (IsCheckGround.IsGrounded && Input.GetKeyDown(KeyCode.S))
        {
            if (!isAttacking)
            {
                Punch1();
            }
            else
            {
                if (punch2)
                {
                    Punch3();
                }
                if (!punch2 && !punch3)
                {
                    Punch2();
                }

            }
        }
    }

    private void Punch1()
    {
        PlayerMovement.idle = true;
        rigidbody2D.velocity = Vector2.zero;
        punch1 = true;
        isAttacking = true;
    }

    private void Punch2()
    {
        punch2 = true;
        PlayerMovement.idle = true;
        rigidbody2D.velocity = Vector2.zero;
    }
    private void Punch3()
    {
        punch3 = true;
        PlayerMovement.idle = true;
        rigidbody2D.velocity = Vector2.zero;
    }

}
