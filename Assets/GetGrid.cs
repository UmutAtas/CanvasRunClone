using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class GetGrid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.layer = 9;
            if (other.TryGetComponent(out GateHandler temp))
            {
                if (temp.textNumber < 0)
                {
                    GridHandle.Instance.GetNewGridXNegative(temp.textNumber);
                }
                else if (temp.textNumber > 0)
                {
                    GridHandle.Instance.GetNewGridXPositive(temp.textNumber);
                }
            }
        }
    }
}
