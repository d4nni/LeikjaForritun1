using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texti : MonoBehaviour
{
    private static int stigOvinir; // býr til sér int fyrir óvinastig
    private static int stigPeningar; // sama fyrir peninga
    private static int lif; // og líf
    public Text ovinirText; // býr til public texta fyrir allt líka
    public Text peningarText;
    public Text lifText;
    void Update()
    {
        stigOvinir = Bullet.count; // tekur inn í sig óvina dráp count
        SetOvinirText(); // og kallar á óvinatexta function
        stigPeningar = Player.count; // sama með peninga stig og líf
        SetPeningarText();
        lif = Player.health;
        SetHealthText();
    }
    void SetOvinirText()
    {
        ovinirText.text = "Óvinir drepnir: " + stigOvinir.ToString(); // convertar yfir í streng,
        // sem hægt er svo að displaya in game
    }
    void SetPeningarText()
    {
        peningarText.text = "Peningar safnaðir: " + stigPeningar.ToString();
    }
    void SetHealthText()
    {
        lifText.text = "Líf: " + lif.ToString();
    }
}
