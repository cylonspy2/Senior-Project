using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SpawnDecoration : MonoBehaviour
{
    public int maxPropEachKind = 2;
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

    public List<GameObject> createdObjectsCoral = new List<GameObject>();

    public List<GameObject> createdObjectsMetronome = new List<GameObject>();

    public List<GameObject> createdObjectsOyster = new List<GameObject>();

    public List<GameObject> createdObjectsPirateShip = new List<GameObject>();

    public List<GameObject> createdObjectsPirateSkull = new List<GameObject>();


    public GameObject oldProp;
    public GameObject newProp;
    public GameObject oldPropCoral;
    public GameObject newPropCoral;
    public GameObject oldPropMetronome;
    public GameObject newPropMetronome;
    public GameObject oldPropOyster;
    public GameObject newPropOyster;
    public GameObject oldPropPirateShip;
    public GameObject newPropPirateShip;
    public GameObject oldPropPirateSkull;
    public GameObject newPropPirateSkull;

    private Vector3 targetPos;

    void Start()
    {
        
    }
  

    void Update()

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
            if (EventSystem.current.IsPointerOverGameObject())
                return;

           
            //if (!IsPointerOverUIObject())
            // {
            //avoids prop clutter but only allows two props total, still not right


            if (createdObjects.Count >= maxPropEachKind)
                {
                //GameObject oldProp = createdObjects[createdObjects.Count - maxPropEachKind];
                //if (oldProp.tag == CurrProp.tag)
                //{
                RemoveProp();
                   // createdObjects.Remove(oldProp);
                   // Destroy(oldProp);
                   // Debug.Log("Old prop destroyed and removed from list of gameobjects");


                // }

            }
                if(createdObjectsCoral.Count >= maxPropEachKind)
            {
                RemovePropCoral();
            }
            if (createdObjectsMetronome.Count >= maxPropEachKind)
            {
                RemovePropMetronome();
            }
            if (createdObjectsOyster.Count >= maxPropEachKind)
            {
                RemovePropOyster();
            }
            if (createdObjectsPirateShip.Count >= maxPropEachKind)
            {
                RemovePropPirateShip();
            }
            if (createdObjectsPirateSkull.Count >= maxPropEachKind)
            {
                RemovePropPirateSkull();
            }





            targetPos = new Vector3(Cursor.transform.position.x, Cursor.transform.position.y + heightAdjust, Cursor.transform.position.z);
            //targetPos = new Vector3(Cursor.transform.position.x, Cursor.transform.position.y + heightAdjust, Cursor.transform.position.z);

            //GameObject go = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);

            if (CurrProp.tag == "Antenna") {

               

                GameObject go = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjects.Add(go);
                newProp = createdObjects[createdObjects.Count - 1];



                oldProp = createdObjects[createdObjects.Count - maxPropEachKind];
            }

            if (CurrProp.tag == "Coral")
            {

                GameObject goCoral = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjectsCoral.Add(goCoral);
                newPropCoral = createdObjectsCoral[createdObjectsCoral.Count - 1];


                oldPropCoral = createdObjectsCoral[createdObjectsCoral.Count - maxPropEachKind];
            }

            if (CurrProp.tag == "Metronome")
            {



                GameObject goMetronome = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjectsMetronome.Add(goMetronome);
                newPropMetronome = createdObjectsMetronome[createdObjectsMetronome.Count - 1];



                oldPropMetronome = createdObjectsMetronome[createdObjectsMetronome.Count - maxPropEachKind];
            }

            if (CurrProp.tag == "Oyster")
            {



                GameObject goOyster = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjectsOyster.Add(goOyster);
                newPropOyster = createdObjectsOyster[createdObjectsOyster.Count - 1];



                oldPropOyster = createdObjectsOyster[createdObjectsOyster.Count - maxPropEachKind];
            }

            if (CurrProp.tag == "PirateShip")
            {



                GameObject goPirateShip = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjectsPirateShip.Add(goPirateShip);
                newPropPirateShip = createdObjectsPirateShip[createdObjectsPirateShip.Count - 1];



                oldPropPirateShip = createdObjectsPirateShip[createdObjectsPirateShip.Count - maxPropEachKind];
            }

            if (CurrProp.tag == "PirateSkull")
            {



                GameObject goPirateSkull = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
                createdObjectsPirateSkull.Add(goPirateSkull);
                newPropPirateSkull = createdObjectsPirateSkull[createdObjectsPirateSkull.Count - 1];



                oldPropPirateSkull = createdObjectsPirateSkull[createdObjectsPirateSkull.Count - maxPropEachKind];
            }



            //createdObjects.Add(go);
            //Debug.Log("calledcalled");

            //}
        }

        
    }

    public void DeleteNewProp()
    {
        
        createdObjects.Remove(newProp);
        Destroy(newProp);
    }

    public void RemoveProp()
    {
         
        


        if (oldProp.tag == CurrProp.tag)
        {

            createdObjects.Remove(oldProp);
            Destroy(oldProp);
            


        }
    }

    public void DeleteOldProp()
    {
        createdObjects.Remove(oldProp);
        Destroy(oldProp);
    }

    public void DeleteNewPropCoral()
    {
        
        createdObjectsCoral.Remove(newPropCoral);
        Destroy(newPropCoral);
    }

    public void RemovePropCoral()
    {
        // oldProp = createdObjects[createdObjects.Count - maxPropEachKind];

        

        if (oldPropCoral.tag == CurrProp.tag)
        {

            createdObjectsCoral.Remove(oldPropCoral);
            Destroy(oldPropCoral);
            Debug.Log("Old prop destroyed and removed from list of gameobjects");


        }
    }

    public void DeleteOldPropCoral()
    {
        createdObjectsCoral.Remove(oldPropCoral);
        Destroy(oldPropCoral);
    }

    public void DeleteNewPropMetronome()
    {
        createdObjectsMetronome.Remove(newPropMetronome);
        Destroy(newPropMetronome);
    }

    public void RemovePropMetronome()
    {
        if (oldPropMetronome.tag == CurrProp.tag)
        {

            createdObjectsMetronome.Remove(oldPropMetronome);
            Destroy(oldPropMetronome);



        }
    }

    public void DeleteOldPropMetronome()
    {
        createdObjectsMetronome.Remove(oldPropMetronome);
        Destroy(oldPropMetronome);
    }

    public void DeleteNewPropOyster()
    {
        createdObjectsOyster.Remove(newPropOyster);
        Destroy(newPropOyster);
    }

    public void RemovePropOyster()
    {
        if (oldPropOyster.tag == CurrProp.tag)
        {

            createdObjectsOyster.Remove(oldPropOyster);
            Destroy(oldPropOyster);



        }
    }
    public void DeleteOldPropOyster()
    {
        createdObjectsOyster.Remove(oldPropOyster);
        Destroy(oldPropOyster);
    }

    public void DeleteNewPropPirateShip()
    {
        createdObjectsPirateShip.Remove(newPropPirateShip);
        Destroy(newPropPirateShip);
    }

    public void RemovePropPirateShip()
    {
        if (oldPropPirateShip.tag == CurrProp.tag)
        {

            createdObjectsPirateShip.Remove(oldPropPirateShip);
            Destroy(oldPropPirateShip);



        }
    }

    public void DeleteOldPropPirateShip()
    {
        createdObjectsPirateShip.Remove(oldPropPirateShip);
        Destroy(oldPropPirateShip);
    }

    public void DeleteNewPropPirateSkull()
    {
        createdObjectsPirateSkull.Remove(newPropPirateSkull);
        Destroy(newPropPirateSkull);
    }

    public void RemovePropPirateSkull()
    {
        if (oldPropPirateSkull.tag == CurrProp.tag)
        {

            createdObjectsPirateSkull.Remove(oldPropPirateSkull);
            Destroy(oldPropPirateSkull);



        }
    }

    public void DeleteOldPropPirateSkull()
    {
        createdObjectsPirateSkull.Remove(oldPropPirateSkull);
        Destroy(oldPropPirateSkull);
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