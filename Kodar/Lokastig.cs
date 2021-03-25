using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lokastig : MonoBehaviour
{
    public Text stig; // texti fyrir stigin

    void Start()
    {
        stig.text = "Lokastig: " + Playermovement.count.ToString(); // prentar í streng lokastig
    }
}
