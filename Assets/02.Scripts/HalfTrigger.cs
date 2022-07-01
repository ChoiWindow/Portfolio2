using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfTrigger : MonoBehaviour
{
    public GameObject LabCompleteTrig;
    public GameObject HalfLabTrigger;

    private void OnTriggerEnter()
    {
        LabCompleteTrig.SetActive(true);
        HalfLabTrigger.SetActive(false);

    }

}
