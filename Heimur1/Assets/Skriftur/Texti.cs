using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texti : MonoBehaviour
{
    private static int stigOvinir;
    private static int stigPeningar;
    private static int lif;
    public Text ovinirText;
    public Text peningarText;
    public Text lifText;
    void Update()
    {
        stigOvinir = Bullet.count;
        SetOvinirText();
        stigPeningar = Player.count;
        SetPeningarText();
        lif = Player.health;
        SetHealthText();
    }
    void SetOvinirText()
    {
        ovinirText.text = "Óvinir drepnir: " + stigOvinir.ToString();
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
