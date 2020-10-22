using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalX(button1, -376, 2).setEaseInOutBack();
        LeanTween.moveLocalX(button2, -376, 2.5f).setEaseInOutBack();
        LeanTween.moveLocalX(button3, -376, 3f).setEaseInOutBack();
        LeanTween.moveLocalX(button4, -376, 3.5f).setEaseInOutBack();
        LeanTween.moveLocalX(button5, -376, 4f).setEaseInOutBack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bigger()
    {
        LeanTween.scale(button1, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setEaseLinear();
    }
    public void Bigger2()
    {
        LeanTween.scale(button2, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setEaseLinear();
    }
    public void Bigger3()
    {
        LeanTween.scale(button3, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setEaseLinear();
    }
    public void Bigger4()
    {
        LeanTween.scale(button4, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setEaseLinear();
    }
    public void Bigger5()
    {
        LeanTween.scale(button5, new Vector3(1.25f, 1.25f, 1.25f), 0.5f).setEaseLinear();
    }
    public void Smaller()
    {
        LeanTween.scale(button1, new Vector3(1, 1, 1), 0.5f).setEaseLinear();
    }
    public void Smaller2()
    {
        LeanTween.scale(button2, new Vector3(1, 1, 1), 0.5f).setEaseLinear();
    }
    public void Smaller3()
    {
        LeanTween.scale(button3, new Vector3(1, 1, 1), 0.5f).setEaseLinear();
    }
    public void Smaller4()
    {
        LeanTween.scale(button4, new Vector3(1, 1, 1), 0.5f).setEaseLinear();
    }
    public void Smaller5()
    {
        LeanTween.scale(button5, new Vector3(1, 1, 1), 0.5f).setEaseLinear();
    }
}
