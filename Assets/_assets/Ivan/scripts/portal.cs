using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public crono cron0;
    [SerializeField] private int esena;
    [SerializeField] private DateTime tiempoInicial;
    [SerializeField] private DateTime tiempoFinal;
    public TimeSpan tiempoResult;

    void Start() {
        tiempoInicial = DateTime.Now;
        cron0 = GameObject.FindGameObjectWithTag("Timer").GetComponent<crono>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            tiempoFinal = DateTime.Now;
            tiempoResult = tiempoFinal.Subtract(tiempoInicial);
            cron0.SaveTime(tiempoResult);
            SceneManager.LoadScene(esena);
        }
    }
    public TimeSpan Timer(){
        return tiempoResult;
    }
}
