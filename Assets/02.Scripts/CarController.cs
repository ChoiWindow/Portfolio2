using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
        public float radius = 6;

        public float power = 100f; //바퀴 힘
        public float rot = 45f; // 바퀴 회전각도
        Rigidbody rb;

        public float downForceValue; // 차량 안정화 누르는 힘

        //휠콜라이더 
        public WheelCollider[] wheels = new WheelCollider[4];
        GameObject[] wheelMesh = new GameObject[4];

        InputManager IM;
        private void Start()
        {
            //태그로 휠 콜라이더와 위치 맞추기
            wheelMesh = GameObject.FindGameObjectsWithTag("Wheel");

            for (int i = 0; i < wheelMesh.Length; i++)
            {
                wheels[i].transform.position = wheelMesh[i].transform.position;
            }

            // y축 아래방향으로 무게중심 맞추기
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
            rb.AddForce(-transform.up * downForceValue * rb.velocity.magnitude); // 차량 속도가 빨라질수록 압력강화
        }


        private void FixedUpdate()
        {
            for (int i = 0; i < wheels.Length; i++) //휠 콜라이더 전체 Vertical 입력에 의해 힘으로 진행하게한다
            {
            wheels[i].motorTorque = IM.vertical* power;
            }
            for (int i = 0; i < 2; i++) // 앞바퀴만 회전각도에 영향 끼치도록 한다.
            {
            wheels[i].steerAngle = IM.horizontal * rot;
            }
            // WheelPosAndAni();
            AddDownForce();
            SteerVehicle();
        }
    }

