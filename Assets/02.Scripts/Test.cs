using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public GameObject[] wheelMeshs = new GameObject[4];
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float brakeTorque;

    private void Update()
    {
        UpdateMeshsPositions();
    }

    private void FixedUpdate()
    {
        float steer = Input.GetAxis("Horizontal");
        wheelColliders[0].steerAngle = steer * maxSteeringAngle;
        wheelColliders[1].steerAngle = steer * maxSteeringAngle;
        float motor = -Input.GetAxis("Vertical");
        wheelColliders[2].motorTorque = motor * maxMotorTorque;
        wheelColliders[3].motorTorque = motor * maxMotorTorque;

    }

    void UpdateMeshsPositions()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos;
            Quaternion quat;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            wheelMeshs[i].transform.position = pos;
            wheelMeshs[i].transform.rotation = quat;
        }

    }

}
