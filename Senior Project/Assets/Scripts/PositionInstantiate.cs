using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInstantiate : MonoBehaviour
{
    private Vector3 targetPos;

    public Transform fish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fish(GameObject spawn)
    {
        targetPos = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f));
        Instantiate(spawn, targetPos, transform.rotation);
        Debug.Log("Fish was spawned");
    }
}
