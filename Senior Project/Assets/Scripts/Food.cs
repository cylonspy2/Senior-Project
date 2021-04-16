using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject thisThing;
    public float effectRange;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnDestroy()
    {
        GameObject[] area = GameObject.FindGameObjectsWithTag("fishTarg");
        foreach (GameObject buul in area)
        {
            buul.GetComponent<MovementTwo>().timerForNewPos = 5f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //check for collider with tag "fish" then destroy the "food"
        //the static variable for timerForNewPos should have a static and local version
        //static overrides local one

        Destroy(thisThing);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] withinRange = GameObject.FindGameObjectsWithTag("fishTarg");


        foreach (GameObject buul in withinRange)
        {
            float distSqr = (buul.transform.position - thisThing.transform.position).sqrMagnitude;

            if (distSqr <= effectRange)
            {
                buul.GetComponent<MovementTwo>().speed = 10f;
                buul.GetComponent<MovementTwo>().allTarget = thisThing.transform.position;
                buul.GetComponent<MovementTwo>().timerForNewPos = -1f;
            }
            else
            {
                buul.GetComponent<MovementTwo>().timerForNewPos = 5f;
            }
        }
    }
}
