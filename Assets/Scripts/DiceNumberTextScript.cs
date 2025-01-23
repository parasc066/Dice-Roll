
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour
{
    public TextMeshProUGUI diceholder;
    public static int diceNumber;


    public void Update()
    {
        diceholder.text = diceNumber.ToString();
    }

    public void resetTextOutput()
    {
        diceholder.text = null;
    }
}

