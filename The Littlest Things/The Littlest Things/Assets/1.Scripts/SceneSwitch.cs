using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject blackScreen;

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

    public void LoadCafe()
    {
        SceneManager.LoadScene(3);
    }  
    
    public void LoadEnding()
    {
        StartCoroutine(endTransition());
    }

    private IEnumerator endTransition()
    {
        if(blackScreen!= null) { blackScreen.SetActive(true);}
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(4);
    }
}
