using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string gameStartScene;
    public GameObject StartButton;

    public void StartGameButton()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
