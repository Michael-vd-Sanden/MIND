using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class IntroStarter : MonoBehaviour
{
    public NPCConversation openingConvo;
    public SceneSwitch sceneSwitch;
    private bool hasStarted;


    private void Start()
    {
        hasStarted = false;
        if (openingConvo != null)
        {
            ConversationManager.Instance.StartConversation(openingConvo);
            hasStarted = true;
        }
    }

    private void Update()
    {
        if (hasStarted && ConversationManager.Instance.IsConversationActive == false) 
        { 
            StartCoroutine(waitTimeToSwitchScene());
        }
    }

    public IEnumerator waitTimeToSwitchScene()
    {
        yield return new WaitForSeconds(1f);
        sceneSwitch.LoadCafe();
    }

}
