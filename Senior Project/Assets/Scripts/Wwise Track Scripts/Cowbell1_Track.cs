using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowbell1_Track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetRTPCValue("Controller_Cowbell1", 100);
        AkSoundEngine.PostEvent("VI_Cowbell02", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
