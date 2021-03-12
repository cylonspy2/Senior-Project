using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishView : MonoBehaviour
{
    public gridPlaceScript manager;
    public Camera cam;
    public KeyCode activ;

    Vector3 jeef;
    Quaternion beef;

    GameObject fsh;
    GameObject camRoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fsh = manager.selectedPhish;
        foreach (Transform chld in fsh.transform)
        {
            if (chld.CompareTag("camRoot"))
            {
                camRoot = chld.gameObject;
            }
        }

        if (Input.GetKeyDown(activ))
        {
            jeef = cam.transform.position;
            beef = cam.transform.rotation;
        }
        if(Input.GetKey(activ))
        {
            cam.transform.position = camRoot.transform.position;
            cam.transform.rotation = camRoot.transform.rotation;
        }
        if (Input.GetKeyUp(activ))
        {
            cam.transform.position = jeef;
            cam.transform.rotation = beef;
        }

    }
}
