using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public string name = "";
    public float life = 3;
    public bool inmunibility = false;
    public float speedWalk = 2;
    public float speedRun = 2;
    public float speedFast = 2;
    public float forceJump = 5;
    public float forceSlide = 5;
    public float attack = 1;
    public float timeToWaitInmunibility=2;
    private float timeToInmunibility=0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        Inmunibility();
    }

    private void Inmunibility()
    {
        if (inmunibility)
        {
            timeToInmunibility += Time.deltaTime;
        }
        if (timeToInmunibility>=timeToWaitInmunibility)
        {
            inmunibility = false;
        }
    }
}
