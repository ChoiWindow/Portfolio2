using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
        public float radius = 6;

        public float power = 100f; //���� ��
        public float rot = 45f; // ���� ȸ������
        Rigidbody rb;

        public float downForceValue; // ���� ����ȭ ������ ��

        //���ݶ��̴� 
        public WheelCollider[] wheels = new WheelCollider[4];
        GameObject[] wheelMesh = new GameObject[4];

        InputManager IM;
        private void Start()
        {
            //�±׷� �� �ݶ��̴��� ��ġ ���߱�
            wheelMesh = GameObject.FindGameObjectsWithTag("Wheel");

            for (int i = 0; i < wheelMesh.Length; i++)
            {
                wheels[i].transform.position = wheelMesh[i].transform.position;
            }

            // y�� �Ʒ��������� �����߽� ���߱�
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0, -1, 0);

            IM = GetComponent<InputManager>();


        }

        //void WheelPosAndAni()
        //{
        //    Vector3 wheelPosition = Vector3.zero;
        //    Quaternion wheelRotation = Quaternion.identity;

        //    for ( int i = 0; i < 4; i++)
        //    {
        //        wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
        //        wheelMesh[i].transform.position = wheelPosition;
        //        wheelMesh[i].transform.rotation = wheelRotation;
        //    }
        //}
        void SteerVehicle()
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
                wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * IM.horizontal;
                wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * IM.horizontal;
            }
            else
            {
                wheels[0].steerAngle = 0;
                wheels[1].steerAngle = 0;
            }
        }
        void AddDownForce()
        {
            rb.AddForce(-transform.up * downForceValue * rb.velocity.magnitude); // ���� �ӵ��� ���������� �з°�ȭ
        }


        private void FixedUpdate()
        {
            for (int i = 0; i < wheels.Length; i++) //�� �ݶ��̴� ��ü Vertical �Է¿� ���� ������ �����ϰ��Ѵ�
            {
            wheels[i].motorTorque = IM.vertical* power;
            }
            for (int i = 0; i < 2; i++) // �չ����� ȸ�������� ���� ��ġ���� �Ѵ�.
            {
            wheels[i].steerAngle = IM.horizontal * rot;
            }
            // WheelPosAndAni();
            AddDownForce();
            SteerVehicle();
        }
    }

