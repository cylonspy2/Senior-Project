using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewPausedMenu : MonoBehaviour
{
    public GameObject pausedUI;

    private bool isPaused;

    public Slider Volume;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
            ActivateMenu();
        }
        else
        {
            Time.timeScale = 1f;
            DeactiveMenu();
        }

        AkSoundEngine.SetRTPCValue("Master_Volume_Control", Volume.value * 100);

        Debug.Log("currentvolume" + Volume.value);
    }

    public void ActivateMenu()
    {
        
        pausedUI.SetActive(true);
    }

    public void DeactiveMenu()
    {
        
        pausedUI.SetActive(false);
        isPaused = false;
    }
}
