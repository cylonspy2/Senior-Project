using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gridPlaceScript : MonoBehaviour
{
    public SpawnDecoration SpawnManager;
    public KeyCode spawnKey;
    public KeyCode targetKey;
    public KeyCode deleteKey;
    public float countDown;
    float currCountDown;

    public bool isGridPlace = true;

    public GameObject cursorVisualise;
    public GameObject[] gridTargets;
    public GameObject freePlaceFloor;

    [Header("PubAccessVariables")]

    public int choice;
    
    public GameObject selectedObj;
    
    public GameObject selectedPhish;
    
    public GameObject selectedPhishMaster;

    // Start is called before the first frame update
    void Start()
    {
        currCountDown = countDown;
        selectedObj = new GameObject();
        selectedPhish = new GameObject();
        selectedPhishMaster = new GameObject();
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
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 4;
            layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
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
                    currCountDown = countDown;
                }
            }
            else
            {
                cursorVisualise.SetActive(false);
            }


        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            print(Input.mousePosition);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << 4;
            layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                string baka = hit.transform.gameObject.tag;
                if (hit.transform.gameObject.tag == "Fish1" && Input.GetKeyDown(targetKey))
                {
                    GameObject phish = hit.transform.gameObject;
                    GameObject phishMaster = phish.transform.parent.gameObject;

                    Debug.Log("FIIIIIISH");

                    selectedPhish = phish;
                    selectedPhishMaster = phishMaster;
                    choice = 0;
                }
                else if ((baka == "Antenna" || baka == "Coral" || baka == "Metronome" || baka == "Oyster" || baka == "PirateShip" || baka == "PirateSkull") && Input.GetKeyDown(targetKey))
                {
                    GameObject OObj = hit.transform.gameObject;

                    selectedObj = OObj;
                    choice = 1;
                }
                else if (hit.transform == freePlaceFloor.transform)
                {
                    cursorVisualise.SetActive(true);
                    if (cursorVisualise != null)
                    {
                        cursorVisualise.transform.position = new Vector3(hit.point.x, cursorVisualise.transform.position.y, hit.point.z);
                    }

                    if (Input.GetKey(spawnKey) && currCountDown <= 0f)
                    {
                        SpawnManager.CreateProp();
                        currCountDown = countDown;
                    }
                }
            }
            else
            {
                cursorVisualise.SetActive(false);
            }

            if (Input.GetKeyDown(deleteKey))
            {
                Debug.Log("RemovingTargettedThing");
                switch (choice)
                {
                    case 0:
                        Destroy(selectedPhishMaster);
                        break;

                    case 1:
                        //Destroy(selectedObj);

                        if (selectedObj == SpawnManager.oldProp)
                        {
                            
                            SpawnManager.DeleteOldProp();
                        }
                         if (selectedObj == SpawnManager.newProp) 
                        {
                            
                            SpawnManager.DeleteNewProp();
                        }
                         if(selectedObj == SpawnManager.oldPropCoral)
                        {
                            SpawnManager.DeleteOldPropCoral();
                        }
                         if (selectedObj == SpawnManager.newPropCoral)
                        {
                            ;
                            SpawnManager.DeleteNewPropCoral();
                        }
                        if (selectedObj == SpawnManager.oldPropMetronome)
                        {
                            SpawnManager.DeleteOldPropMetronome();
                        }
                        if (selectedObj == SpawnManager.newPropMetronome)
                        {
                            
                            SpawnManager.DeleteNewPropMetronome();
                        }
                        if (selectedObj == SpawnManager.oldPropOyster)
                        {

                            SpawnManager.DeleteOldPropOyster();
                        }
                        if (selectedObj == SpawnManager.newPropOyster)
                        {

                            SpawnManager.DeleteNewPropOyster();
                        }

                        if (selectedObj == SpawnManager.oldPropPirateShip)
                        {

                            SpawnManager.DeleteOldPropPirateShip();
                        }
                        if (selectedObj == SpawnManager.newPropPirateShip)
                        {

                            SpawnManager.DeleteNewPropPirateShip();
                        }
                        if (selectedObj == SpawnManager.oldPropPirateSkull)
                        {

                            SpawnManager.DeleteOldPropPirateSkull();
                        }
                        if (selectedObj == SpawnManager.newPropPirateSkull)
                        {

                            SpawnManager.DeleteNewPropPirateSkull();
                        }




                        break;
                }
            }
        }

        if(selectedObj == null)
        {
            selectedObj = new GameObject();

        }
        if (selectedPhish == null)
        {
            selectedPhish = new GameObject();
        }
        if (selectedPhishMaster == null)
        {
            selectedPhishMaster = new GameObject();
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
}
