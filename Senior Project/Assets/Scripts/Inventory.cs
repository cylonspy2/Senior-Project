using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text koiText;
    public Text minnowText;
    public Text anglerText;
    public Text clownText;
    public Text lionText;
    public Text pennantText;
    public Text rainbowText;
    public Text robText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] koi = GameObject.FindGameObjectsWithTag("Koi");
        
        koiText.text = koi.Length.ToString();

        GameObject[] minnow = GameObject.FindGameObjectsWithTag("Minnow");
        minnowText.text = minnow.Length.ToString();


        GameObject[] angler = GameObject.FindGameObjectsWithTag("Angler");
        anglerText.text = angler.Length.ToString();

        GameObject[] clown = GameObject.FindGameObjectsWithTag("Clown");
        clownText.text = clown.Length.ToString();


        GameObject[] lion = GameObject.FindGameObjectsWithTag("Lion");
        lionText.text = lion.Length.ToString();

        GameObject[] pennant = GameObject.FindGameObjectsWithTag("Pennant");
        pennantText.text = pennant.Length.ToString();


        GameObject[] rainbow = GameObject.FindGameObjectsWithTag("Rainbow");
        rainbowText.text = rainbow.Length.ToString();

        GameObject[] rob = GameObject.FindGameObjectsWithTag("Rob");
        robText.text = rob.Length.ToString();

        

    }
}
