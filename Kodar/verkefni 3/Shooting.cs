using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; //bullet importað inn
    private int speed = 20; // speed fyrir kúluna
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F))  //ef vinstri smellt er á mús eða f takka
        {
            Debug.Log("pew");// gefur til kynna að skotið er       
           
           // tekur inn bullet objectið og skýtur henni frá byrjunarstað, í rigidbody formi, og eyðir henni aftur
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed);
            Destroy(instBullet, 1);//kúlu eytt eftir 1 sek
          
        }
    }
}
