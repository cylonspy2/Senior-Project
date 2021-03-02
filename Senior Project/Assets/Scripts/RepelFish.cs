using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelFish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MovementTwo.allTarget = transform.position;
        MovementTwo.repel = true;
    }

    void OnDestroy()
    {
        MovementTwo.repel = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
