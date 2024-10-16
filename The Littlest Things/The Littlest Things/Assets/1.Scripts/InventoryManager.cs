using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlot;

    public Item[] availableItems;

    private void Start()
    {
        itemSlot[0].selectedShader.SetActive(true);
        itemSlot[0].thisItemSelected = true;
    }
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

    public void GiveItem(int ItemID) //the id of the correct item
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemSelected == true)
            {
                itemSlot[i].GiveSelectedItem(ItemID);
                return;
            }
        }
    }
}
