/*
 * Evan Wieland
 * Monkey game
 * 
 * Handles monkey move
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMove : MonoBehaviour
{
    public float[] movePositions;

    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;
    private GameObject monkey;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        monkey = GameObject.FindGameObjectWithTag("Monkey");
        InvokeRepeating("MoveMonkey", startDelay, repeatRate);
    }

    void MoveMonkey()
    {
        if (playerControllerScript.gameOver == false)
        {
            monkey.transform.position = new Vector2(monkey.transform.position.x, movePositions[Random.Range(0, movePositions.Length)]);
        }
    }
}
