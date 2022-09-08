using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Animator playerHudAnimator;
    public GameObject menuOptions;
    public Animator menuOptionsAnimator;
    public bool isPause = false;
    public bool active = true;
    private GameObject[] gamesObjects;

    public static Pause instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gamesObjects = GameObject.FindGameObjectsWithTag("CanStop");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GetPause();
        }
        Pausing();
    }

    private void Pausing()
    {
        if (isPause)
        {
            playerHudAnimator.enabled = true;
            menuOptions.SetActive(true);
            playerHudAnimator.SetBool("Enter", true);
            menuOptionsAnimator.SetBool("Enter", true);
        }
        else
        {
            playerHudAnimator.SetBool("Enter", false);
            menuOptionsAnimator.SetBool("Enter", false);
        }
    }

    public void GetPause()
    {

        StopAll();
        if (isPause)
        {
            isPause = false;
        }
        else
        {
            isPause = true;

        }

    }

    public void StopAll()
    {
        active = !active;
        foreach (var go in gamesObjects)
        {
            if (go != null)
            {
                go.SetActive(active);
            }
        }
    }
}
