using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionInstantiate : MonoBehaviour
{
    private Vector3 targetPos;

    public Transform fish;
    public Vector3 rangeMax;
    public Vector3 rangeMin;

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
        targetPos = new Vector3(Random.Range(rangeMin.x, rangeMax.x), Random.Range(rangeMin.y, rangeMax.y), Random.Range(rangeMin.z, rangeMax.z));
        Instantiate(spawn, targetPos, transform.rotation);
        Debug.Log("Fish was spawned");
    }
}
