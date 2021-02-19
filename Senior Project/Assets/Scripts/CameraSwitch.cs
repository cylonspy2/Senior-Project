using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject UI_Bottom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            
            maincamera.GetComponent<FlyCamera>().enabled = false;
            maincamera.GetComponent<CameraZoom>().enabled = true;
            maincamera.GetComponent<moving>().enabled = true;

            UI_Bottom.SetActive(true);

            

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            maincamera.GetComponent<FlyCamera>().enabled = true;
            maincamera.GetComponent<CameraZoom>().enabled = false;
            maincamera.GetComponent<moving>().enabled = false;

            UI_Bottom.SetActive(false);
        }
    }
    

}
    
