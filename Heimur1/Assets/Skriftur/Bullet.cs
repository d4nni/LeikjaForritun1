using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody rb;
    public int damage = 10;
    public static int count;
    private static int telurStora = 0;
    void Start()
    {
        rb.velocity = transform.forward  * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        Debug.Log("danni hér");
       // Ovinur ovinur = collision.collider.GetComponent<Ovinur>();
        if (collision.collider.tag=="ovinur")
        {
            count = count + 1;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            Debug.Log("drap óvin");
            // ovinur.TakeDamage(damage);//ná í aðferðina í klasanum Ovinur
            //  Destroy(gameObject);//eyða kúlunni
            // Debug.Log("kúlu eytt");
            // collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.tag=="storiOvinur")
        {
            telurStora = telurStora + 1;
            Debug.Log("hitti stóran");
            Debug.Log(telurStora);
            if (telurStora == 3)
            {
                count = count + 3;
                Destroy(collision.gameObject);
                gameObject.SetActive(false);
                Debug.Log("Drap stóran óvin");
                telurStora = 0;
            }
        }
        /*
        if (ovinur != null)
        {
            Debug.Log("hitti óvin");
           // ovinur.TakeDamage(damage);//ná í aðferðina í klasanum Ovinur
            Destroy(gameObject);//eyða kúlunni
            Debug.Log("kúlu eytt");
        }*/
        else if (collision.collider.name != "Player")
        {
          //  Destroy(gameObject);//eyða kúlunni
           // Debug.Log("kúlu líka eytt eytt");
        }
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        Debug.Log("konni hér");
        Ovinur ovinur = collision.GetComponent<Ovinur>();
        if (ovinur!= null)
        {
            Debug.Log("hitti óvin");
            ovinur.TakeDamage(damage);//ná í aðferðina í klasanum Ovinur
            Destroy(gameObject);//eyða kúlunni
            Debug.Log("kúlu eytt");
        }
        if (collision.name!="Player")
        {
            Destroy(gameObject);//eyða kúlunni
            Debug.Log("kúlu líka eytt eytt");
        }
       
   
    } */
    /*void SetCountText()
    {
        countText.text = "Kills: " + count.ToString();
    }
    */
}
