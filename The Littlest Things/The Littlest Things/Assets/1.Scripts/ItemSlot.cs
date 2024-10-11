using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public GameObject selectedShader;
    public bool thisItemSelected;
    public TMP_Text nameText;
    public GameObject deleteBtn;
    
    private InventoryManager inventoryManager;

    [SerializeField] private Image itemImage;
    private void Start()
    {
        inventoryManager = GameObject.Find("BagInventory").GetComponent<InventoryManager>();
        nameText.text = itemName;
    }

    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.sprite = itemSprite;
        nameText.gameObject.SetActive(true);
        deleteBtn.SetActive(true);
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

    public void RemoveItem()
    {
        this.itemImage.sprite = null;
        this.itemName = null;
        nameText.gameObject.SetActive(false);
        deleteBtn.gameObject.SetActive(false);
        isFull = false;

        //drop the item TODO
    }
}
