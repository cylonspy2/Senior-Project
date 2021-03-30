using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPass_Control : MonoBehaviour
{
    public float lowPVal;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lowPVal = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("LowPass_Control", lowPVal);
        Debug.Log("The amount of reverb was set to: " + lowPVal);
    }
}