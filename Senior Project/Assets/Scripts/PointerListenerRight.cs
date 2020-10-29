using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class PointerListenerRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool _pressed = false;

    public float speed = -30f;
    public GameObject cameraRotator;
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
            cameraRotator.transform.Rotate(0, speed * Time.deltaTime, 0);
        }





    }
}
