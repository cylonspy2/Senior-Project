using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float lerpSpeed;
    public float lerpClamp;

    public Camera cam;
    public Transform target;
    //public Transform target;
    public Vector3 startPos;
    public KeyCode mouseMov, forward, left, right, back;
    public bool Mov;
    private Vector3 previousPos;
    private Quaternion prevCamRot;
    private Vector3 prevCamPos;

    public bool isFollowing;

    public KeyCode followMov;
    public gridPlaceScript selectMov;

    public float mainSpeed = 100.0f; //regular speed
    public float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)

    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
        lastMouse = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;


        if (Mov)
        {


            Vector3 direction = GetBaseInput();
            // if (Input.GetKeyDown(mouseMov))
            // {
            //     previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            // }
            if (Input.GetKeyDown(followMov))
            {
                isFollowing = true;
                Debug.Log("CamAcknowledgingTarget");
                prevCamRot = cam.transform.rotation;
                prevCamPos = cam.transform.position;
            }
            else if(Input.GetKey(followMov))
            {
                Debug.Log("CamFollowingTarget");
                switch(selectMov.choice)
                {
                    case 0:
                        cam.transform.LookAt(selectMov.selectedPhish.transform.position, Vector3.up);
                        break;
                    case 1:
                        cam.transform.LookAt(selectMov.selectedObj.transform.position);
                        break;
                }
            }
            else if(Input.GetKeyUp(followMov))
            {
                isFollowing = false;
                Debug.Log("CamResettingCamera");
                cam.transform.position = prevCamPos;
                cam.transform.rotation = prevCamRot;

            }
            else if (Input.GetKey(mouseMov))
            {
                cam.transform.position = target.position;

                //cam.transform.position = target.position;

                direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);

                cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
                cam.transform.Rotate(new Vector3(x: 0, y: -1, z: 0), angle: direction.x * 180, relativeTo: Space.World);
                cam.transform.Translate(startPos);

                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else
            {
                
                direction = direction * mainSpeed;
                direction = direction * Time.deltaTime;
                Vector3 newPosition = transform.position;
                // if ((Mathf.Abs(Vector3.Distance(cam.transform.position, target.position)) <= lerpClamp))
                // {
                //     cam.transform.position = target.position;
                //     cam.transform.Translate(startPos, Space.Self);
                // }
                // else
                // {
                //     cam.transform.position = Vector3.Lerp(cam.transform.position, target.position, Time.deltaTime * lerpSpeed);
                // }

                // //cam.transform.position = target.position;

                // //vector3.Lerp(cam.transform.position, startPos, Time.deltaTime * lerpSpeed);
                // cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
                // cam.transform.Rotate(new Vector3(x: 0, y: -1, z: 0), angle: direction.x * 180, relativeTo: Space.World);
            }

            //previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            transform.Translate(direction);
        }

    }
    
    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(forward))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(back))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(left))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(right))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
