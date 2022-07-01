using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject cameraView; //ī�޶� �ٶ� ���

    public GameObject cameraPos; //ī�޶��� ��ġ

    public float speed; //ī�޶� ������ �ӵ�

    private void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraPos.transform.position,
            Time.deltaTime * speed);

        gameObject.transform.LookAt(cameraView.transform);
    }



}
