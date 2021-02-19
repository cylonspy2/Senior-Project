using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//VI_Cowbell01
//VI_Cowbell02
//VI_BassDrum01
//VI_BassDrum02 There are two BassDrum01 scripts Bass_Track && BDrum_Track
//VI_Chords01
//VI_Cymbal01
//VI_SnareDrum01
//VI_Solo01

public class Overlord_Music : MonoBehaviour
{
    public MetronomeScript meta;
    bool hasStarted = false;
    public string selectedMusic;
    string disableMusic;

    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        meta = manager.GetComponent<MetronomeScript>();
    }

    void Update()
    {
        if (meta.Tick == true && hasStarted == false)
        {
            AkSoundEngine.PostEvent(selectedMusic, gameObject);
            hasStarted = true;
        }

    }

    void OnDisable()
    {
        disableMusic = "reset_" + selectedMusic;
        AkSoundEngine.PostEvent(disableMusic, gameObject);
        Debug.Log("PrintOnDisable: script was disabled");
    }

}
