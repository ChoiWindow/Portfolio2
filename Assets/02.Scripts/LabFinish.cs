using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LabFinish : MonoBehaviour
{
    public GameObject LabCompleteTrig;
    public GameObject HalfLabTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;
    
    public GameObject LabTimeBox;

    private void OnTriggerEnter()
    {
        if(LabTimeManager.SecondCount <= 9)
        {
            SecondDisplay.GetComponent<Text>().text = "0" + LabTimeManager.SecondCount + ".";
        }
        else
        {
            SecondDisplay.GetComponent<Text>().text = "" + LabTimeManager.SecondCount + ".";
        }

        if (LabTimeManager.MinuteCount <= 9)
        {
            MinuteDisplay.GetComponent<Text>().text = "0" + LabTimeManager.MinuteCount + ".";
        }
        else
        {
            MinuteDisplay.GetComponent<Text>().text = "" + LabTimeManager.MinuteCount + ".";
        }

        MilliDisplay.GetComponent<Text>().text = "" + LabTimeManager.MilliCount;

        LabTimeManager.MinuteCount = 0;
        LabTimeManager.SecondCount = 0;
        LabTimeManager.MilliCount = 0;

        HalfLabTrig.SetActive(true);
        LabCompleteTrig.SetActive(false);
    }
}
