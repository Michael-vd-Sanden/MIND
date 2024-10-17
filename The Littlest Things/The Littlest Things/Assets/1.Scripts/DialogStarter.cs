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
        }
        else
        {
            player.enabled = true;
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
            trigger.hasConversation = false;
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
            trigger.hasConversation = false;
        }
    }

}
