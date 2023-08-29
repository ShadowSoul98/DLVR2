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
    public TMP_InputField user;
    public TMP_InputField pass;
    public GameObject imLoading;
    public DBUser DBuser;
    // Start is called before the first frame update
    public void SesionStart()
    {
        StartCoroutine(Start());
    }
    IEnumerator Start()
    {
        imLoading.SetActive(true);
        string[] data = new string[2];
        data[0] = user.text;
        data[1] = pass.text;
        //Debug.Log(user.text+ " " +pass.text);
        StartCoroutine(server.ServiceConsum("login", data, PosLoader));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !server.busy);
        imLoading.SetActive(false);
    }

    public void PosLoader()
    {
        switch (server.response.codigo)
        {
            case 204:
                print("Usuario o contrasena son incorrectos");
                break;
            case 205:
                //SceneManager.LoadScene(1);
                Debug.Log(server.response.respuesta);
                DBuser = JsonUtility.FromJson<DBUser>(server.response.respuesta);
                break;
            case 402:
                print("Usuario o contrasena son incorrectos");
                break;
            case 404:

                print("No se puede conectar con el servidor");
                break;
            default:
                break;
        }
    }
}

[Serializable]
public class DBUser
{
    public int id;
    public string user;
    public string pass;
    public string imguser;
    public string level;
}