using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float foxSpeed = 50.0f;
    public moving camMovSys;
    public gridPlaceScript CursorManager;

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
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += this.transform.forward * scroll * foxSpeed;
    }
}