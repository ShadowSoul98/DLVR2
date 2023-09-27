using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    [SerializeField]
    private String tagado;
    public finishmission finishmission;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(tagado))
        {
            finishmission.GetComponent<finishmission>().bolbook++;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag(tagado))
        {
            finishmission.GetComponent<finishmission>().bolbook--;
        }
    }
}
