using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameended = false;
    public GameObject gameoveru─▒;


    private void Start()
    {
        gameended = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameended)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.lives<=0)
        {
            EndGame();
        }

        void EndGame()
        {
            gameended = true;
            Debug.Log("game over.");
            gameoveru─▒.SetActive(true);
            
        }
    }
}
