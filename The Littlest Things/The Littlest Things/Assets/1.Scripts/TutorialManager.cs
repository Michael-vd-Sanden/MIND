using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject wasdKeys;
    public GameObject paperArrow;
    public GameObject paperBall;
    public GameObject bagArrow;
    public GameObject bagInventory;
    public GameObject itemArrow;
    public GameObject itemBorder;
    public GameObject comeClose;
    public TriggerBtn talkbubble;
    public bool isTutorialActive = false;

    private int tutorialStage = 0;

    public void Tutorial()
    {
        isTutorialActive = true;
        wasdKeys.SetActive(true);
    }

    private void Update()
    {
        if(isTutorialActive)
        {
            TutorialLoop();
        }
    }

    public void TutorialLoop()
    {
        switch (tutorialStage) 
        { 
            case 0: 
                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) 
                { 
                    wasdKeys.SetActive(false);
                    tutorialStage++;   
                }
                break;
            case 1: 
                paperArrow.SetActive(true);
                if(paperBall.activeSelf == false) 
                { 
                    paperArrow.SetActive(false);
                    bagArrow.SetActive(true);
                    tutorialStage++;
                }
                break;
            case 2:
                if(bagInventory.activeSelf)
                {
                    bagArrow.SetActive(false);
                    itemArrow.SetActive(true);
                    tutorialStage++;
                }
                break;
            case 3:
                if(itemBorder.activeSelf)
                {
                    itemArrow.SetActive(false);
                    comeClose.SetActive(true);
                    tutorialStage++;
                }
                break;
            case 4:
                if(talkbubble.hasEntered)
                {
                    comeClose.SetActive(false);
                    isTutorialActive = false;
                }
                break;

        }
    }
}
