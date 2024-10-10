using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void Update()
    {
        if(isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
