using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    static int count = 0;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //destroy the projectile when it reach a distance of 1000.0f from the origin
        if(transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }

    //called by the player controller after it instantiate a new projectile to launch it.
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();

        //if the object we touched wasn't an enemy, just destroy the projectile.
        if (e != null)
        {
            e.Fix();
            count += 1;
            if (count == 13)
            {
                SceneManager.LoadScene(2);
            }
        }
        
        Destroy(gameObject);
    }
}
