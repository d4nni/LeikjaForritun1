using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public Animator animator;

    public int maxHealth = 5;
    int currentHealth;
    public float runSpeed = 40f;

    static public int points = 0;

    public Transform respawnPosition;

    public Text lif;
    public Text stig;

    float horizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update () {

        SetText();

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("IsJumping", true);
		}

        if (currentHealth == 0)
        {
            Respawn();
        }
        if (transform.position.y < -30)
        {
            Respawn();
        }

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            currentHealth -= 1;

            Debug.Log(currentHealth);

            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.tag == "Peningur")
        {
            points += 1;

            Debug.Log(currentHealth);

            collision.collider.gameObject.SetActive(false);
        }
    }
    private void SetText()
    {
        lif.text = "Líf: " + currentHealth.ToString();
        stig.text = "Stig: " + points.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void Respawn()
    {
        currentHealth = maxHealth;
        points = 0;
        SceneManager.LoadScene(0);
    }

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
