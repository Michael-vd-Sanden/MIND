using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using DialogueEditor;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Sprite emptySprite;

    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public GameObject selectedShader;
    public bool thisItemSelected;
    public TMP_Text nameText;
    public GameObject deleteBtn;
    public TMP_Text descriptionText;
    public string itemDescription;
    
    private InventoryManager inventoryManager;
    private GameObject player;
    private int thisItemID;

    [SerializeField] private Image itemImage;
    private void Start()
    {
        inventoryManager = GameObject.Find("BagInventory").GetComponent<InventoryManager>();
        player = GameObject.Find("Player");
        nameText.text = itemName;
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription, int itemID)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        this.thisItemID = itemID;
        isFull = true;

        itemImage.sprite = itemSprite;
        nameText.text = itemName;
        descriptionText.text = itemDescription;
        nameText.gameObject.SetActive(true);
        deleteBtn.SetActive(true);
        //ConversationManager.Instance.SetBool("hasItems", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) 
        {
            ClickedOnItem();
        }
    }

    public void ClickedOnItem() 
    { 
        inventoryManager.DeselectAll();
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

    public void GiveSelectedItem(int ItemID)
    {
        if(thisItemSelected && isFull) 
        {
            if(thisItemID == ItemID) //correct item given
            {
                ConversationManager.Instance.SetBool("correctItemGiven", true);
            }
            else
            {
                ConversationManager.Instance.SetBool("correctItemGiven", false);
            }
            RemoveItem();
        }
    }

    public void RemoveItem()
    {
        //remove from list
        this.itemImage.sprite = emptySprite;
        this.itemName = "";
        nameText.gameObject.SetActive(false);
        deleteBtn.gameObject.SetActive(false);
        isFull = false;

        //bag empty or not?
      /*  foreach (ItemSlot i in inventoryManager.itemSlot)
        {
            int tempCounter = 0;
            if (i.isFull == false)
            {
                tempCounter++;
            }
            if(tempCounter == 3) //all spots are empty
            {
                ConversationManager.Instance.SetBool("hasItems", false);
            }
        }*/
    }

    public void DropItem()
    {
        //drop the item
        foreach (Item i in inventoryManager.availableItems)
        {
            if (i.itemID == thisItemID)
            {
                Vector3 offset = new Vector3(1, 0, 0);
                i.gameObject.transform.position = player.transform.position + offset;
                i.gameObject.SetActive(true);
            }
        }
    }
}
