using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject image1;
    public GameObject image2;
    

    public GameObject deletedUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("right");
            deletedUI.SetActive(false);

            image1.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
            image2.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
        }
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            image1.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            image2.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        }
    }
    
        
}
