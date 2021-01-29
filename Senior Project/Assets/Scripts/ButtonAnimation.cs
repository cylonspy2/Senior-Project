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
    public GameObject button6;
    public float speed;
    public GameObject cameraRotator;
    public GameObject fishPopsUp;
    public GameObject dePopsUp;

    public GameObject pieces;
    public GameObject button_AddFish;
    public GameObject button_AddDe;
    public GameObject reload;
    public GameObject exit;

    public GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(button1, 400, 2).setEaseInOutBack();
        LeanTween.moveLocalY(button2, 400, 2.5f).setEaseInOutBack();
        LeanTween.moveLocalY(button3, 400, 3f).setEaseInOutBack();
        LeanTween.moveLocalY(button4, 400, 3.5f).setEaseInOutBack();
        LeanTween.moveLocalX(button5, -873, 4f).setEaseInOutBack();
        LeanTween.moveLocalX(button6, 893, 4f).setEaseInOutBack();

        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pieces.SetActive(false);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //   cameraRotator.transform.Rotate(0, speed * Time.deltaTime, 0);
    //}
    public void Bigger()
    {
        LeanTween.scale(button1, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void Bigger2()
    {
        LeanTween.scale(button2, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void Bigger3()
    {
        LeanTween.scale(button3, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void Bigger4()
    {
        LeanTween.scale(button4, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void Bigger5()
    {
        LeanTween.scale(button5, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void Smaller()
    {
        LeanTween.scale(button1, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void Smaller2()
    {
        LeanTween.scale(button2, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void Smaller3()
    {
        LeanTween.scale(button3, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void Smaller4()
    {
        LeanTween.scale(button4, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void Smaller5()
    {
        LeanTween.scale(button5, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void fishPopUpEnter()
    {
        fishPopsUp.SetActive(true);
    }
    public void fishPopUpLeave()
    {
        fishPopsUp.SetActive(false);
    }
    public void DePopUpEnter()
    {
        dePopsUp.SetActive(true);
    }
    public void DePopUpLeave()
    {
        dePopsUp.SetActive(false);
    }


    public void FishBigger()
    {
        LeanTween.scale(button_AddFish, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void FishSmaller()
    {
        LeanTween.scale(button_AddFish, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void DeBigger()
    {
        LeanTween.scale(button_AddDe, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void DeSmaller()
    {
        LeanTween.scale(button_AddDe, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void ReloadBigger()
    {
        LeanTween.scale(reload, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void ReloadSmaller()
    {
        LeanTween.scale(reload, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }
    public void ExitBigger()
    {
        LeanTween.scale(exit, new Vector3(1.25f, 1.25f, 1.25f), 0.2f).setEaseLinear();
    }
    public void ExitSmaller()
    {
        LeanTween.scale(exit, new Vector3(1, 1, 1), 0.2f).setEaseLinear();
    }

    public void CameraOn()
    {
        camera.GetComponent<moving>().enabled = true;
    }
    public void CameraOff()
    {
        camera.GetComponent<moving>().enabled = false;
    }







}
