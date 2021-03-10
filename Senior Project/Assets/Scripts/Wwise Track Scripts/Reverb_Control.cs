using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverb_Control : MonoBehaviour
{
    public float verbVal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verbVal = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("Reverb_Control", verbVal);
        Debug.Log("The amount of reverb was set to: " + verbVal);
    }
}
