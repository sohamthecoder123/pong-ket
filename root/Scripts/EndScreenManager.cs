using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This manages the end screen 
*/

public class EndScreenManager : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(1); //load the game scene
    }

    public void Menu()
    {
        SceneManager.LoadScene(0); //load the main menu
    }
}
