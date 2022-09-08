using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public static bool idle = false;
    public static bool walk = false;
    public static bool run = false;
    public static bool fast = false;
    public static bool jump = false;
    public static bool fall = false;
    public static bool crounch = false;
    public static bool slide = false;
    private void Update()
    {
        if (!idle)
        {
            Walk();
            Jump();
        }
        Slide();
        Fall();
    }

    private void Fall()
    {
        if (rigidbody2D.velocity.y<0 && !IsCheckGround.IsGrounded)
        {
            fall = true;
        }
        else if (IsCheckGround.IsGrounded)
        {
            fall = false;
        }
    }

    private void Slide()
    {
        if (Input.GetKey(KeyCode.A) && IsCheckGround.IsGrounded &&
            crounch && rigidbody2D.velocity == Vector2.zero)
        {
            if (!slide)
            {
                idle = true;
            }
            slide = true;
            if (!spriteRenderer.flipX)
            {
                rigidbody2D.velocity = Vector2.right * Player.instance.forceSlide;
            }
            else
            {
                rigidbody2D.velocity = Vector2.left * Player.instance.forceSlide;
            }
        }
        if ((Input.GetKeyUp(KeyCode.A) && slide))
        {
            slide = false;
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void CrounchAnimation()
    {
        if (Input.GetKey(KeyCode.DownArrow) && IsCheckGround.IsGrounded)
        {
            crounch = true;
        }
        else
        {
            crounch = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsCheckGround.IsGrounded)
        {
            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Player.instance.forceJump);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Player.instance.forceJump + Math.Abs(rigidbody2D.velocity.x / 2));
        }
    }
    private void FixedUpdate()
    {
        if (!idle)
        {
            WalkAnimation();
            RunAnimation();
            FastAnimation();
            JumpAnimation();
            FallAnimation();
            Flip();
            CrounchAnimation();
        }
    }
    private void FastAnimation()
    {
        if (Input.GetKey(KeyCode.RightShift) &&
            rigidbody2D.velocity.x != 0 && IsCheckGround.IsGrounded)
        {
            fast = true;
        }
        else
        {
            fast = false;
        }
    }

    private void Flip()
    {
        if (rigidbody2D.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rigidbody2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FallAnimation()
    {
        if (IsCheckGround.IsGrounded)
        {
            fall = false;
        }
    }

    private void JumpAnimation()
    {
        if (rigidbody2D.velocity.y > 0 && !IsCheckGround.IsGrounded)
        {
            jump = true;
        }
        else if (rigidbody2D.velocity.y < 0 && !IsCheckGround.IsGrounded)
        {
            jump = false;
            fall = true;
        }
    }

    private void RunAnimation()
    {
        if (Input.GetKey(KeyCode.LeftShift) && rigidbody2D.velocity.x != 0 && IsCheckGround.IsGrounded)
        {
            run = true;
        }
        else
        {
            run = false;
        }
    }

    private void WalkAnimation()
    {
        if (rigidbody2D.velocity.x != 0 && IsCheckGround.IsGrounded)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
    }
    private void Walk()
    {
        var speedX = Input.GetAxisRaw("Horizontal");
        var speedY = rigidbody2D.velocity.y;
        if (fast && !crounch)
        {
            rigidbody2D.velocity = new Vector2(speedX * Player.instance.speedFast, speedY);
        }
        else if (run && !crounch)
        {
            rigidbody2D.velocity = new Vector2(speedX * Player.instance.speedRun, speedY);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(speedX * Player.instance.speedWalk, speedY);
        }
    }
}
