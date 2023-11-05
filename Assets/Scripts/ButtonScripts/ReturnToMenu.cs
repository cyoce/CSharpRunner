using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMenu : MonoBehaviour
{
    public int menuReturn;
    public GameObject ReturnButton;

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(menuReturn);
    }
}
