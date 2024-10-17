using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyStarting : MonoBehaviour
{
    public bool doneTalking = false;
    public NPCWalking walking;
    public NPCConversation bullyConvo;

    public void talkDone()
    {
        doneTalking = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(doneTalking) 
        {
           StartCoroutine(walkTalking());
        }
    }

    private IEnumerator walkTalking()
    {
        walking.walkToPoint();
        yield return new WaitForSecondsRealtime(2f);
        ConversationManager.Instance.StartConversation(bullyConvo);
        doneTalking = false;
    }
}
