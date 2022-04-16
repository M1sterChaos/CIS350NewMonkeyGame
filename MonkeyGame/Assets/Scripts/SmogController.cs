/*
 * Zach Daly
 * Project
 * Controls smog onscreen depending on vehicle
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogController : MonoBehaviour
{
    public ParticleSystem smog1;
    public ParticleSystem smog2;
    public ParticleSystem smog3;
    public ParticleSystem smog4;
    public ParticleSystem smog5;
    public ParticleSystem smog6;

    // We can update this variable to set different levels of smog depending on
    // the players mode of transportation
    private string playerVehicle;

    // Start is called before the first frame update
    void Start()
    {
        playerVehicle = "Car";

        smog1.Play();
        smog3.Play();
        smog5.Play();
        StartCoroutine("DelayedStart");
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2.5f);

        smog2.Play();
        smog4.Play();
        smog6.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerVehicle == "Car")
        {
            
        }
        if (playerVehicle == "SmallerCar")
        {
            smog1.Stop();
            smog2.Stop();
        }
        if (playerVehicle == "Moped")
        {
            smog3.Stop();
            smog4.Stop();
        }
        if (playerVehicle == "Moped")
        {
            smog5.Stop();
            smog6.Stop();
        }
    }
}