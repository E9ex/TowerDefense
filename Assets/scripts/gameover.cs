using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public TextMeshProUGUI roundstext;

    private void OnEnable()
    {
        roundstext.text = PlayerStats.rounds.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Debug.Log("go to men");
    }
}
