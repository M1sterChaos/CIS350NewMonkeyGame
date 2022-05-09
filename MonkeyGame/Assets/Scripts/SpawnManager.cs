/*
 * Evan Wieland
 * Monkey game
 * 
 * Handles spawning
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject lootPrefab;
    public GameObject healthPrefab;

    public float[] spawnPositions;

    private float startDelayObstacle = 2;
    private float repeatRateObstacle = 2;
    private float startDelayHealth = 7;
    private float repeatRateHealth = 7;
    private float startDelayLoot = 3;
    private float repeatRateLoot = 3;

    private PlayerController playerControllerScript;
    private GameObject monkey;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        monkey = GameObject.FindGameObjectWithTag("Monkey");
        StartCoroutine(SpawnObstacle(startDelayObstacle));
        InvokeRepeating("SpawnHealth", startDelayHealth, repeatRateHealth);
        InvokeRepeating("SpawnLoot", startDelayLoot, repeatRateLoot);
    }

    IEnumerator SpawnObstacle(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            if (playerControllerScript.gameOver == false)
            {
                Vector2 spawnPosition = new Vector2(10, spawnPositions[Random.Range(0, spawnPositions.Length)]);
                Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            }
            yield return new WaitForSeconds(repeatRateObstacle / UIManager.level);
        }
    }

    void SpawnHealth()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector2 spawnPosition = new Vector2(10, spawnPositions[Random.Range(0, spawnPositions.Length)]);
            Instantiate(healthPrefab, spawnPosition, healthPrefab.transform.rotation);
        }
    }

    void SpawnLoot()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector2 spawnPosition = new Vector2(monkey.transform.position.x - .2f, monkey.transform.position.y);
            Instantiate(lootPrefab, spawnPosition, lootPrefab.transform.rotation);
        }
    }
}
