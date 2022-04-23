using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class LengthGateHandler : MonoBehaviour
{
    public int textNumber;
    public int multiplier;

    private void Start()
    {
        GetGateLength();
    }
    private void GetGateLength()
    {
        multiplier = Random.Range(1, 3);
        textNumber = Grid.Instance.currentX * multiplier;
        print(Grid.Instance.currentX);
        TextMeshProUGUI txt = GetComponentInChildren<TextMeshProUGUI>();
        txt.SetText("Length +" + textNumber.ToString());
    }
}
