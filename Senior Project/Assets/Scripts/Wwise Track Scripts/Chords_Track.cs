using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chords_Track : MonoBehaviour
{
    MetronomeScript meta;
    bool hasStarted;

    void Start()
    {
        meta = gameObject.GetComponent<MetronomeScript>();
    }

    void Update()
    {
        if (meta.Tick == true && hasStarted == false)
        {
            AkSoundEngine.PostEvent("VI_Chords01", gameObject);
            hasStarted = true;
        }
    }
}
