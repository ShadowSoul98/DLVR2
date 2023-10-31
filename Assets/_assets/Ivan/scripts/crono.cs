using System.Runtime.CompilerServices;
using System.Data.SqlTypes;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class crono : MonoBehaviour
{
    public DateTime tiempoInicial;
    void Start() {
        tiempoInicial = DateTime.Now;
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
