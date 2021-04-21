using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int count; // telur peninga
    public static int health = 3; // geymir health

    void Update()
    {
        if (health <= 0) // ef health fer niður fyrir eða jafnt og 0
        {
            Die(); // framkvæmir die function
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) // Player contact
    {
        if (hit.collider.tag == "peningur1")// ef player rekst á pening
        {
            hit.collider.gameObject.SetActive(false); // gerir pening óvirkan
            count = count + 1; // bætir einum við peninga count
            Destroy(hit.gameObject); // eyðir pening út
            Debug.Log("rakst á pening"); // gefur til kynna í Console hvað gerðist
        }
        if (hit.collider.tag == "ovinur") // ef player rekst á óvin
        {
            health = health - 1; // missir einn health
            Destroy(hit.gameObject);// eyðir óvin út
            hit.collider.gameObject.SetActive(false); // setur hann false
            Debug.Log("Rakst á óvin"); // gefur til kynna í console
        }
        if (hit.collider.tag == "storiOvinur") // ef player rekst á stóran óvin
        {
            health = health - 1; // missir einn health
            Destroy(hit.gameObject); // eyðir og setur false
            hit.collider.gameObject.SetActive(false);
            Debug.Log("Rakst á stóran óvin"); // gefur til kynna í console
        }
    }
    private void OnTriggerEnter(Collider other) // allir árekstrar players við triggera
    {
        if (other.GetComponent<Collider>().tag == "vatn") // vatn
        {
            Debug.Log("Datt í vatn"); // gefur til kynna hvað gerðist
            Drukknadi(); // drukknadi function sett af stað
        }
        if (other.GetComponent<Collider>().tag == "endatrigger") // endatrigger
        {
            LeikLokid(); // leikLokid function sett af stað
        }
    }
    public void Die() // die function
    {
        SceneManager.LoadScene(2); // loadar upp senu 2, sem er dauða sena
        count = 0; // endurræsir peningacount, health og óvina count
        health = 3;
        Bullet.count = 0;
    }
    public void Drukknadi() // drukknadi function
    {
        SceneManager.LoadScene(3); // loadar upp senu 3, sem er drukknaði sena
        count = 0;// gerir sama og í die function
        health = 3;
        Bullet.count = 0;
    }
    public void LeikLokid() // leiklokid function
    {
        SceneManager.LoadScene(4); // loadar upp senu 4, sem er loka sena
        health = 3; // endurræsir bara health, til að hægt sé að sýna lokastig í lokasenu
    }
}
