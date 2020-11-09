using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// rename this class to suit your needs
public class SpawnDecoration : MonoBehaviour
{
    // the Equip prefab - required for instantiation
    public GameObject DecorationPlaceholder;

    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();

    private Vector3 targetPos;

    void Start()
    {
        
    }

    public void CreateObject()
    {
        // a prefab is need to perform the instantiation
        if (DecorationPlaceholder != null)
        {

            // instantiate the object
            targetPos = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f));

            GameObject go = (GameObject)Instantiate(DecorationPlaceholder, targetPos, Quaternion.identity);
            createdObjects.Add(go);

        }
    }
}