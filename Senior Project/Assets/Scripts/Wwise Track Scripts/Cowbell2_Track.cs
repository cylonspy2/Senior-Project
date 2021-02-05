using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowbell2_Track : MonoBehaviour
{
    MetronomeScript meta;
    bool hasStarted = false;

    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        //AkSoundEngine.PostEvent("VI_Cowbell02", gameObject);
        meta = manager.GetComponent<MetronomeScript>();
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
