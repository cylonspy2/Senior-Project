using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRot : MonoBehaviour
{
    public GameObject rol;
    public GameObject targe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targe.transform.position = new Vector3(rol.transform.position.x, rol.transform.position.y, rol.transform.position.z);
        targe.transform.eulerAngles = new Vector3(0, rol.transform.eulerAngles.y, rol.transform.eulerAngles.z);
    }
}
