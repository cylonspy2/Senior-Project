using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject UI_Bottom;

    public KeyCode toggleToDefault;
    public KeyCode toggleToOne;
    public KeyCode toggleToTwo;

    public string startingCamScript;
    public string optionOneCam;
    public string optionTwoCam;


    Behaviour def;
    Behaviour one;
    Behaviour two;

    // Start is called before the first frame update
    void Start()
    {
        //grab the various camera scripts using strings. Annoying to extend if we want to add more camera modes, but screw it. Not My Script. 
        var optDef = maincamera.GetComponent(startingCamScript);
        def = optDef as Behaviour;
        var optOne = maincamera.GetComponent(optionOneCam);
        one = optOne as Behaviour;
        var optTwo = maincamera.GetComponent(optionTwoCam);
        two = optTwo as Behaviour;
    }

    // Update is called once per frame
    void Update()
    {


        //Li's code, just modified to pass through the variables instead so we don't have to touch the editor next month. Please god let me not have to look at the editor next month.
        //disables all but the important scripts for that given camera mode when a button is pushed. Doesn't allow for toggling sadly, but I'm surviving off of nothing but chocolate milk and prayers to the God-Emperor.
        if (Input.GetKey(toggleToDefault))
        {
            two.enabled = false;
            one.enabled = false;
            maincamera.GetComponent<CameraZoom>().enabled = true;
            def.enabled = true;

            UI_Bottom.SetActive(true);
        }

        if (Input.GetKey(toggleToOne))
        {
            two.enabled = false;
            one.enabled = true;
            maincamera.GetComponent<CameraZoom>().enabled = false;
            def.enabled = false;

            UI_Bottom.SetActive(false);
        }

        if (Input.GetKey(toggleToTwo))
        {
            two.enabled = true;
            one.enabled = false;
            maincamera.GetComponent<CameraZoom>().enabled = false;
            def.enabled = false;

            UI_Bottom.SetActive(false);
        }
    }
    

}
    
