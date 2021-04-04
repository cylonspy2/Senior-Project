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
    public KeyCode mouseMov;
    public bool Mov;
    private Vector3 previousPos;
    private Quaternion prevCamRot;
    private Vector3 prevCamPos;

    public bool isFollowing;

    public KeyCode followMov;
    public gridPlaceScript selectMov;
    // Start is called before the first frame update


    void Start()
    {
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mov)
        {

            Vector3 direction = new Vector3(); //default value is (0,0,0)
            if (Input.GetKeyDown(mouseMov))
            {
                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
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
                //cam.transform.position = target.position;

                cam.transform.position = target.position;

                direction = previousPos - cam.ScreenToViewportPoint(Input.mousePosition);

                cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
                cam.transform.Rotate(new Vector3(x: 0, y: -1, z: 0), angle: direction.x * 180, relativeTo: Space.World);
                cam.transform.Translate(startPos);

                previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else
            {
                if ((Mathf.Abs(Vector3.Distance(cam.transform.position, target.position)) <= lerpClamp))
                {
                    cam.transform.position = target.position;
                    cam.transform.Translate(startPos, Space.Self);
                }
                else
                {
                    cam.transform.position = Vector3.Lerp(cam.transform.position, target.position, Time.deltaTime * lerpSpeed);
                }

                //cam.transform.position = target.position;

                //vector3.Lerp(cam.transform.position, startPos, Time.deltaTime * lerpSpeed);
                cam.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), angle: direction.y * 180);
                cam.transform.Rotate(new Vector3(x: 0, y: -1, z: 0), angle: direction.x * 180, relativeTo: Space.World);
            }

            previousPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
