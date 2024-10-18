using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBtn : MonoBehaviour
{
    public GameObject triggerBtn;
    public bool hasConversation;

    private bool hasEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
    }

    public void changeHasConversation(bool change)
    {
        hasConversation = change;
    }
    private void Update()
    {
        if (hasEntered) 
        {
            if (hasConversation)
            {
                triggerBtn.SetActive(true);
            }
            else 
            {
                triggerBtn.SetActive(false);
            }
        }
        else
        {
            triggerBtn.SetActive(false);
        }
    }
}
