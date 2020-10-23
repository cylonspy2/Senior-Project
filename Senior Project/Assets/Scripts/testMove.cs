using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Specialized;

public class testMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float timerforNewPath;
    bool InCoRoutine;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);
        float z = Random.Range(-10f, 10f);

        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    // Update is called once per frame
    IEnumerator Coroutine()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(timerforNewPath);
        // get the new path
        getNewPath();
        InCoRoutine = false;

    }

    void getNewPath()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }
    
    void Update()
    {
        if (!InCoRoutine)
            StartCoroutine(Coroutine());
    }

}
