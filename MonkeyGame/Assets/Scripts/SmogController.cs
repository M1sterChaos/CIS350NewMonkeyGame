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
    private int playerVehicle;

    // Start is called before the first frame update
    void Start()
    {
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
        playerVehicle = UIManager.vehicle;

        if (playerVehicle == 2)
        {
            smog1.Stop();
            smog2.Stop();
            smog3.Stop();
        }

        if (playerVehicle == 3)
        {
            smog1.Stop();
            smog2.Stop();
            smog3.Stop();
            smog4.Stop();
            smog5.Stop();
            smog6.Stop();
        }
    }
}