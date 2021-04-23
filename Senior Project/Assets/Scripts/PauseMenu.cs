using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;
    public GameObject mainCamera;

    private float time=1f;
    private float cameraStance=1f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraStance = 1f;
            Debug.Log(cameraStance);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraStance = 2f;
            Debug.Log(cameraStance);
        }

        Time.timeScale = time;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            

            if (GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        time = 1f;
        GameIsPaused = false;
        if (cameraStance == 1f)
        {
            mainCamera.GetComponent<moving>().enabled = true;
            mainCamera.GetComponent<CameraZoom>().enabled = true;
        }
        if (cameraStance == 2f)
        {
            mainCamera.GetComponent<FlyCamera>().enabled = true;
        }

    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        time = 0f;
        GameIsPaused = true;
        mainCamera.GetComponent<moving>().enabled = false;
        mainCamera.GetComponent<CameraZoom>().enabled = false;
        mainCamera.GetComponent<FlyCamera>().enabled = false;
    }
}
