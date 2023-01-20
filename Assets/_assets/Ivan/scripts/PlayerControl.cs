using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public WheelCollider LLantaDControl, LLantatControl;

    public Transform frontDR, backDR;

    public float _steerAngle = 0;

    public float steerAngl;

    public float _motorforce = 0;

    float h, v;

    public Transform moveMoto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Inputs();
        Drive();
        SteerMoto();

        UpdateWheelPos(LLantaDControl, frontDR);
        UpdateWheelPos(LLantatControl, backDR);
    }

    void Inputs()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

    }

    void Drive()
    {
        LLantatControl.motorTorque= v*_motorforce;
    }

    void SteerMoto()
    {
        steerAngl = _steerAngle * h;
        LLantaDControl.steerAngle = steerAngl;

        //moveMoto.rotation = Quaternion(0, 0, 0);

    }
    void UpdateWheelPos(WheelCollider col, Transform t)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;

        col.GetWorldPose(out pos, out rot);
        t.position = pos;
        t.rotation = rot;
    }
}
