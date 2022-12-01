using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startmoney = 1000;

    public static int lives;
    public int startlives = 20;
    public  static int rounds;

    private void Start()
    {
        money = startmoney;
        lives = startlives;
        rounds = 0;
    }
}
