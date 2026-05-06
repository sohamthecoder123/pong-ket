using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Game Manager Script
 * 
 * Keeps track of runs, wickets, etc.
 * Controls the game overall
 * Spawns balls as its own children
*/

public class GameManager : MonoBehaviour
{
    public int runs; //the runs scored 
    public int wickets; //the wickets lost
    public int maxWickets = 10; //max no of wickets (10 in normal, 11-a-side cricket)
    public int ballsBowled; //the no of balls bowled till now
    public bool isTest; //is the current game a test match (ie, infinite play)
    public int maxBalls; //the maximum no of balls (infinity for tests, lesser for lower versions)

    public int gameLossScene;

    int highScore = 0;

    //adds runs
    public void AddRuns(int i)
    {
        if (wickets < maxWickets)
        {
            runs += i;
        }
    }

    //makes loss of wickets
    public void AddWickets(int i)
    {
        if (wickets < maxWickets)
        {
            wickets += i;
        }
    }

    //balls bowled
    public void AddBalls(int i)
    {
        if (wickets < maxWickets)
        {
            ballsBowled += i;
        }
    }

    //ends game
    public void Lose()
    {
        print("You Lost");
        PlayerPrefs.SetInt("Runs", runs);
        PlayerPrefs.SetInt("Wickets", wickets);
        PlayerPrefs.SetInt("Balls", ballsBowled);

        if (runs > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = runs;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        SceneManager.LoadScene(gameLossScene);
    }

    private void Update()
    {
        //ends game if no of wickets lost exceeds no of players
        if(wickets >= maxWickets || ballsBowled >= maxBalls)
        {
            Lose();
        }
    }
}
