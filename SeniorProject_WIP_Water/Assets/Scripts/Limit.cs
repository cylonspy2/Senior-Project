using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        if (currentRotation.x <= 0)
        {
            currentRotation.x = 0;
        } 
        else if(currentRotation.x >= 30)
        {
            currentRotation.x = 30;
        }
        transform.localRotation = Quaternion.Euler(currentRotation);


    }
}
