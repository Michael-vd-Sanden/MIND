using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConvoStarter : MonoBehaviour
{
    public NPCConversation openingConvo;
    public NPCConversation introConvo;

    public PlayerMovement2D player;

    private void Start()
    {
        if (openingConvo != null)
        {
            ConversationManager.Instance.StartConversation(openingConvo);
        }
    }
    private void Update()
    {
        if(ConversationManager.Instance.IsConversationActive)
        {
            player.enabled = false;
        }
        else
        {
            player.enabled = true;
        }
    }

    public void triggerIntro()
    {
        ConversationManager.Instance.StartConversation(introConvo);
    }

}
