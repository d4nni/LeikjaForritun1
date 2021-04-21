using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lokastig : MonoBehaviour
{
    private static int stigOvinir;
    private static int stigPeningar;
    public Text peningar;
    public Text ovinir;
    void Start()
    {
        stigOvinir = Bullet.count;
        SetOvinirText();
        stigPeningar = Player.count;
        SetPeningarText();
    }
    void SetOvinirText()
    {
        peningar.text = "Óvinir drepnir: " + stigOvinir.ToString();
        Bullet.count = 0;
    }
    void SetPeningarText()
    {
        ovinir.text = "Peningar safnaðir: " + stigPeningar.ToString();
        Player.count = 0;
    }
}
