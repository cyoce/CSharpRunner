using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int gameQuit;
    public GameObject QuitGameButton;

    public void QuitGame()
    {
        Application.Quit();
    }
}

