using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowbell1_Track : MonoBehaviour
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
            AkSoundEngine.PostEvent("VI_Cowbell02", gameObject);
            hasStarted = true;
        }
    }
}
