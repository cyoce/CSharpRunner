using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class OnDeath : MonoBehaviour
{
    public string afterDeath;

    public void Dies()
    {
        SceneManager.LoadScene(afterDeath);
        Debug.Log("dies");
    }

    public void Dead()
    {
        PlayerControl.onDeath += Dies;
    }

    private void OnEnable()
    {
        PlayerControl.onDeath += Dies;
    }

    private void OnDisable()
    {
        PlayerControl.onDeath -= Dies;
    }
}
