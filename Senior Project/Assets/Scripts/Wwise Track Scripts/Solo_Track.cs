using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo_Track : MonoBehaviour
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
            AkSoundEngine.PostEvent("VI_Solo01", gameObject);
            hasStarted = true;
        }
    }
}
