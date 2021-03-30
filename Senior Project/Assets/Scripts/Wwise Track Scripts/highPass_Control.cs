using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highPass_Control : MonoBehaviour
{
    public float highPVal;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highPVal = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("HighPass_Control", highPVal);
        Debug.Log("The amount of reverb was set to: " + highPVal);
    }
}

