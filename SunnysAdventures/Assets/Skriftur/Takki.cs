using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Takki : MonoBehaviour
{

    public void Byrja()
    {
        SceneManager.LoadScene(1); // loadar aðal senu
        PlayerMovement.points = 0; // endurræsir stig eftir að maður byrjar leik aftur eftir sigur
    }
}
