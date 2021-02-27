using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MovementTwo.allTarget = transform.position;
        MovementTwo.timerForNewPos = -1f;
    }

    void OnDestroy()
    {
        MovementTwo.timerForNewPos = 5f;
    }

    void OnCollisionEnter(Collision collision)
    {
        //check for collider with tag "fish" then destroy the "food"
        //the static variable for timerForNewPos should have a static and local version
        //static overrides local one
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
