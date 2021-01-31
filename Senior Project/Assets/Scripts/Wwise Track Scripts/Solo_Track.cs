using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo_Track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.SetRTPCValue("Controller_Solo", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
