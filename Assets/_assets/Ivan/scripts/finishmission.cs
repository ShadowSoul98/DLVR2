using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class finishmission : MonoBehaviour
{
    public int bolbook = 0;
    public List<Light> luz;
    public Transform puerta,puerta1,newpuerta,newpuerta1;
    public GameObject portal;
    // Start is called before the first frame update
    void Update()
    {
        if(bolbook == 4){
            Portal();
        }
    }

    void Portal(){
        for(int i=0;i<luz.Count;i++){
            luz[i].enabled = true;
        }
        puerta.GetComponent<Transform>().SetPositionAndRotation(newpuerta.position,newpuerta.rotation);
        puerta1.GetComponent<Transform>().SetPositionAndRotation(newpuerta1.position,newpuerta1.rotation);
        portal.SetActive(true);
    }
}
