using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOLD : MonoBehaviour
{
    public float minFOV;
    public float maxFOV;
    public float foxSpeed = 10f;
    public moving camMovSys;
    public gridPlaceScript CursorManager;
    public float zoomSize;

    private Camera cam;
    private float initialFOV;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        initialFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camMovSys.isFollowing)
        {
            initialFOV -= Input.GetAxis("Mouse ScrollWheel") * foxSpeed;
            //Debug.Log(initialFOV);
            initialFOV = Mathf.Clamp(initialFOV, minFOV, maxFOV);
            cam.fieldOfView = initialFOV;
        }
        else
        {
            float peep = minFOV;
            switch (CursorManager.choice)
            {
                case 0:
                    peep = maxFOV - (Vector3.Distance(cam.transform.position, CursorManager.selectedPhish.transform.position) / zoomSize);
                    break;
                case 1:
                    peep = maxFOV - (Vector3.Distance(cam.transform.position, CursorManager.selectedObj.transform.position) / zoomSize);
                    break;
            }
            cam.fieldOfView = Mathf.Clamp(peep, minFOV, maxFOV);
        }
    }

    
    
}
