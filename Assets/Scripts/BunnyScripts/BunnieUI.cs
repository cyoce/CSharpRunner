using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BunnieUI : MonoBehaviour
{
    private TextMeshProUGUI bunnieText;

    void Start()
    {
        bunnieText = GetComponent<TextMeshProUGUI>();
    }

    
    public void UpdateBunnieText(BunnyCounter bunnyCounter)
    {
        bunnieText.text = "Score: " + bunnyCounter.numberOfBunnies.ToString();
    }
}
