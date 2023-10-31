using System.Data.SqlTypes;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class crono : MonoBehaviour
{
    public TimeSpan dateTimE;
    public int segundos;
    public void SaveTime(TimeSpan timeSpan) {
        dateTimE = timeSpan;
        segundos =+ (int)dateTimE.TotalSeconds;
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
