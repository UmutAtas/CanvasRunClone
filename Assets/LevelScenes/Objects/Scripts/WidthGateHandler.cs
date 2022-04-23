using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class WidthGateHandler : MonoBehaviour
{
    public int textNumber;
    public int multiplier;

    private void Start()
    {
        GetGateWidth();
    }
    private void GetGateWidth()
    {
        multiplier = Random.Range(1, 3);
        textNumber = Grid.Instance.currentZ * multiplier;
        print(Grid.Instance.currentZ);
        TextMeshProUGUI txt = GetComponentInChildren<TextMeshProUGUI>();
        txt.SetText("Width +" + textNumber.ToString());
    }
}
