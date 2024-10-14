using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    [SerializeField] public int itemID;

    public GameObject textE;
    public InventoryManager inventoryManager;

    private bool inRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textE.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textE.SetActive(false);
        inRange = false;
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            inventoryManager.AddItem(itemName, sprite, itemID);
            gameObject.SetActive(false);
        }
    }
}
