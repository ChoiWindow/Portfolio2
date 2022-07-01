using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject cameraView; //카메라 바라볼 대상

    public GameObject cameraPos; //카메라의 위치

    public float speed; //카메라가 움직일 속도

    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraPos.transform.position,
            Time.deltaTime * speed);

        gameObject.transform.LookAt(cameraView.transform);
    }



}
