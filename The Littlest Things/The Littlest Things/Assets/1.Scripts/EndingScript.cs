using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject picture;
    public GameObject badAss;
    public GameObject menuButton;
    public NPCConversation endingConvo;
    public NPCConversation crowningConvo;
    public ConversationManager conversationManager;

    private void Start()
    {
        conversationManager.StartConversation(crowningConvo);
    }

    public void EndingStart()
    {
        StartCoroutine(ending());
    }

    public void transitionStart()
    {
        StartCoroutine(transition());  
    }

    private IEnumerator ending()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        picture.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        conversationManager.StartConversation(endingConvo);
    }

    private IEnumerator transition()
    {
        picture.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        badAss.SetActive(true) ;
        yield return new WaitForSecondsRealtime(2f);
        menuButton.SetActive(true);
    }
}
