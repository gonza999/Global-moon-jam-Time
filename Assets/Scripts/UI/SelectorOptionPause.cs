using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SelectorOptionPause : MonoBehaviour
{
    public Transform selector;
    private bool resume = true;
    private bool exit = false;
    public bool startMenu = false;
    public bool isMap = false;
    public Transform[] positions;
    public bool can = true;
    public Transform textResume;
    public Transform textExit;
    public PlayableDirector director;
    public PlayableAsset intro;
    public PlayableAsset endIntro;
    public PlayableAsset fadeOut;
    public AudioSource moveSound;
    public AudioSource selectionSound;

    public static bool castle = false;
    public static bool forest = false;
    public static bool montain = false;

    private void Start()
    {
        if (isMap)
        {
            selector.position = positions[0].position;
        }
    }
    private void Update()
    {
        if (can)
        {
            MoveSelector();
        }
        if (!isMap)
        {
            if (exit)
            {
                Quit();
            }
            if (resume)
            {
                Resume();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S) && can)
            {
                selectionSound.Play();
                director.playableAsset = fadeOut;
                can = false;
                if (selector.position==positions[0].position)
                {
                    castle = true;
                }else if (selector.position == positions[1].position)
                {
                    montain = true;
                }
                else
                {
                    forest = true;
                }
                director.Play();
            }
        }
    }

    private void MoveSelector()
    {
        if (!isMap)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveSound.Play();
                selector.position = new Vector3(selector.position.x,
                    textExit.position.y, selector.position.z);
                exit = true;
                resume = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveSound.Play();
                selector.position = new Vector3(selector.position.x,
                    textResume.position.y, selector.position.z);
                exit = false;
                resume = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveSound.Play();
                MoveInMap(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveSound.Play();
                MoveInMap(false);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveSound.Play();
                MoveInMap(true);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveSound.Play();
                MoveInMap(false);
            }
        }
    }

    private void MoveInMap(bool derecha)
    {
        if (derecha)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (selector.position == positions[i].position)
                {
                    if (i >= positions.Length - 1)
                    {
                        selector.position = positions[0].position;
                    }
                    else
                    {
                        selector.position = positions[i + 1].position;
                    }
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (selector.position == positions[i].position)
                {
                    if (i <= 0)
                    {
                        selector.position = positions[positions.Length - 1].position;
                    }
                    else
                    {
                        selector.position = positions[i - 1].position;
                    }
                    break;
                }
            }
        }
    }

    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            selectionSound.Play();
            Application.Quit();
        }
    }
    public void Resume()
    {
        if (Input.GetKeyDown(KeyCode.S) && !startMenu)
        {
            selectionSound.Play();
            Pause.instance.GetPause();
        }
        else if (Input.GetKeyDown(KeyCode.S) && startMenu)
        {
            selectionSound.Play();
            director.playableAsset = endIntro;
            director.Play();
            can = false;
        }
    }

    public void Can()
    {
        this.can = !can;
    }
}
