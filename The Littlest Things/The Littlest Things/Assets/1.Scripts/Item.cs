using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;
    [SerializeField] public int itemID;

    [SerializeField] private AudioSource pickupSound;

    public GameObject textE;
    public InventoryManager inventoryManager;

    public bool isStealing = false;
    public GameObject teacher;
    public float allowedDistance;
    private float teacherDistance;

    private bool inRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textE.SetActive(false);
        inRange = false;
    }

    private void Update()
    {
        if (inRange)
        {
            if (isStealing)
            {
                teacherDistance = Vector3.Distance(transform.position, teacher.transform.position);
                if (teacherDistance > allowedDistance)
                {
                    textE.SetActive(true);
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        checkE();
                    }
                }
                else if (teacherDistance < allowedDistance) 
                { 
                    textE.SetActive(false);
                }
            }
            else
            {
                textE.SetActive(true);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    checkE();
                }
            }
        }
    }

    public void checkE()
    {
        inventoryManager.AddItem(itemName, sprite, itemDescription, itemID);
        pickupSound.Play();
        gameObject.SetActive(false);
    }
}
