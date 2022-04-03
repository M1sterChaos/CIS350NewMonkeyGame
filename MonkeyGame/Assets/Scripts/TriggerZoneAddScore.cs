/*
 * Evan Wieland
 * Monkey game
 * 
 * Manages adding score when trigger zone entered
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private UIManager uIManager;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
