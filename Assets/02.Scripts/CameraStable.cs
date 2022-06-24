using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject Thecar;
    public float CarX;
    public float CarY;
    public float CarZ;

    private void Update()
    {
        CarX = Thecar.transform.eulerAngles.x;
        CarY = Thecar.transform.eulerAngles.y;
        CarZ = Thecar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY - CarY, CarZ - CarZ);
    }
}
