using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startmoney = 1000;

    public static int lives;
    public int startives = 20;

    private void Start()
    {
        money = startmoney;
        lives = startives;
    }
}
