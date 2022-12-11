using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This code will start the game when the play button is pressed
    public void StartFunction()
    {
        SceneManager.LoadScene("Village_Level");
    }

    // This code will close the game when the exit button is pressed
    public void ExitFunction()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
