using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPulse : MonoBehaviour
{
    public MetronomeScript meta;
    //public float maxSize = 1;
    //public float minSize = 1;
    //public float growSpeed = 0.1;



    private bool keepGoing = true;
    private bool coroutineAllowed;



    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;

        GameObject manager = GameObject.Find("GameManager");
        meta = manager.GetComponent<MetronomeScript>();
        //StartCoroutine("StartPulsing");
    }

    //private void OnMouseOver()
    //{
    //    if (coroutineAllowed)
    //    {
    //        StartCoroutine("StartPulsing");
    //    }
    //}

    private IEnumerator StartPulsing()
    {

        //while (keepGoing)
        //{
            coroutineAllowed = false;

            for (float i = 0f; i <= 1f; i += 0.1f)
            {
                transform.localScale = new Vector3(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.025f, Mathf.SmoothStep(0f, 1f, i)))
                    );
                yield return new WaitForSeconds(0.015f);
            }

            for (float i = 0f; i <= 1f; i += 0.1f)
            {
                transform.localScale = new Vector3(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.025f, Mathf.SmoothStep(0f, 1f, i)))
                    );
                yield return new WaitForSeconds(0.015f);
            }

            coroutineAllowed = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(meta.Tick == true)
        {
            StartCoroutine("StartPulsing");
        }
    }
}
