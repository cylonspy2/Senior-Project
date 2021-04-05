using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCenterMove : MonoBehaviour
{
    public Transform target;
    public KeyCode forward, backward, left, right;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 blep = target.position;

        if (Input.GetKeyDown(right) || Input.GetKey(right))
        {
            blep = new Vector3(blep.x + speed * Time.deltaTime, blep.y, blep.z);
        }
        if (Input.GetKeyDown(left) || Input.GetKey(left))
        {
            blep = new Vector3(blep.x - speed * Time.deltaTime, blep.y, blep.z);
        }
        if (Input.GetKeyDown(forward) || Input.GetKey(forward))
        {
            blep = new Vector3(blep.x, blep.y, blep.z + speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(backward) || Input.GetKey(backward))
        {
            blep = new Vector3(blep.x, blep.y, blep.z - speed * Time.deltaTime);
        }


        target.position = blep;
    }
}
