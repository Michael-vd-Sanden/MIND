using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public ConvoStarter convoStarter;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("IntroTrigger"))
        {
            convoStarter.triggerIntro();
        }
    }
}
