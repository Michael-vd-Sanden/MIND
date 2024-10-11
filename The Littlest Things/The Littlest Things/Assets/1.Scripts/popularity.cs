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

    public Slider popularitySlider;
    public TMP_Text objectiveText;

    private void Start()
    {
        popularityPoints = 0;
        minPopularity = 0;
        maxPopularity = 10;
    }

    public void changePopularity(int popChange)
    {
        popularityPoints += popChange;
        if(popularityPoints > maxPopularity) popularityPoints = maxPopularity;
        if(popularityPoints < minPopularity) popularityPoints = minPopularity;

        popularitySlider.value = popularityPoints;
    }

    public void ChangeObjective()
    {
        objectiveText.text = "Win the lunch crown";
    }

}
