using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solo_Track : MonoBehaviour
{
    public MetronomeScript meta;
    bool hasStarted = false;

    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        //AkSoundEngine.PostEvent("VI_Solo01", gameObject);
        meta = manager.GetComponent<MetronomeScript>();
    }

    void Update()
    {
        if (meta.Tick == true && hasStarted == false)
        {
            print("The sound has started!");
            AkSoundEngine.PostEvent("VI_Solo01", gameObject);
            hasStarted = true;
        }
    }
}
