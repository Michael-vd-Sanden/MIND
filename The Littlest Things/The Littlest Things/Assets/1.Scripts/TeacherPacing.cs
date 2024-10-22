using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TeacherPacing : MonoBehaviour
{
    public GameObject[] walkingPoints;
    public float walkingSpeed;
    private bool isMoving = false;
    private Vector3 currentPoint;
    private int pointCounter = 0;

    public void StartPacing()
    {
        isMoving = true;
    }

    private void Update()
    {
        if(ConversationManager.Instance.IsConversationActive)
        {
            walkingSpeed = 0;
        }
        else
        {
            walkingSpeed = 3;
        }
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            currentPoint = walkingPoints[pointCounter].transform.position;
            if (this.transform.position != currentPoint)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, currentPoint, walkingSpeed * Time.deltaTime);
            }
            else
            {
                if(walkingPoints.Length - 1 > pointCounter) 
                {
                    pointCounter++;
                }
                else
                {
                    pointCounter = 0;
                }
            }
        }
    }
}
