using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDrum_Track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AkSoundEngine.SetRTPCValue("Controller_BDrum", 100);
        AkSoundEngine.PostEvent("VI_BassDrum01", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
