using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeVis : MonoBehaviour
{
    public MetronomeScript meta;
    public GameObject Indicator;
    public ParticleSystem bily;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(meta.Tick)
        {
            bily.Play();
        }else
        {
            bily.Stop();
        }

        Indicator.SetActive(meta.Tick);
    }
}
