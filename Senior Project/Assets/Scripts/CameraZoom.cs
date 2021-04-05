using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float defaultFOV;
    public float minFOV;
    public float maxFOV;
    public float foxSpeed = 10f;
    public moving camMovSys;
    public gridPlaceScript CursorManager;
    public float zoomSize;

    private Camera cam;
    private float initialFOV;
    public float initialZOOM;
    public float minZOOM;
    public float maxZOOM;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        cam.fieldOfView = defaultFOV;
        initialFOV = cam.fieldOfView;

    }

    // Update is called once per frame
    void Update()
    {
        if (!camMovSys.isFollowing)
        {
            initialZOOM -= Input.GetAxis("Mouse ScrollWheel") * foxSpeed;
            //Debug.Log(initialFOV);
            initialZOOM = Mathf.Clamp(initialZOOM, minZOOM, maxZOOM);
            initialFOV = defaultFOV;
            camMovSys.startPos = new Vector3(camMovSys.startPos.x, camMovSys.startPos.y, Mathf.Clamp(initialZOOM, minZOOM, maxZOOM));
            cam.fieldOfView = Mathf.Clamp(initialFOV, minFOV, maxFOV);
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
