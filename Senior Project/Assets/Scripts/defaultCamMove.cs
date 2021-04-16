using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultCamMove : MonoBehaviour
{
    public CameraSwitch camSel;
    public KeyCode forward, left, right, back;
    private Vector3 direction;
    public float mainSpeed = 100.0f; //regular speed


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camSel.camVal == 1) 
        {
            direction = GetBaseInput();
            // Debug.Log("This is the original direction " + direction + "THis is the Y position !!!!!::!!!!!! " + transform.position.y);
            direction = direction * mainSpeed;
            // Debug.Log("This is the direction after multiplied by mainSpeed " + direction + "THis is the Y position !!!!!::!!!!!! " + transform.position.y);
            direction = direction * Time.deltaTime;
            // Debug.Log("This is the direction multiplied by time.deltatime " + direction + "THis is the Y position !!!!!::!!!!!! " + transform.position.y);
            Vector3 dirt = new Vector3(direction.x + transform.position.x, transform.position.y, direction.z + transform.position.z);
            transform.Translate(dirt);
            Debug.Log("THis is the Vector3 dirt !!!!!::!!!!!! " + dirt);
        }
    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(forward))
        {
            p_Velocity += new Vector3(0, 0, 1);
            Debug.Log("Forward");
        }
        if (Input.GetKey(back))
        {
            p_Velocity += new Vector3(0, 0, -1);
            Debug.Log("back");
        }
        if (Input.GetKey(left))
        {
            p_Velocity += new Vector3(-1, 0, 0);
            Debug.Log("left");
        }
        if (Input.GetKey(right))
        {
            p_Velocity += new Vector3(1, 0, 0);
            Debug.Log("right");
        }
        return p_Velocity;
    }

}
