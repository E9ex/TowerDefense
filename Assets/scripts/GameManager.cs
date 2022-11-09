using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameended = false;

    // Update is called once per frame
    void Update()
    {
        if (gameended)
        {
            return;
        }
        if (PlayerStats.lives<=0)
        {
            EndGame();
        }

        void EndGame()
        {
            gameended = true;
            Debug.Log("game over.");
            
        }
    }
}
