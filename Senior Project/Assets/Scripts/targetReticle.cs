using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetReticle : MonoBehaviour
{
    public SpriteRenderer targImage;
    public GameObject targetRet;
    public GameObject camera;
    public gridPlaceScript selectionSys;
    public GameObject curTarget;
    public moving baka;
    public float offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

            switch (selectionSys.choice)
            {
                case 0:
                    curTarget = selectionSys.selectedPhish;
                    break;
                case 1:
                    curTarget = selectionSys.selectedObj;
                    break;
            }

        if(curTarget.name == "New Game Object")
        {
            curTarget = camera;
        }

        if(baka.enabled == false)
        {
            targImage.enabled = false;
        }
        else
        {
            targImage.enabled = true;
        }

        targetRet.transform.position = curTarget.transform.position;
        
        if(curTarget == camera)
        {
            targetRet.transform.rotation = curTarget.transform.rotation;
        }
        else
        {
            targetRet.transform.LookAt(camera.transform);
            targetRet.transform.Translate(new Vector3(0, 0, offset));
        }

    }
}
