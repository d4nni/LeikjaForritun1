using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller; // controller fyrir karakter
    public Animator animator; // animator sem er settur inn fyrir karakter

    static public int maxHealth = 5; // int fyrir max health(l�f)
    static public int currentHealth; // int fyrir n�verandi health(l�f)
    public float runSpeed = 40f; // hlaupa hra�i fyrir karakter

    static public int points = 0; // int fyrir stig hj� leikmanni

    public Text lif; // texti fyrir l�f leikmanns
    public Text stig; // texti fyrir stig leikmanns

    float horizontalMove = 0f; // float fyrir hreyfingu leikmanns til hli�anna
    bool jump = false; // bool fyrir hopp hreyfingar leikmanns

    void Start()
    {
        currentHealth = maxHealth; // n�verandi health ver�ur maxHealth
    }

    void Update () {

        SetText(); // uppf�rir texta

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // f�rir til hli�anna eftir hvert input � axis v�sa

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // animator setur float speed � horizontal input

		if (Input.GetButtonDown("Jump")) // ef input er hoppa takki, space � �essu tilfelli
		{
			jump = true; // hoppa er true
            animator.SetBool("IsJumping", true); // setur animator � jumping hreyfingu
		}

        if (currentHealth == 0) // ef health ver�ur 0
        {
            Respawn(); // setur respawn af sta�
        }
        if (transform.position.y < -30) // ef leikma�ur er kominn a�eins of langt ni�ur fyrir mappi�
        {
            Respawn(); // setur respawn af sta�
        }

	}
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.collider.tag == "Enemy") // ef rekist er � �vin
        {
            currentHealth -= 1; // health missir einn

            collision.collider.gameObject.SetActive(false); // setur �vin � false
        }
        if (collision.collider.tag == "Peningur") // ef rekist er � pening
        {
            points += 1; // b�tir vi� einum � stig

            collision.collider.gameObject.SetActive(false); // setur pening � false
        }
    }
    private void SetText()
    {
        lif.text = "L�f: " + currentHealth.ToString(); // prentar l�f leikmanns texta yfir � strengja form
        stig.text = "Stig: " + points.ToString(); // og stig leikmanns
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver(); // ef rekist er � enda trigger, fer � gameover fall
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false); // ef leikma�ur lendir � j�r�inni, h�ttir a� hoppa
    }

    void Respawn()
    {
        currentHealth = maxHealth; // endurr�sir l�f of stig
        points = 0;
        SceneManager.LoadScene(1); // loadar a�alsenu
    }

    void GameOver()
    {
        SceneManager.LoadScene(2); // loadar enda senu
    }

    void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); // f�rir karakter
		jump = false; // setur hoppi� � false
	}
}
