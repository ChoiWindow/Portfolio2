using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject NomalCam;
    public GameObject SecCam;
    public GameObject ThrCam;
    public int CamMode;

    private void Update()
    {
        if (Input.GetButtonDown("ViewChange"))
        {
            if(CamMode == 2)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(ModeChange());
        }
    }

    IEnumerator ModeChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            NomalCam.SetActive(true);
            SecCam.SetActive(false);
        }
        if(CamMode == 1)
        {
            ThrCam.SetActive(true);
            NomalCam.SetActive(false);
        }
        if(CamMode == 2)
        {
            SecCam.SetActive(true);
            ThrCam.SetActive(false);
        }
    }
}
