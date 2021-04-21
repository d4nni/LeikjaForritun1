using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkiptaSenu : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Byrja"); // gefur til kynna að sena hafi "loadast"
    }
    private void OnTriggerEnter(Collider other) // þegar rekist er á trigger, setur allt á false og
                                                // startar Bíða rútínu
    {
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());
    }
    IEnumerator Bida() // bíður í 2 sek og endurræsir leikinn með Endurræsa
    {
        yield return new WaitForSeconds(2);
        Endurraesa();
    }
    public void Endurraesa() // tekur current senu og loadar plús 1 í build index
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//næsta sena
    }
}
