using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByssaSnu : MonoBehaviour
{
    public Transform kamera; // tekur inn transformation hjá kameru

    void Update()
    {
        transform.rotation = kamera.rotation; // hreyfir hlut eftir staðsetningu kameru
    }
}
