using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour
{
    [SerializeField]
    private float upperBounds = 4.5f;
    [SerializeField]
    private float lowerBounds = -4.53f;
    [SerializeField]
    private float[] lane;

    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        MoveUpOrDown();
    }

    public void MoveUpOrDown()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(count > lane.Length - 2)
            {
                count = lane.Length - 1;
            }
            else if(count < 0)
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
}
