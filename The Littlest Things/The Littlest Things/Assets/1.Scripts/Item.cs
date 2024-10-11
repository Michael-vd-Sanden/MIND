using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;

    public InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inventoryManager.AddItem(itemName, sprite);
        Destroy(gameObject);
    }
}
