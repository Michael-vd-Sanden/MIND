using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> notebookPages = new List<GameObject>();

    public void changePage(int page)
    {
        foreach (GameObject g in notebookPages) 
        { 
            g.SetActive(false);
        }

        notebookPages[page].SetActive(true);
    }
}
