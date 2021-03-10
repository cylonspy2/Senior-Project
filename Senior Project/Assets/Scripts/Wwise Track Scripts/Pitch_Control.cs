using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch_Control : MonoBehaviour
{
    public float pitchVal;

    void Start()
    {
        
    }

    // Update is called once per frame
    // it appears that pitch in wise, speeds up/slows down the tracks LUL
    void Update()
    {
        pitchVal = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("Pitch_Control", pitchVal);
        Debug.Log("The pitch value was set to: " + pitchVal);
    }
}
