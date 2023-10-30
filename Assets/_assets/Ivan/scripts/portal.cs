using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public int esena;
    [SerializeField] private DateTime tiempoInicial;
    [SerializeField] private DateTime tiempoFinal;
    public TimeSpan tiempoResult;

    void Start() {
        tiempoInicial = DateTime.Now;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            tiempoFinal = DateTime.Now;
            tiempoResult = tiempoFinal.Subtract(tiempoInicial);
            SceneManager.LoadScene(esena);
        }
    }
}
