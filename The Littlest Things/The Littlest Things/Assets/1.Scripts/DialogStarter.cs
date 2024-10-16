using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogStarter : MonoBehaviour
{
    public PlayerMovement2D player;
    public TriggerBtn trigger;

    public NPCConversation[] convoList;
    private int convoNmbr = 0;

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
        ConversationManager.Instance.StartConversation(convoList[convoNmbr]);
        if ((convoList.Length - 1) > convoNmbr)
        {
            convoNmbr++;
        }
        else
        {
            trigger.hasConversation = false;
        }
    }

}
