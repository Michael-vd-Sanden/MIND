using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogStarter : MonoBehaviour
{
    public NPCConversation first;
    public NPCConversation second;
    private NPCConversation currentConvo;
    private int convoNumber = 1;

    public void Talk()
    {
        switch (convoNumber)
        {
            case 1:
                currentConvo = first; break;
            case 2:
                currentConvo = second; break;
        }
        if (currentConvo != null)
        {
            ConversationManager.Instance.StartConversation(currentConvo);
            convoNumber++;
        }
        
    }

}
