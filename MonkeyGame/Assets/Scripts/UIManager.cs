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
    static public int level = 1;
    public int maxScore = 10;
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
            scoreText.text = "Score: " + score + "/"+ maxScore;
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if(score == maxScore)
        {
            playerControllerScript.gameOver = true;
            won = true;

            scoreText.text = "You Win!\n Press C to Continue or \n R to try a different mode!";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.C) && won)
        {
            level++;
            score = 0;
            playerControllerScript.gameOver = false;
            won = false;
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            level = 1;
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
        maxScore = 20;
    }
    public void bike()
    {
        vehicle = 2;
        plAnim.SetInteger("vehicle", 2);
        Time.timeScale = 1;
        UI.enabled = true;
        maxScore = 15;
        startscreen.enabled = false;
    }

    public void run()
    {
        vehicle = 3;
        plAnim.SetInteger("vehicle", 3);
        Time.timeScale = 1;
        UI.enabled = true;
        startscreen.enabled = false;
        maxScore = 10;
    }

}
