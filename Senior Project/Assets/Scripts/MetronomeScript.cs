using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeScript : MonoBehaviour
{
    public float count = 0.49f;
    public bool Tick = true;
    public float baka = 0f;
    public float tickGap = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        baka = count;
    }

    void Update()
    {
        baka = baka - Time.deltaTime;
        if (baka <= 0f){
            Tick = true;
        }
        else
            {
        Tick = false;
        }

        if(baka <= count - (count + tickGap))
        {
            baka = count;
        }
    }


}
