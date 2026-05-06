using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This sets the score of the game as it is running
*/


public class ScoreManager : MonoBehaviour
{
    GameManager gm; //the game manager

    public TMP_Text runs, wickets, balls; //the text of the scorecard

    private void Start()
    {
        gm = GetComponent<GameManager>(); //get the game manager
    }

    private void Update()
    {
        //set the scorecard
        runs.SetText(gm.runs.ToString()); 
        wickets.SetText(gm.wickets.ToString());
        balls.SetText(gm.ballsBowled.ToString());
    }
}
