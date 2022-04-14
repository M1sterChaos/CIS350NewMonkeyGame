/*
 * Zach Daly
 * Project
 * Move the monkey
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheMonkey : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(12, 2, 0);
    private Vector3 pos2 = new Vector3(12, -4, 0);
    public float speed = 0.75f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}