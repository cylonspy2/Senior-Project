using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    private float masterVolume=0f;

    AudioSource music1;
    // Start is called before the first frame update
    void Start()
    {
        music1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] fish = GameObject.FindGameObjectsWithTag("Fish1");
        float numOfFish = fish.Length;

        //Debug.Log(numOfFish);

        masterVolume = numOfFish / 10;
        Debug.Log(masterVolume);

        if (numOfFish >= 10)
        {
            numOfFish = 10;
        }

        music1.volume = masterVolume;
    }
}
