/*
 * Austin Buck
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float upperBounds = 4.5f;
    [SerializeField]
    private float lowerBounds = -4.53f;
    [SerializeField]
    private float leftBound = -3f;
    [SerializeField]
    private float rightBound = 3f;
    [SerializeField]
    private float[] lane;
    [SerializeField]
    private float[] hMoveVehicleMod;

    private int count = 0;

    private float hMove;

    [SerializeField]
    private float speedModifier;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpeed();
        if (!playerControllerScript.gameOver)
        {
            hMove = Input.GetAxis("Horizontal");
            if(this.transform.position.x < leftBound)
            {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            }
            else if (this.transform.position.x > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }

            transform.Translate(Vector2.right * (hMove * speedModifier) * Time.deltaTime, Space.World);

            MoveUpOrDown();
        }
    }

    public void MoveUpOrDown()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (count > lane.Length - 2)
            {
                count = lane.Length - 1;
            }
            else if (count < 0)
            {
                count = 1;
            }
            else
            {
                count++;
            }
            if (this.transform.position.y >= upperBounds)
            {
                transform.position = new Vector3(transform.position.x, upperBounds, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, lane[count], transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (count < 0)
            {
                count = 0;
            }
            else
            {
                count--;
            }
            if (this.transform.position.y <= lowerBounds)
            {
                transform.position = new Vector3(transform.position.x, lowerBounds, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, lane[count], transform.position.z);
            }
        }
    }
    private void MoveSpeed()
    {
        switch(UIManager.vehicle)
        {
            case 1:
                speedModifier = hMoveVehicleMod[0];
                break;
            case 2:
                speedModifier = hMoveVehicleMod[1];
                break;
            case 3:
                speedModifier = hMoveVehicleMod[2];
                break;
            default:
                speedModifier = hMoveVehicleMod[0];
                break;
        }
    }
}
