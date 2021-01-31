using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cymbal_Track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] CymbalCheck = new GameObject[0];
        if (GameObject.FindGameObjectsWithTag("Cymbal01") != CymbalCheck)
        {
            //AkSoundEngine.SetRTPCValue("Controller_Cymbal", 100);
            AkSoundEngine.PostEvent("VI_Cymbal01", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
