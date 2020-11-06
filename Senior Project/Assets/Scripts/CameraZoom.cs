using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minFOV;
    public float maxFOV;
    public float foxSpeed = 10f;

    

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
        
        initialFOV -= Input.GetAxis("Mouse ScrollWheel")*foxSpeed;
        //Debug.Log(initialFOV);
        initialFOV = Mathf.Clamp(initialFOV, minFOV, maxFOV);
        cam.fieldOfView = initialFOV;

    }

    
    
}
