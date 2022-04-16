/*
 * Evan Wieland
 * Monkey game
 * 
 * Controls player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    public Sprite healthSprite;
    public Sprite harmSprite;
    public Image[] healthDisplay;
    public int health;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip crashSound;
    public AudioClip healthSound;
    public AudioClip lootSound;

    private AudioSource playerAudio;



    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();

        health = healthDisplay.Length;

        dirtParticle.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            // Play expolosion particle
            explosionParticle.Play();

            // Play crash noise
            playerAudio.PlayOneShot(crashSound, 1.0f);

            healthDisplay[health - 1].sprite = harmSprite;
            health--;

            if(health <= 0)
            {
                gameOver = true;
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Loot") && !gameOver)
        {
            playerAudio.PlayOneShot(lootSound, 1.0f);
            collision.gameObject.SetActive(false);
            UIManager.score++;
        }

        if (collision.gameObject.CompareTag("Health") && !gameOver)
        {
            playerAudio.PlayOneShot(healthSound, 1.0f);
            collision.gameObject.SetActive(false);
            if (health < healthDisplay.Length)
            {
                healthDisplay[health].sprite = healthSprite;
                health++;
            }
        }

        /* if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
         {
             Debug.Log("Game Over!");
             gameOver = true;

             // Play expolosion particle
             explosionParticle.Play();

             // Play crash noise
             playerAudio.PlayOneShot(crashSound, 1.0f);

             // Stop playing dirt particle
             dirtParticle.Stop();
         }*/
    }
}
