using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller; // controller fyrir karakter
    public Animator animator; // animator sem er settur inn fyrir karakter

    static public int maxHealth = 5; // int fyrir max health(líf)
    static public int currentHealth; // int fyrir núverandi health(líf)
    public float runSpeed = 40f; // hlaupa hraði fyrir karakter

    static public int points = 0; // int fyrir stig hjá leikmanni

    public Text lif; // texti fyrir líf leikmanns
    public Text stig; // texti fyrir stig leikmanns

    float horizontalMove = 0f; // float fyrir hreyfingu leikmanns til hliðanna
    bool jump = false; // bool fyrir hopp hreyfingar leikmanns

    void Start()
    {
        currentHealth = maxHealth; // núverandi health verður maxHealth
    }

    void Update () {

        SetText(); // uppfærir texta

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // færir til hliðanna eftir hvert input á axis vísa

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // animator setur float speed í horizontal input

		if (Input.GetButtonDown("Jump")) // ef input er hoppa takki, space í þessu tilfelli
		{
			jump = true; // hoppa er true
            animator.SetBool("IsJumping", true); // setur animator í jumping hreyfingu
		}

        if (currentHealth == 0) // ef health verður 0
        {
            Respawn(); // setur respawn af stað
        }
        if (transform.position.y < -30) // ef leikmaður er kominn aðeins of langt niður fyrir mappið
        {
            Respawn(); // setur respawn af stað
        }

	}
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.collider.tag == "Enemy") // ef rekist er á óvin
        {
            currentHealth -= 1; // health missir einn

            collision.collider.gameObject.SetActive(false); // setur óvin í false
        }
        if (collision.collider.tag == "Peningur") // ef rekist er á pening
        {
            points += 1; // bætir við einum í stig

            collision.collider.gameObject.SetActive(false); // setur pening í false
        }
    }
    private void SetText()
    {
        lif.text = "Líf: " + currentHealth.ToString(); // prentar líf leikmanns texta yfir á strengja form
        stig.text = "Stig: " + points.ToString(); // og stig leikmanns
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver(); // ef rekist er á enda trigger, fer í gameover fall
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false); // ef leikmaður lendir á jörðinni, hættir að hoppa
    }

    void Respawn()
    {
        currentHealth = maxHealth; // endurræsir líf of stig
        points = 0;
        SceneManager.LoadScene(1); // loadar aðalsenu
    }

    void GameOver()
    {
        SceneManager.LoadScene(2); // loadar enda senu
    }

    void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); // færir karakter
		jump = false; // setur hoppið í false
	}
}
