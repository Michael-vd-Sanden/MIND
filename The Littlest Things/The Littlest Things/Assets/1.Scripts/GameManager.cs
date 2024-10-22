using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    public NPCConversation startingConvo;
    public TMP_Text objectiveText;
    public GameObject objectiveObject;

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

    public void setObjective(bool set)
    {
        objectiveObject.SetActive(set);
    }

    public void ChangeObjective(string objective)
    {
        objectiveText.text = objective;
    }
}
