using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    public BoxCollider2D normalCollider;
    public BoxCollider2D crounchCollider;
    public CircleCollider2D attackColliderRight;
    public CircleCollider2D attackColliderLeft;
    public CircleCollider2D dropKickColliderLeft;
    public CircleCollider2D dropKickColliderRight;
    public SpriteRenderer playerSpriteRenderer;
    public static bool isCrounch = false;
    private void Update()
    {
        if (isCrounch)
        {
            crounchCollider.enabled = true;
            normalCollider.enabled = false;
        }
        else
        {
            crounchCollider.enabled = false;
            normalCollider.enabled = true;
        }
    }

    public void EnabledAttackCollider()
    {
        if (playerSpriteRenderer.flipX)
        {
            attackColliderLeft.enabled = true;
        }
        else
        {
            attackColliderRight.enabled = true;
        }
    }
    public void EnabledDropKickCollider()
    {
        if (playerSpriteRenderer.flipX)
        {
            dropKickColliderLeft.enabled = true;
        }
        else
        {
            dropKickColliderRight.enabled = true;
        }
    }
    public void DisabledAttackCollider()
    {
        attackColliderRight.enabled = false;
        attackColliderLeft.enabled = false;
        dropKickColliderRight.enabled = false;
        dropKickColliderLeft.enabled = false;
    }
}
