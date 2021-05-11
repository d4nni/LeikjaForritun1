using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StigSofnud : MonoBehaviour
{
    public Text stig; // texti fyrir lokastig
    int lokaStig = PlayerMovement.points; // nær í síðustu stig úr aðalsenu

    private void Update()
    {
        stig.text = "Lokastig: " + lokaStig.ToString(); // færir stigin yfir á strengjaform
    }

}
