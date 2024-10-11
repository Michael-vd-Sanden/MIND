using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlot;
    public void AddItem(string itemName, Sprite itemSprite)
    {
        for (int i = 0; i< itemSlot.Length; i++) 
        { 
            if (itemSlot[i].isFull == false) 
            {
                itemSlot[i].AddItem(itemName, itemSprite);
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
}
