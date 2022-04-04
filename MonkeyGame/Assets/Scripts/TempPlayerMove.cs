using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(this.transform.position.y < 4.5f)
            {
                this.transform.Translate(new Vector3(0, 3f, 0));
                if (this.transform.position.y >= 4.5f)
                {
                    transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (this.transform.position.y > -4.5f)
            {
                this.transform.Translate(new Vector3(0, -3f, 0));
                if (this.transform.position.y <= -4.5f)
                {
                    transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
                }
            }
        }
    }
}
