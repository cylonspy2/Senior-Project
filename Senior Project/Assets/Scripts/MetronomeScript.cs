using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeScript : MonoBehaviour
{
    float count = 0.5f;
    public bool Tick = true;
    float baka = 0;

    // Start is called before the first frame update
    void Start()
    {
        baka = count;
    }

    void Update()
    {
        if(baka == 0f){
            Tick = true;
            baka = count;
        }
        else
            {
        Tick = false;
        }

        baka = baka - Time.deltaTime; 

    }


}
