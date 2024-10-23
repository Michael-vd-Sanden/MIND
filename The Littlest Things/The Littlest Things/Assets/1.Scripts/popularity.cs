using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DialogueEditor;

public class popularity : MonoBehaviour
{
    public int popularityPoints;
    private int maxPopularity;
    private int minPopularity;

    public TMP_Text chocolateText;

    public Slider popularitySlider;
    public TMP_Text objectiveText;
    public AudioSource pickupSound;
    public ConversationManager conversationManager;

    private int convoChocolate;

    private void Start()
    {
        popularityPoints = 2;
        minPopularity = 0;
        maxPopularity = 10;
    }

    public void changeChocolate(int popChange)
    {
        popularityPoints += popChange;
        if(popularityPoints > maxPopularity) popularityPoints = maxPopularity;
        if(popularityPoints < minPopularity) popularityPoints = minPopularity;

        chocolateText.text = popularityPoints.ToString();
        pickupSound.Play();
        //popularitySlider.value = popularityPoints;
    }

    public void checkChocolate()
    {
        if(popularityPoints >= 2)
        {
            ConversationManager.Instance.SetBool("enoughChocolate", true);
        }
        else
        {
            ConversationManager.Instance.SetBool("enoughChocolate", false);
        }
    }

    public void ChangeObjective()
    {
        objectiveText.text = "Win the lunch crown";
    }

}
