﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords_Track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //AkSoundEngine.SetRTPCValue("Controller_Chords", 100);
        AkSoundEngine.PostEvent("VI_Chords01", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
