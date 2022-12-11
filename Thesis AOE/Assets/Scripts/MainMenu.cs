using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This code will start the game and open up the village level scene
    public void StartFunction()
    {
        SceneManager.LoadScene("Village_Level");
    }
}
