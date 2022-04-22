using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateHandler : MonoBehaviour
{
    public int textNumber;
    private void Start()
    {
        TextMeshProUGUI txt = GetComponentInChildren<TextMeshProUGUI>();
        if (textNumber <= 0)
        {
            txt.SetText(textNumber.ToString());
        }
        else
        {
            txt.SetText("+" + textNumber.ToString());
        }
        
    }
}
