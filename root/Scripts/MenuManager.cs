using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This manages the scene changing in the main menu
*/

public class MenuManager : MonoBehaviour
{
    //Next Screen
    public void NextScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Help Screen
    public void HelpScreen()
    {
        SceneManager.LoadScene(3);
    }

    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
