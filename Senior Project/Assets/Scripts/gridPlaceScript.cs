using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridPlaceScript : MonoBehaviour
{
    public bool isGridPlace = true;

    public GameObject cursorVisualise;
    public GameObject[] gridTargets;
    public GameObject freePlaceFloor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGridPlace)
        {
            GameObject selectedTarget;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject i in gridTargets)
                {
                    if (hit.transform == i.transform)
                    {
                        cursorVisualise.SetActive(true);
                        if (cursorVisualise != null)
                        {
                            cursorVisualise.transform.position = new Vector3(i.transform.position.x, cursorVisualise.transform.position.y, i.transform.position.z);
                        }
                        break;
                    }
                    else
                    {
                        selectedTarget = gridTargets[0];
                        if (cursorVisualise != null)
                        {
                            cursorVisualise.SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == freePlaceFloor.transform)
                {
                    cursorVisualise.SetActive(true);
                    if (cursorVisualise != null)
                    {
                        cursorVisualise.transform.position = new Vector3(hit.point.x, cursorVisualise.transform.position.y, hit.point.z);
                    }
                }
            }
            else
            {
                cursorVisualise.SetActive(false);
            }
        }
    }
}
