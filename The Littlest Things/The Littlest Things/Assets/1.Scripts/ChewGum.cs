using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChewGum : MonoBehaviour
{
    public bool isPlaying = false;
    public bool isAllowed = false;
    public bool hasChewedGum = false;
    public bool hasDistraction = false;
    public GameObject minigameObject;
    public Slider gumSlider;
    public InventoryManager inventoryManager;

    public Item chewedGum;
    public GameObject pressX;
    public TMP_Text xText;
    public AudioSource gumSound;

    public ConversationManager conversationManager;
    public NPCConversation distractionConvo;
    
    public void startPlaying()
    {
        isPlaying = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && isAllowed) 
        {
            conversationManager.StartConversation(distractionConvo);
            //isPlaying = true;
            pressX.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.X) && hasChewedGum)
        {
            gumSound.Play();
            hasChewedGum = false;
            pressX.SetActive(false);
        }
        if (isPlaying)
        {
            minigameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gumSlider.value++;
                if(gumSound.isPlaying) 
                { gumSound.Stop(); }
                gumSound.Play();
            }
            if(gumSlider.value == 50 ) 
            { 
                completedGum();
            }
        }
        else
        {
            minigameObject.SetActive(false);
        }
    }

    public void completedGum()
    {
        foreach (ItemSlot i in inventoryManager.itemSlot)
        {
            if (i.thisItemID == 2) //gumID
            {
                i.RemoveItem();
                i.AddFullItem(chewedGum);
            }
        }
        isPlaying = false;
        isAllowed = false;
        minigameObject.SetActive(false);
        hasChewedGum = true;
        xText.text = "Press X to place gum";
        pressX.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (ItemSlot i in inventoryManager.itemSlot)
        {
            if (i.thisItemID == 3 && hasDistraction) //gumID
            {
                pressX.SetActive(true);
                isAllowed = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressX.SetActive(false);
        isAllowed = false;
    }

    public void createDistraction()
    {
        hasDistraction = true;
    }
}
