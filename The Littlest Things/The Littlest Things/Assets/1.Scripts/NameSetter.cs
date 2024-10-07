using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSetter : MonoBehaviour
{
    public string playerName;

    private void Start()
    {
        playerName = new string("");
    }
    public void setRiver()
    {
        playerName = "River";
    }
    public void setNoah()
    {
        playerName = "Noah";
    }
    public void setCharlie()
    {
        playerName = "Charlie";
    } 
}
