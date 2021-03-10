using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Control : MonoBehaviour
{
    public float pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position.x + 50;

        AkSoundEngine.SetRTPCValue("Volume_Control", pos);
        Debug.Log("The master volume was set to: " + pos);
    }
}
