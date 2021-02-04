using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject sideCamera_1;
    public GameObject sideCamera_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainOn()
    {
        maincamera.GetComponent<Camera>().enabled = true;
        sideCamera_1.SetActive(false);
        sideCamera_2.SetActive(false);

    }
    public void Side1On()
    {
        maincamera.GetComponent<Camera>().enabled = false;
        sideCamera_1.SetActive(true);
        sideCamera_2.SetActive(false);

    }
    public void Side2On()
    {
        maincamera.GetComponent<Camera>().enabled = false;
        sideCamera_1.SetActive(false);
        sideCamera_2.SetActive(true);

    }
}
