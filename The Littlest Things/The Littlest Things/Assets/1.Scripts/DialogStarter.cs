using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Unity.VisualScripting;

public class DialogStarter : MonoBehaviour
{
    public PlayerMovement2D player;
    public TriggerBtn trigger;

    public NPCConversation[] convoListRound1;
    private int convoNmbrRound1 = 0;
    public NPCConversation[] convoListRound2;
    private int convoNmbrRound2 = 0;

    public bool isRound2 = false;
    public bool isLooping = false;

    public GameObject[] triggerBtns;
    private GameObject triggerCanvas;

    public void changeRounds()
    {
        isRound2 = true;
        if (convoListRound2.Length > 0)
        {
            trigger.hasConversation = true;
        }
        else
        {
            trigger.hasConversation = false;
        }
    }

    private void Update()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {
            player.enabled = false;
            foreach (GameObject t in triggerBtns)
            {
                triggerCanvas = t.transform.GetChild(0).gameObject;
                triggerCanvas.SetActive(false);
            }
        }
        else
        {
            player.enabled = true;
            foreach (GameObject t in triggerBtns)
            {
                triggerCanvas = t.transform.GetChild(0).gameObject;
                triggerCanvas.SetActive(true);
            }
        }
    }

    public void Talk()
    {
        if(!isRound2)
        {
            TalkRound1();
        }
        else
        {
            TalkRound2();
        }
    }

    public void TalkRound1()
    {
        ConversationManager.Instance.StartConversation(convoListRound1[convoNmbrRound1]);
        if ((convoListRound1.Length - 1) > convoNmbrRound1)
        {
            convoNmbrRound1++;
        }
        else
        {
            if (isLooping)
            {
                convoNmbrRound1 = 0;
            }
            else
            {
                trigger.hasConversation = false;
            }
        }
    }

    public void TalkRound2()
    {
        ConversationManager.Instance.StartConversation(convoListRound2[convoNmbrRound2]);
        if ((convoListRound2.Length - 1) > convoNmbrRound2)
        {
            convoNmbrRound2++;
        }
        else
        {
            if (isLooping)
            {
                convoNmbrRound2 = 0;
            }
            else
            { 
                 trigger.hasConversation = false;
            }
        }
    }

}
