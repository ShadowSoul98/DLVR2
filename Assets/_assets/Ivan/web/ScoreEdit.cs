using System.Collections;
using System.Data.SqlTypes;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreEdit : MonoBehaviour
{
    public server server;
    public playerProfile profile;
    public crono cron0;
    public TimeSpan tiempo;
    public DateTime tiempoFinal;
    public void FinPartida()
    {
        StartCoroutine(Fin());
    }
    IEnumerator Fin()
    {
        int score = (int)tiempo.TotalSeconds;
        string[] data = new string[3];
        data[0] = profile.DBuser.id.ToString();
        data[1] = tiempo.ToString(@"hh\:mm\:ss");
        data[2] = score.ToString();
        StartCoroutine(server.ServiceConsum("scoreEdit", data, PosLoader));
        yield return new WaitForSeconds(0.15f);
        yield return new WaitUntil(() => !server.busy);
    }
    public void PosLoader()
    {
        switch (server.response.codigo)
        {
            case 204:
                Debug.Log("Usuario o contrasena son incorrectos");
                break;
            case 206:
                Debug.Log("Usuario Actualizado "+"Puntos: "+server.response.respuesta);
                break;
            case 402:
                Debug.Log("Error datos faltantes");
                break;
            case 404:
                Debug.Log("No se puede conectar con el servidor");
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        profile = GameObject.FindGameObjectWithTag("userData").GetComponent<playerProfile>();
        cron0 = GameObject.FindGameObjectWithTag("Timer").GetComponent<crono>();
        tiempoFinal = DateTime.Now;
        tiempo = tiempoFinal.Subtract(cron0.tiempoInicial);
        FinPartida();
    }
}
