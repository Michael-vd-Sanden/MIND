using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene(1);
    }

    public void PressQuit() 
    { 
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPicture()
    {
        SceneManager.LoadScene(2);
    }
}
