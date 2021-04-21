using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lokastig : MonoBehaviour
{
    private static int stigOvinir; // býr til private int fyrir óvinastig
    private static int stigPeningar; // og peninga
    public Text peningar; // og texta fyrir bæði
    public Text ovinir;
    void Start()
    {
        stigOvinir = Bullet.count; // tekur inn óvina drápin
        SetOvinirText(); // og setur upp í streng með þessu falli
        stigPeningar = Player.count; // sama hér
        SetPeningarText();
    }
    void SetOvinirText()
    {
        peningar.text = "Óvinir drepnir: " + stigOvinir.ToString();
        Bullet.count = 0; // svo þarf að endurræsa count fyrir næsta leik
    }
    void SetPeningarText()
    {
        ovinir.text = "Peningar safnaðir: " + stigPeningar.ToString();
        Player.count = 0; // og hérna líka
    }
}
