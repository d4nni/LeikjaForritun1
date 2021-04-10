using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    // breyta fyrir player, þannig hægt sé að tengja cameru við player
    public GameObject player;
    // offset breyta sem er föst, þannig að camera sé ekki inn í player, heldur aðeins fyrir aftan
    private Vector3 offset = new Vector3(0, 6, -8);

    // Update er kallað inn á hverjum ramma
    void Update()
    {
        // færir cameru í samræmi við player og bætir við offsettinu til þess að hún haldist fyrir aftan
        transform.position = player.transform.position + offset; 
    }
}
