using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByssaSnu : MonoBehaviour
{
    public Transform kamera;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = kamera.rotation;
    }
}
