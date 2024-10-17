using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public GameObject[] walkingPoints;
    public float walkingSpeed;
    private bool isMoving = false;
    private Vector3 currentPoint;
    private int pointCounter = 0;

    public void walkToPoint()
    {
        currentPoint = walkingPoints[pointCounter].transform.position;
        isMoving = true;
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (this.transform.position != currentPoint)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, currentPoint, walkingSpeed * Time.deltaTime);
            }
            else
            { 
                isMoving = false;
                pointCounter++;
            }
        }
    }
}
