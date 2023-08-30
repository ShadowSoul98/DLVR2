using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public server server;
    public playerProfile playerProfile;
    public TMP_InputField username;
    public TMP_InputField password;
    public GameObject imLoading;
    public TextMeshProUGUI errorText;
    public bool first = false;

    public void InicioPartida()
    {
        StartCoroutine(Inicio());
    }
    IEnumerator Inicio()
    {
        imLoading.SetActive(true);
        string[] data = new string[2];
        data[0] = username.text;
        data[1] = password.text;
        Debug.Log(2);
        StartCoroutine(server.ServiceConsum("login", data, PosLoader));
        yield return new WaitForSeconds(0.15f);
        yield return new WaitUntil(() => !server.busy);
        //imLoading.SetActive(false);
    }

    public void PosLoader()
    {
        switch (server.response.codigo)
        {
            case 204:
                if (first)
                {
                    Debug.Log(1);
                    errorText.text = "Usuario o contrasena son incorrectos";
                    imLoading.SetActive(true);
                    //print("Usuario o contrasena son incorrectos");
                }
                else
                {
                    first = true;
                    imLoading.SetActive(false);
                }
                    break;
            case 205:
                playerProfile.DBuser = JsonUtility.FromJson<DBUser>(server.response.respuesta);
                errorText.text = "Bienvenido "+playerProfile.DBuser.name;
                SceneManager.LoadScene(1);
                break;
            case 402:
                errorText.text = "Error datos faltantes";
                break;
            case 404:

                errorText.text = "No se puede conectar con el servidor";
                break;
            default:
                break;
        }
    }
}
