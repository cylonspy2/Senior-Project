using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDecorations : MonoBehaviour
{
    public GameObject antenna;
    public GameObject coral;
    public GameObject metronome;
    public GameObject oyster;
    public GameObject pirateShip;
    public GameObject pirateSkull;

    public GameObject antenna_on;
    public GameObject antenna_off;

    public GameObject coral_on;
    public GameObject coral_off;

    public GameObject metronome_on;
    public GameObject metronome_off;

    public GameObject oyster_on;
    public GameObject oyster_off;

    public GameObject pirateShip_on;
    public GameObject pirateShip_off;

    public GameObject pirateSkull_on;
    public GameObject pirateSkull_off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn_Antenna()
    {
        antenna.SetActive(true);
        coral.SetActive(false);
        metronome.SetActive(false);
        oyster.SetActive(false);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(false);

        coral_on.SetActive(true);
        metronome_on.SetActive(true);
        oyster_on.SetActive(true);
        pirateShip_on.SetActive(true);
        pirateSkull_on.SetActive(true);

        coral_off.SetActive(false);
        metronome_off.SetActive(false);
        oyster_off.SetActive(false);
        pirateShip_off.SetActive(false);
        pirateSkull_off.SetActive(false);
    }
    public void TurnOff()
    {
        antenna.SetActive(false);
        coral.SetActive(false);
        metronome.SetActive(false);
        oyster.SetActive(false);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(false);
    }

    public void TurnOn_Coral()
    {
        antenna.SetActive(false);
        coral.SetActive(true);
        metronome.SetActive(false);
        oyster.SetActive(false);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(false);

        antenna_on.SetActive(true);
        metronome_on.SetActive(true);
        oyster_on.SetActive(true);
        pirateShip_on.SetActive(true);
        pirateSkull_on.SetActive(true);

        antenna_off.SetActive(false);
        metronome_off.SetActive(false);
        oyster_off.SetActive(false);
        pirateShip_off.SetActive(false);
        pirateSkull_off.SetActive(false);
    }

    public void TurnOn_Metronome()
    {
        antenna.SetActive(false);
        coral.SetActive(false);
        metronome.SetActive(true);
        oyster.SetActive(false);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(false);

        antenna_on.SetActive(true);
        coral_on.SetActive(true);
        oyster_on.SetActive(true);
        pirateShip_on.SetActive(true);
        pirateSkull_on.SetActive(true);

        antenna_off.SetActive(false);
        coral_off.SetActive(false);
        oyster_off.SetActive(false);
        pirateShip_off.SetActive(false);
        pirateSkull_off.SetActive(false);
    }

    public void TurnOn_Oyster()
    {
        antenna.SetActive(false);
        coral.SetActive(false);
        metronome.SetActive(false);
        oyster.SetActive(true);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(false);

        antenna_on.SetActive(true);
        coral_on.SetActive(true);
        metronome_on.SetActive(true);
        pirateShip_on.SetActive(true);
        pirateSkull_on.SetActive(true);

        antenna_off.SetActive(false);
        coral_off.SetActive(false);
        metronome_off.SetActive(false);
        pirateShip_off.SetActive(false);
        pirateSkull_off.SetActive(false);
    }
    public void TurnOn_PirateShip()
    {
        antenna.SetActive(false);
        coral.SetActive(false);
        metronome.SetActive(false);
        oyster.SetActive(false);
        pirateShip.SetActive(true);
        pirateSkull.SetActive(false);

        antenna_on.SetActive(true);
        coral_on.SetActive(true);
        metronome_on.SetActive(true);
        oyster_on.SetActive(true);
        pirateSkull_on.SetActive(true);

        antenna_off.SetActive(false);
        coral_off.SetActive(false);
        metronome_off.SetActive(false);
        oyster_off.SetActive(false);
        pirateSkull_off.SetActive(false);
    }

    public void TurnOn_PirateSkull()
    {
        antenna.SetActive(false);
        coral.SetActive(false);
        metronome.SetActive(false);
        oyster.SetActive(false);
        pirateShip.SetActive(false);
        pirateSkull.SetActive(true);

        antenna_on.SetActive(true);
        coral_on.SetActive(true);
        metronome_on.SetActive(true);
        oyster_on.SetActive(true);
        pirateShip_on.SetActive(true);

        antenna_off.SetActive(false);
        coral_off.SetActive(false);
        metronome_off.SetActive(false);
        oyster_off.SetActive(false);
        pirateShip_off.SetActive(false);
    }




}
