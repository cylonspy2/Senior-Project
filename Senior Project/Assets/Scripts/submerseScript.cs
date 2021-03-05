using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submerseScript : MonoBehaviour
{
    public GameObject subMerse;
    public GameObject camControl;
    public GameObject camRoot;
    public float mainSpeed = 100.0f;
    public float mainRotMult = 0.25f;
    public float camSens = 0.25f;
    public Vector2 camClamp;
    public Vector3 subClamp;

    public KeyCode forward;
    public KeyCode leftTurn;
    public KeyCode rightTurn;
    public KeyCode backward;
    public KeyCode up;
    public KeyCode down;

    private Vector3 lastMouse;

    // Start is called before the first frame update
    void Start()
    {
        lastMouse = new Vector3(Screen.width/2, Screen.height/2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        camControl.transform.position = camRoot.transform.position;

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        //lastMouse = new Vector3(Mathf.Clamp(camControl.transform.eulerAngles.x + lastMouse.x, camClamp.x, -camClamp.x), Mathf.Clamp(camControl.transform.eulerAngles.y + lastMouse.y, camClamp.y, -camClamp.y), 0);
        lastMouse = new Vector3(camControl.transform.eulerAngles.x + lastMouse.x, camControl.transform.eulerAngles.y + lastMouse.y, 0);
        camControl.transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;



        Vector3 p = GetBaseInput();
        p = p * mainSpeed * Time.deltaTime;



        subMerse.transform.eulerAngles = new Vector3(subMerse.transform.eulerAngles.x + p.x, subMerse.transform.eulerAngles.y, subMerse.transform.eulerAngles.z);



        Vector3 q = new Vector3(0, p.y, p.z);
        subMerse.transform.Translate(q);
        subMerse.transform.position = new Vector3(Mathf.Clamp(subMerse.transform.position.x, subClamp.x, -subClamp.x), Mathf.Clamp(subMerse.transform.position.y, subClamp.y, -subClamp.y), Mathf.Clamp(subMerse.transform.position.z, subClamp.z, -subClamp.z));

    }

    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(forward))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(backward))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(leftTurn))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(rightTurn))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(up))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if(Input.GetKey(down))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }

}
