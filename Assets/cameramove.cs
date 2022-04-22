using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform pTransform;
    private Vector3 offset;
    void Start()
    {
        offset  = transform.position - pTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, transform.position.y,
            Mathf.Lerp(transform.position.z, pTransform.position.z + offset.z, 10f * Time.deltaTime));
    }
}
