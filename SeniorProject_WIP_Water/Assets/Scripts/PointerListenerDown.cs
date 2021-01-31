using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class PointerListenerDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool _pressed = false;

    public float speed = -30f;
    public GameObject cameraRotator;



    void Start()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (_pressed)
        {
            cameraRotator.transform.Rotate(speed * Time.deltaTime, 0, 0);
        }





    }
}
