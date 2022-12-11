using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject ui;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            Toggle();//akfif oldugunda oyunun zamanın durduruyor olmadıgında da akmasını saglıyor oyunun.
            
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menu()//bunlara animator eklersek update modenu unscaled time  seçmemiz gerekiyor esc her bastıgımızda aynı zaman animasyon da duruyor ve animasyon çalışmıyor.
    {
        Debug.Log("go to menu");
    }
}
