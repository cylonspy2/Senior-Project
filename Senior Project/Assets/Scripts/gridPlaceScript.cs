using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridPlaceScript : MonoBehaviour
{
    public SpawnDecoration SpawnManager;
    public KeyCode spawnKey;
    public float countDown;
    float currCountDown;

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
        if(countDown != 0f && !(currCountDown <= 0f))
        {
            currCountDown = currCountDown - Time.deltaTime;
        }

        if (isGridPlace)
        {
            GameObject selectedTarget;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                bool hitt = false;
                foreach (GameObject i in gridTargets)
                {
                    if (hit.transform.gameObject == i)
                    {
                        cursorVisualise.SetActive(true);
                        cursorVisualise.transform.position = new Vector3(i.transform.position.x, cursorVisualise.transform.position.y, i.transform.position.z);
                        hitt = true;
                    }
                }
                if (Input.GetKey(spawnKey) && hitt == true && currCountDown <= 0f)
                {
                    SpawnManager.CreateProp();
                }
            }
            else
            {
                cursorVisualise.SetActive(false);
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

                    if (Input.GetKey(spawnKey) && currCountDown <= 0f)
                    {
                        SpawnManager.CreateProp();
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
