using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int count;
    public static int health = 3;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "peningur1") 
        {
            hit.collider.gameObject.SetActive(false);
            count = count + 1;
            Destroy(hit.gameObject);
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "vatn")
        {
            StartCoroutine(Bida());
        }
    }
    IEnumerator Bida() // bíður í eina sek og kallar í fallið endurræsa
    {
        yield return new WaitForSeconds(0.5f);
        Endurraesa();
    }
    public void Endurraesa() // endurræsir í senu 1, sem er fyrra borðið
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);
        count = 0;
        health = 3;
        Bullet.count = 0;
    }
    void Die()
    {
      
    }
}
