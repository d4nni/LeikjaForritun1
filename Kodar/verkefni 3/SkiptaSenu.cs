using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkiptaSenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ef ýtt er á Space
        {
            Debug.Log("Skipti um senu"); // skiptir í senu 1, sem er leiksenan
            SceneManager.LoadScene(1);
        }
    }
}
