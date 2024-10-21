using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
    public NPCConversation startingConvo;

    private void Start()
    {
        ConversationManager.Instance.StartConversation(startingConvo); 
    }

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
