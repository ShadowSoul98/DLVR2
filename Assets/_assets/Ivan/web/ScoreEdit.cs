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
    float tiempoTranscurrido;
    public DateTime tiempoFinal;
    int score;
    public void FinPartida()
    {
        StartCoroutine(Fin());
    }
    public void FinScore()
    {
        StartCoroutine(ScoreCheck());
    }
    IEnumerator ScoreCheck()
    {
        string[] data = new string[1];
        data[0] = profile.DBuser.id.ToString();
        StartCoroutine(server.ServiceConsum("scoreCheck", data, PosLoader));
        yield return new WaitForSeconds(0.15f);
        yield return new WaitUntil(() => !server.busy);
    }
    
    IEnumerator Fin()
    {
        string[] data = new string[3];
        Debug.Log("id: "+ profile.DBranck.id+"score: "+profile.DBranck.score);        
        if(profile.DBranck.score <= score){
            Debug.Log("cambiar puntos");
            data[0] = profile.DBuser.id.ToString();
            data[1] = tiempo.ToString(@"hh\:mm\:ss");
            data[2] = score.ToString();
            StartCoroutine(server.ServiceConsum("scoreEdit", data, PosLoader));
            yield return new WaitForSeconds(0.15f);
            yield return new WaitUntil(() => !server.busy);
        } else{
            Debug.Log("no cambio los puntos");
        }
    }
    public void PosLoader()
    {
        switch (server.response.codigo)
        {
            case 204:
                Debug.Log("Usuario o contrasena son incorrectos");
                break;
            case 205:
                profile.DBranck = JsonUtility.FromJson<DBRanck>(server.response.respuesta);
                FinPartida();
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
        tiempoTranscurrido = (int)tiempo.TotalSeconds;
        score = CalcularPuntaje(tiempoTranscurrido);

        FinScore();
        Debug.Log("tiempoFinal: "+tiempo);
        //FinPartida();
    }
    int CalcularPuntaje(float tiempoTranscurrido)
    {
        float tiempoMaximo = 60.0f; // Tiempo máximo en segundos
        int puntajeMaximo = 1000;  // Puntaje máximo
        int puntajeMinimo = 100;   // Puntaje mínimo

        // Asegurarse de que el tiempo no supere el tiempo máximo
        tiempoTranscurrido = Mathf.Min(tiempoTranscurrido, tiempoMaximo);

        // Calcular el puntaje inversamente proporcional al tiempo
        float porcentajeTiempo = tiempoTranscurrido / tiempoMaximo;
        int puntaje = (int)Mathf.Lerp(puntajeMaximo, puntajeMinimo, porcentajeTiempo);

        return puntaje;
    }
}
