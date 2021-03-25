using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player; // transform hjá player
    public Vector3 offset; // býr til offset frá player, í þessu tilfelli þannig camera sé fyrir aftan

    void Update()
    {
        transform.position = player.position + offset; // hreyfir cameru í samræmi við player
                                                       // og offset
    }
}
