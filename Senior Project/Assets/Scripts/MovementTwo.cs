using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Specialized;

public class MovementTwo : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float timerForNewPos;
    public float visionDistance;
    public Rigidbody rb;
    bool InCoRoutine;
    Vector3 target;
    public float xa = 4.5f;
    public float ya = 4.5f;
    public float za = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    Vector3 getNewRandomPosition()
    {
        float xb = xa * -1;
        float yb = ya * -1;
        float zb = za * -1;

        float x = Random.Range(xb, xa);
        float y = Random.Range(yb, ya);
        float z = Random.Range(zb, za);

        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    IEnumerator Coroutine()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPos);
        // get the new path
        getNewPath();
        
        InCoRoutine = false;

    }

    void getNewPath()
    {
        target = getNewRandomPosition();
        rb.velocity = (target - transform.position).normalized*speed;
        rb.transform.LookAt(target);

        RaycastHit hit;
        Ray DetectRay = new Ray(transform.position, Vector3.forward);
        
        if(Physics.Raycast(DetectRay, out hit, visionDistance) == true)
        {
            InCoRoutine = false;
        }
    }
    
    void Update()
    {
        if (Input.GetKey (KeyCode.Keypad1))
            xa += -0.05f;

        if (Input.GetKey (KeyCode.Keypad2))
            xa += 0.05f;

        if (Input.GetKey (KeyCode.Keypad4))
            za += -0.05f; 

        if (Input.GetKey (KeyCode.Keypad5))
            za += 0.05f;

        if (!InCoRoutine)
            StartCoroutine(Coroutine());

        
        
    }

    
}
