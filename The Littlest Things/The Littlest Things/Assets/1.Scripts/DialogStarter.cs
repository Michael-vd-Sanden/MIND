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
    public NPCConversation[] convoListRound3;
    private int convoNmbrRound3 = 0;

    public int isRound = 1;
    public bool isLooping = false;

    public GameObject[] triggerBtns;
    private GameObject triggerCanvas;

    public void changeRounds(int round)
    {
        isRound = round;
        switch (isRound)
        {
            case 1:
                if (convoListRound1.Length > 0)
                { trigger.hasConversation = true; }
                else
                { trigger.hasConversation = false; }
                break;
            case 2:
                if (convoListRound2.Length > 0)
                { trigger.hasConversation = true; }
                else
                { trigger.hasConversation = false; }
                break;
            case 3:
                if (convoListRound3.Length > 0)
                { trigger.hasConversation = true; }
                else
                { trigger.hasConversation = false; }
                break;
        }    
        
    }

    public void changeLooping(bool loopChange)
    {
        isLooping = loopChange;
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
        switch (isRound)
        {
            case 1:
                TalkRound1();
                break;
            case 2:
                TalkRound2();
                break;
            case 3:
                TalkRound3();
                break;

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

    public void TalkRound3()
    {
        ConversationManager.Instance.StartConversation(convoListRound3[convoNmbrRound3]);
        if ((convoListRound3.Length - 1) > convoNmbrRound3)
        {
            convoNmbrRound3++;
        }
        else
        {
            if (isLooping)
            {
                convoNmbrRound3 = 0;
            }
            else
            {
                trigger.hasConversation = false;
            }
        }
    }

}
