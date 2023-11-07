using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    public int controls;
    public GameObject OpenControls;

    public void ControlButton()
    {
        SceneManager.LoadScene(controls); 
    }
}
