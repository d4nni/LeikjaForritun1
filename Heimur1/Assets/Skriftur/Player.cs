using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int count;
    public static int health = 3;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "peningur1") 
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
        if (hit.collider.tag == "storiOvinur")
        {
            health = health - 1;
            Destroy(hit.gameObject);
            hit.collider.gameObject.SetActive(false);
            Debug.Log("Rakst á stóran óvin");
        }
        if (hit.collider.tag == "vatn")
        {
            Debug.Log("Datt í vatn");
            // hér kemur lína til að endurræsa leikinn
            StartCoroutine(Bida()); // byrjar rútínuna Bíða
        }
    }
    IEnumerator Bida() // bíður í tvær sek og kallar í fallið endurræsa
    {
        yield return new WaitForSeconds(0.5f);
        Endurraesa();
    }
    public void Endurraesa() // endurræsir í senu 1, sem er fyrra borðið
    {
        SceneManager.LoadScene(0);
        count = 0;
        health = 3;
        Bullet.count = 0;
    }
}
