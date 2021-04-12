using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovinur : MonoBehaviour
{
    public int health = 100;
    public GameObject daudi;
    public void TakeDamage(int damage)
    {
        Debug.Log("health er núna" + (health).ToString());
        health -= damage;
        if (health<=0)
        {

            //Die();
        }

    }
    void Die()
    {
        Debug.Log("deyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyrdeyr");
        Instantiate(daudi, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
