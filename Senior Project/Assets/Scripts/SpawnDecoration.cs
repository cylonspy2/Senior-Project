using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnDecoration : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject CurrProp;

    // list that holds all created objects - enables deleting all instances
    public List<GameObject> createdObjects = new List<GameObject>();

    private Vector3 targetPos;

    void Start()
    {

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
            targetPos = Cursor.transform.position;

            GameObject go = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
            createdObjects.Add(go);
        }
    }
}