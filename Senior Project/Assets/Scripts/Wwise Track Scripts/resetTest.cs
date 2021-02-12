using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("reset_All", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
