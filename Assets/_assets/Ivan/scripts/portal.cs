using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    [SerializeField] private int esena;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(esena);
        }
    }
}
