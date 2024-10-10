using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBtn : MonoBehaviour
{
    public GameObject triggerBtn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerBtn.SetActive(true);
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerBtn.SetActive(false);
        Debug.Log("exit");
    }
}
