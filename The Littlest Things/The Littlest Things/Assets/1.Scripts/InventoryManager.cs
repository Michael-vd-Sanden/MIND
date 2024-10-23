using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlot;

    public Item[] availableItems;

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, int itemID)
    {
        for (int i = 0; i< itemSlot.Length; i++) 
        { 
            if (itemSlot[i].isFull == false) 
            {
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription, itemID);
                return;
            }
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void CheckIfItemAvailable(int ItemID)
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemID == ItemID)
            {
                ConversationManager.Instance.SetBool("hasCorrectItem", true);
                return;
            }
        }
        ConversationManager.Instance.SetBool("hasCorrectItem", false);
    }

    public void GiveItem(int ItemID) //the id of the correct item
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemID == ItemID)
            {
                itemSlot[i].GiveSelectedItem(ItemID);
                return;
            }
        }
    }
}
