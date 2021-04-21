using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 20; // hraða breyta
    public Rigidbody rb; // rigidbody kúlu
    public static int count; // count fyrir óvini drepna
    private static int telurStora = 0; // telur hversu oft stórir óvinir eru hittir, áður en hann fellur
    void Start()
    {
        rb.velocity = transform.forward  * speed; // hreyfir kúluna áfram þegar hún er kölluð til leiks
    }
    private void OnCollisionEnter(Collision collision) // árekstrar kúlu
    {
        if (collision.collider.tag == "ovinur") // ef kúla rekst á venjulegan óvin
        {
            count = count + 1; // bætir við einum í óvina dráp
            Destroy(collision.gameObject); // eyðir óvin og setur false
            gameObject.SetActive(false);
            Debug.Log("drap óvin"); // gefur til kynna hvað gerðist
        }
        if (collision.collider.tag == "storiOvinur") // ef það er stór óvinur
        {
            telurStora = telurStora + 1; // bætir einum við talningu stóra
            Debug.Log("hitti stóran"); // gefur til kynna hvað gerðist
            Debug.Log(telurStora); // sýnir hvað er komið upp í marga
            if (telurStora == 3) // ef talið er upp í þrjá
            {
                count = count + 3; // þá fær player 3 stig í óvina dráp
                Destroy(collision.gameObject); // eyðir stóra óvin út og setur false
                gameObject.SetActive(false);
                Debug.Log("Drap stóran óvin");// gefur til kynna hvað gerðist
                telurStora = 0; // endurræsir countinn fyrir stóra óvin
            }
        }
    }
}
