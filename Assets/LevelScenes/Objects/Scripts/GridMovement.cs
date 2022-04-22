using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(0f,0f,5f*Time.deltaTime);
    }
}
