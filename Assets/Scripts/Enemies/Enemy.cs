using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public float life = 2;
    public float speed;
    public float attack = 1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
