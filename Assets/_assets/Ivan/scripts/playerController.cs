using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform player;
    public WheelCollider frontWColider, backWColider;
    public Transform frontWtransform, backWtransform;
    public float _steerAngle=25.0f, _motoForce=1500f, steerAngle;
    float h, v;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Inputs();
        Drive();
        SteerCar();
        UpdateWheelPos(frontWColider, frontWtransform);
        //UpdateWheelPos(backWColider, backWtransform);
    }

    void Inputs() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
    }
    void Drive() {
        backWColider.motorTorque = v * _motoForce;
    }
    void SteerCar() {
        steerAngle= _steerAngle*h;
        frontWColider.steerAngle= steerAngle;
    }
    void UpdateWheelPos(WheelCollider col, Transform t)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        col.GetWorldPose(out pos,out rot);
        t.position = pos;
        t.rotation = rot;
    }
}
