using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCheckGround : MonoBehaviour
{
    public static bool IsGrounded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
