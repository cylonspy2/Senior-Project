using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SpawnDecoration : MonoBehaviour
{
    public GameObject Cursor;
    private GameObject CurrProp;
    public GameObject sample_1;
    public GameObject sample_2;
    public GameObject sample_3;
    public GameObject sample_4;
    public GameObject sample_5;
    public GameObject sample_6;
    public float heightAdjust;

    public GameObject camera_1;
    public GameObject camera_2;
    public GameObject camera_3;

    // list that holds all created objects - enables deleting all instances
    public List<GameObject> createdObjects = new List<GameObject>();

    private Vector3 targetPos;

    void Start()
    {
        
    }
  

    private void Update()
    {
        //CurrProp = sample_1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera_1.SetActive(true);
            camera_2.SetActive(false);
            camera_3.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera_1.SetActive(false);
            camera_2.SetActive(true);
            camera_3.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera_1.SetActive(false);
            camera_2.SetActive(false);
            camera_3.SetActive(true);

        }
    }

    //switches which prop to place
    public void PrepProp(GameObject i)
    {
        CurrProp = i;
        
    }

    //instantiate's the prop
    public void CreateProp()
    {
        if (CurrProp != null)
        {
            if (!IsPointerOverUIObject())
            {
                //avoids prop clutter but only allows two props total, still not right
                if (createdObjects.Count >= 2)
                {
                    GameObject oldProp = createdObjects[createdObjects.Count - 2];
                    if (oldProp.tag == CurrProp.tag)
                    {
                        createdObjects.Remove(oldProp);
                        Destroy(oldProp);
                        Debug.Log("Old prop destroyed and removed from list of gameobjects");
                    }
                    
                }
                targetPos = new Vector3(Cursor.transform.position.x, Cursor.transform.position.y + heightAdjust, Cursor.transform.position.z);

                GameObject go = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjects.Add(go);

            }
        }

        
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    public void TurnOn_Antenna()
    {
        CurrProp = sample_1;
    }

    public void TurnOn_Coral()
    {
        CurrProp = sample_2;
    }

    public void TurnOn_Metronome()
    {
        CurrProp = sample_3;
    }

    public void TurnOn_Oyster()
    {
        CurrProp = sample_4;
    }

    public void TurnOn_PirateShip()
    {
        CurrProp = sample_5;
    }

    public void TurnOn_PirateSkull()
    {
        CurrProp = sample_6;
    }

    public void SwitchToFish()
    {
        CurrProp = null;
    }

    

    
}