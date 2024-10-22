using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class popularity : MonoBehaviour
{
    public int popularityPoints;
    private int maxPopularity;
    private int minPopularity;

    public TMP_Text chocolateText;

    public Slider popularitySlider;
    public TMP_Text objectiveText;

    private void Start()
    {
        popularityPoints = 2;
        minPopularity = 0;
        maxPopularity = 2;
    }

    public void changeChocolate(int popChange)
    {
        popularityPoints += popChange;
        if(popularityPoints > maxPopularity) popularityPoints = maxPopularity;
        if(popularityPoints < minPopularity) popularityPoints = minPopularity;

        chocolateText.text = popularityPoints.ToString();
        //popularitySlider.value = popularityPoints;
    }

    public void ChangeObjective()
    {
        objectiveText.text = "Win the lunch crown";
    }

}
