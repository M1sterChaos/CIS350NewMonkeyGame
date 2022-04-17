/*
 * Evan Wieland, Luke Lesimple
 * Monkey game
 * 
 * Manages the UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public int score = 0;
    public Text scoreText;
    public PlayerController playerControllerScript;
    public bool won = false;

    public Canvas startscreen;
    public Canvas UI;

    public static int vehicle = 0;

    public Button carbut;
    public Button bikebut;
    public Button runbut;

    public Animator plAnim;

    // Start is called before the first frame update
    void Start()
    {

        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";

        plAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        

        Time.timeScale = 0;
        UI.enabled = false;
        startscreen.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score +", " + vehicle;
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if(score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            score = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void car()
    {
        vehicle = 1;
        Time.timeScale = 1;
        UI.enabled = true;
        startscreen.enabled = false;
    }
    public void bike()
    {
        vehicle = 2;
        plAnim.SetInteger("vehicle", 2);
        Time.timeScale = 1;
        UI.enabled = true;
        startscreen.enabled = false;
    }

    public void run()
    {
        vehicle = 3;
        plAnim.SetInteger("vehicle", 3);
        Time.timeScale = 1;
        UI.enabled = true;
        startscreen.enabled = false;
    }

}
