using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishView : MonoBehaviour
{
    public gridPlaceScript manager;
    public Camera cam;
    public KeyCode activ;

    public float lerpSpeed;
    float lerpCount;

    Vector3 jeef;
    Quaternion beef;

    GameObject fsh;
    GameObject camRoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.selectedPhish == null)
        {
            fsh = manager.selectedPhish;
        }
        else if(fsh == null)
        {
            fsh = new GameObject();
        }

        foreach (Transform chld in fsh.transform)
        {
            if (chld.CompareTag("camRoot"))
            {
                camRoot = chld.gameObject;
            }
        }

        if (Input.GetKeyDown(activ))
        {
            jeef = cam.transform.position;
            beef = cam.transform.rotation;
        }
        if(Input.GetKey(activ))
        {
            lerpCount = Mathf.Clamp(lerpCount + Time.deltaTime * lerpSpeed, 0, 1);
            cam.transform.position = Vector3.Lerp(jeef, camRoot.transform.position, lerpCount);
            cam.transform.rotation = Quaternion.Lerp(beef, camRoot.transform.rotation, lerpCount);
        }
        if (Input.GetKeyUp(activ))
        {
            lerpCount = 0;
            cam.transform.position = jeef;
            cam.transform.rotation = beef;
        }

    }
}
