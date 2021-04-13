using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int count;
    public static int health = 5;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "peningur1") // ef tag er peningur1, þá rekst leikmaður
                                                   // á venjulegan pening, 1 stig
        {
            count = count + 1;
            Destroy(hit.gameObject);
            hit.collider.gameObject.SetActive(false);
            Debug.Log("peningur");
        }
        if (hit.collider.tag == "ovinur") 
        {
            health = health - 1;
            Destroy(hit.gameObject);
            hit.collider.gameObject.SetActive(false);
            Debug.Log("Rakst á óvin");
        }
    }

}
