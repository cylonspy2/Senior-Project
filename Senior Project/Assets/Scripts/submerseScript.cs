using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submerseScript : MonoBehaviour
{
    public GameObject subMerse;
    public GameObject camControl;
    public GameObject camRoot;

    public GameObject foodPellet;
    public GameObject repellant;
    public GameObject fireNozzle;

    public gridPlaceScript propPlacementSystem;

    public bool attract;

    public float mainSpeed = 100.0f;
    public float mainRotMult = 0.25f;
    public float camSens = 0.25f;
    public float lerpSpeed = 1.0f;
    public float lerpClamp;
    public Vector3 subClamp, camClamp;

    public KeyCode forward;
    public KeyCode leftTurn;
    public KeyCode rightTurn;
    public KeyCode backward;
    public KeyCode up;
    public KeyCode down;
    public KeyCode fire;
    public KeyCode toggle;

    private Vector3 lastMouse;

    Vector3 baka;

    // Start is called before the first frame update
    void Start()
    {
        lastMouse = new Vector3(Screen.width/2, Screen.height/2, 0);
        Vector3 baka = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        //lastMouse = new Vector3(Mathf.Clamp(camControl.transform.eulerAngles.x + lastMouse.x, -camClamp.x, camClamp.x), Mathf.Clamp(camControl.transform.eulerAngles.y + lastMouse.y, -camClamp.y, camClamp.y), 0);
        
        Vector3 p = GetBaseInput();
        p = p * mainSpeed * Time.deltaTime;

        subMerse.transform.eulerAngles = new Vector3(subMerse.transform.eulerAngles.x, subMerse.transform.eulerAngles.y + p.x, subMerse.transform.eulerAngles.z);
<<<<<<< HEAD
        camControl.transform.eulerAngles = new Vector3(camControl.transform.eulerAngles.x, camControl.transform.eulerAngles.y + p.x, camControl.transform.eulerAngles.z);
=======
        // camRotateX = Mathf.Clamp(camControl.transform.eulerAngles.x + lastMouse.x, -camClamp.x, camClamp.x);
        // camRotateY = Mathf.Clamp(camControl.transform.eulerAngles.y + lastMouse.y, -camClamp.y, camClamp.y);

        lastMouse = new Vector3(camControl.transform.eulerAngles.x + lastMouse.x, camControl.transform.eulerAngles.y + lastMouse.y, 0);
        camControl.transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        baka = new Vector3(baka.x + (Input.GetAxis("Mouse Y") * mainRotMult), baka.y - (Input.GetAxis("Mouse X") * mainRotMult), 0);
        Vector3 buku = new Vector3(Mathf.Clamp(baka.x, -camClamp.x, camClamp.x), Mathf.Clamp(baka.y + subMerse.transform.eulerAngles.y, -camClamp.y + subMerse.transform.eulerAngles.y, camClamp.y + subMerse.transform.eulerAngles.y), camControl.transform.eulerAngles.z);
        
        camControl.transform.rotation = Quaternion.Euler(buku);


>>>>>>> ClampTest

        Vector3 q = new Vector3(0, p.y, p.z);
        subMerse.transform.Translate(q);
        subMerse.transform.position = new Vector3(Mathf.Clamp(subMerse.transform.position.x, -subClamp.x, subClamp.x), Mathf.Clamp(subMerse.transform.position.y, -subClamp.y, subClamp.y), Mathf.Clamp(subMerse.transform.position.z, -subClamp.z, subClamp.z));

        if((Mathf.Abs((camControl.transform.position.x - camRoot.transform.position.x) * (camControl.transform.position.y - camRoot.transform.position.y) * (camControl.transform.position.z - camRoot.transform.position.z)) <= lerpClamp))
        {
            camControl.transform.position = camRoot.transform.position;
        }
        else
        {
            camControl.transform.position = Vector3.Lerp(camControl.transform.position, camRoot.transform.position, Time.deltaTime * lerpSpeed);
        }
        

        if (Input.GetKeyDown(fire))
        {
            shootGun();
        }


    }

    public void OnEnable()
    {
        propPlacementSystem.enabled = false;
    }

    public void OnDisable()
    {
        propPlacementSystem.enabled = true;
    }

    public void shootGun()
    {
        if(attract)
        {
            Instantiate(foodPellet, fireNozzle.transform.position, camControl.transform.rotation);
        }
        else
        {
            Instantiate(repellant, fireNozzle.transform.position, camControl.transform.rotation);
        }
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
