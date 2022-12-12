using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoload = "mainscene";
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(leveltoload);
    }

    public void Quit()
    {
        Debug.Log("exciting");
        Application.Quit();

    }
}
