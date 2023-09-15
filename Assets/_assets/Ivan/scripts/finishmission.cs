using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class finishmission : MonoBehaviour
{
    public int bolbook = 0;
    public Light light3,light1,light2;
    public Transform puerta,puerta1,newpuerta,newpuerta1;
    public Collider portal;
    // Start is called before the first frame update
    void Update()
    {
        if(bolbook == 4){
            Portal();
        }
    }

    void Portal(){
        portal.enabled = true;
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        puerta.GetComponent<Transform>().SetPositionAndRotation(newpuerta.position,newpuerta.rotation);
        puerta1.GetComponent<Transform>().SetPositionAndRotation(newpuerta1.position,newpuerta1.rotation);
    }
}
