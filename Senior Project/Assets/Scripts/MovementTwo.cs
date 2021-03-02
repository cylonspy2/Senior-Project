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
    static public float timerForNewPos = 5f;
    public float visionDistance;
    public Rigidbody rb;
    bool InCoRoutine;
    public Vector3 target;
    static public Vector3 allTarget;
    public float xa;
    public float ya;
    public float za;
    public float targetTime = 5f;
    static public bool repel;
    private float minRange = 5f;
    private float distanceToTarget;

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
        while(true){
            InCoRoutine = true;
            print("timerForNewPos = " + timerForNewPos);
            if (timerForNewPos < 0f) { //if food in tank go to food
                target = allTarget;
                setNewPath();
                yield return new WaitForSeconds(targetTime);
                timerForNewPos = targetTime;
            } else if (repel == true) { //if repel avoid the object
                print("Repel is set to = " + repel);
                target = getNewRandomPosition();
                distanceToTarget = Vector3.Distance(target, allTarget);
                bool tooClose = distanceToTarget < minRange;
                yield return new WaitForSeconds(targetTime);
                if (tooClose != true) {
                    setNewPath();
                } else { // behave normally
                    yield return new WaitForSeconds(timerForNewPos);
                    target = getNewRandomPosition();
                    setNewPath();
                }
            } else { //if anything else just do normal behavior
                yield return new WaitForSeconds(timerForNewPos);
                target = getNewRandomPosition();
                // get the new path
                setNewPath();
            }
        }
        //InCoRoutine = false;

    }

    void setNewPath()
    {
        //target = getNewRandomPosition();
        rb.velocity = (target - transform.position).normalized*speed;
        rb.transform.LookAt(target);

        RaycastHit hit;
        Ray DetectRay = new Ray(transform.position, Vector3.forward);
        
        if(Physics.Raycast(DetectRay, out hit, visionDistance) == true)
            InCoRoutine = false;
    }
    
    void Update()
    {
        
        if (!InCoRoutine)
            StartCoroutine(Coroutine());

        
        
    }

    
}
