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
    public Rigidbody rb;
    public float timerForNewPos;
    bool InCoRoutine;
    Vector3 target;
    Vector3 fishScale;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fishScale = getRandSize();
        this.transform.localScale = fishScale;
    }

    Vector3 getRandSize()
    {
        float x = Random.Range(0.75f, 1.5f);
        float y = Random.Range(0.75f, 1.5f);

        Vector3 scale = new Vector3(x, y, 1);
        return scale;
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-4.5f, 4.5f);
        float y = Random.Range(-4.5f, 4.5f);
        float z = Random.Range(-4.5f, 4.5f);

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
        rb.velocity = (target - transform.position).normalized * speed;
    }
    
    void Update()
    {
        if (!InCoRoutine)
            StartCoroutine(Coroutine());
    }

    
}
