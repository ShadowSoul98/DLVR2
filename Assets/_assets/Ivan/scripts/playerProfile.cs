using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class playerProfile : MonoBehaviour
{
    public Login Login;
    public DBUser DBuser;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update

    public void SetUserName(string name)
    {
        textMeshPro.text = DBuser.name;
    }
}

[Serializable]
public class DBUser
{
    public int id;
    public string name;
    public string password;
    public string imguser;
    public string level;
}