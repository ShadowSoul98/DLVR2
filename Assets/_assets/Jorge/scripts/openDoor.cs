using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator Puerta;
    
    private void OnTriggerEnter(Collider other){
        Puerta.Play("oPuerta");
    }

    private void OnTriggerExit(Collider other){
        Puerta.Play("cPuerta");
    }
}
