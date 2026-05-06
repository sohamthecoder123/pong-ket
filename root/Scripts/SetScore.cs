using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This manages the final scores on the end screen 
*/

public class SetScore : MonoBehaviour
{
    public string type; //the type of score to be displayed
    public TMP_Text text; //the text that is to be updated

    private void Start()
    {
        text.SetText(PlayerPrefs.GetInt(type).ToString()); //set the text to the type of score stored as PlayerPrefs
    }
}
