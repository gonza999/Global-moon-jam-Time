using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public List<GameObject> hearts;
    public Animator heartAnimator;
    public Text playerName;
    private void Start()
    {
        Player.instance.life = hearts.Count();
    }
    private void Update()
    {
        CheckName();
        CheckPlayerLifes();
    }

    private void CheckName()
    {
        playerName.text = Player.instance.name;
    }

    private void CheckPlayerLifes()
    {
        if (Player.instance.life<2)
        {
            heartAnimator.SetBool("Danger",true);
        }
        else if (Player.instance.life < 2)
        {
            heartAnimator.SetBool("Danger", false);
        }
    }
    public void GetDamage()
    {
        var index = hearts.Count() - 1;
        var heartGameObject = hearts[index];
        heartGameObject.active=false;
        hearts.RemoveAt(index);
    } 
}
