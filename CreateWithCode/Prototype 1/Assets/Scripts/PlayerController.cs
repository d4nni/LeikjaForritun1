// allar using innkallanir sem unity kallar inn sjálfkrafa
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// classinn sem stýrir player
public class PlayerController : MonoBehaviour
{
    // breyta fyrir hraðann á ökutækinu
    private float speed = 20.0f;
    // breyta fyrir beygju hraðann
    private float turnSpeed = 60.0f;
    // breyta fyrir lárétt input
    private float horizontalInput;
    // breyta fyrir áfram eða lóðrétt input
    private float forwardInput;

    // Update er það fall sem kallað er inn á hverjum ramma
    void Update()
    {
        // lárétt input tekur inn input á láréttan ás
        horizontalInput = Input.GetAxis("Horizontal");
        // áfram input tekur inn input á lóðréttum ás
        forwardInput = Input.GetAxis("Vertical");

        // færa ökutækið áfram, stjórnað með lóðréttu inputti
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // beygir ökutækinu til hægri eða vinstri, stjórnað með láréttu inputti
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
