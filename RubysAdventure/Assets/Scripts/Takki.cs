using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{
    public void Byrja() // byrjar á Senu 1, fyrsta borð
    {
        SceneManager.LoadScene(1);
    }
    public void Endir() // ef player kýs að ætla spila aftur, þá endurræsist leikurinn
                        // á borð 1 og counter er endurræstur
    {
        SceneManager.LoadScene(1);
    }
}
