using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToDeath : MonoBehaviour
{
    public float countDown = 8.0f;
    public GameObject thisThing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown = countDown - Time.deltaTime;

        if(countDown <= 0.0f)
        {
            Destroy(thisThing);
        }
    }
}
