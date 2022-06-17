using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // private Animator anim;
    private Rigidbody2D rb;
    public GameObject player;
    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        //f�r death animation
        // anim= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //die when in collision with enemy or trap
        if (collision.gameObject.CompareTag("Trap"))
        {

            deathSound.Play();
            Die();

        }
        if (collision.gameObject.CompareTag("enemy"))
        {

            deathSound.Play();
            Die();
        }
    }

    private void Die()
    {

        //f�r death animation
        //anim.SetTrigger("death");

        Debug.Log("Die");

        //no movement after death
        rb.bodyType = RigidbodyType2D.Static;

        //player disappears
        player.SetActive(false);

        //Levelrestart after 1 second
        Invoke("RestartLevel", 1);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("Restart");
    }

}