using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnDecoration : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject CurrProp;
    public float heightAdjust;

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
            targetPos = new Vector3(Cursor.transform.position.x, Cursor.transform.position.y + heightAdjust, Cursor.transform.position.z);

            GameObject go = (GameObject)Instantiate(CurrProp, targetPos, Quaternion.identity);
            createdObjects.Add(go);
        }
    }
}