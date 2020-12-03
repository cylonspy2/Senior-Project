using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Keypad0))
        { 
            gameObject.transform.localScale += new Vector3 (-0.05f, 0.0f, 0.0f);
        } 
        if (Input.GetKey (KeyCode.Keypad1))
        { 
            gameObject.transform.localScale += new Vector3 (0.05f, 0.0f, 0.0f);
        }
        if (Input.GetKey (KeyCode.Keypad4))
        { 
            gameObject.transform.localScale += new Vector3 (0.0f, 0.0f, -0.05f);
        } 
        if (Input.GetKey (KeyCode.Keypad5))
        { 
            gameObject.transform.localScale += new Vector3 (0.0f, 0.0f, 0.05f);
        }
        /*if (Input.GetKeyDown("Keypad0")) 
        {
            GameObject.transform.localScale.x += new Vector3(-0.01f, 0.0f, 0.0f) * Time.deltaTime;
        }*/
    }
}
