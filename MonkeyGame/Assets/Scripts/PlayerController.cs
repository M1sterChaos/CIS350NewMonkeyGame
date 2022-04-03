/*
 * Evan Wieland
 * Monkey game
 * 
 * Controls player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool gameOver = false;

    //public Animator playerAnimator;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        dirtParticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Play expolosion particle
            explosionParticle.Play();

            // Play crash noise
            playerAudio.PlayOneShot(crashSound, 1.0f);

            // Stop playing dirt particle
            dirtParticle.Stop();
        }
    }
}
