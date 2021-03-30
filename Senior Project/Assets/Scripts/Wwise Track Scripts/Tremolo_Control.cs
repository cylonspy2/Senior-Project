using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremolo_Control : MonoBehaviour
{
    public float tremVal;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tremVal = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("Tremolo_Control", tremVal);
        Debug.Log("The master volume was set to: " + tremVal);
    }
}
