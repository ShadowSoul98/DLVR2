using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Server", menuName = "Ivan/Server", order = 1)]
public class server : ScriptableObject
{
    public string servidor;
    public Service[] services;

    public bool busy=false;
    public Respuesta response;


    public IEnumerator ServiceConsum(string name, string[] data, UnityAction e)
    {
        busy = true;
        WWWForm form = new WWWForm();
        Service s = new Service();

        for (int i = 0; i < services.Length; i++)
        {
            //Debug.Log(services[i].name);
            if (services[i].name.Equals(name))
            {
                s = services[i];
            }
        }
        for (int i = 0;i < s.parameters.Length; i++)
        {
            form.AddField(s.parameters[i], data[i]);
        }
        UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.url, form);
        //Debug.Log(servidor + "/" + s.url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) 
        {
            //no cargo el usuario
            response = new Respuesta();
        }
        else
        {
            response = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
            response.LoadProfile();
        }
        busy = false;
        e.Invoke();
    }
}

[Serializable]
public class Service
{
    public string name;
    public string url;
    public string[] parameters;
}

[Serializable]
public class Respuesta
{
    public int codigo;
    public string mensaje;
    public string respuesta;

    public void LoadProfile()
    {
        respuesta = respuesta.Replace('#', '"');
    }

    public Respuesta()
    {
        codigo = 404;
        mensaje = "Error";
        respuesta = "Error";
    }
}