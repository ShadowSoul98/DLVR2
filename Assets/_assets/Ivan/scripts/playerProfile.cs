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
    public RawImage Image;
    // Start is called before the first frame update

    public void Loadimage()
    {
        StartCoroutine(GetTexture());
    }
    public void SetUserName(string name)
    {
        textMeshPro.text = DBuser.name;
        Loadimage();
    }
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://scontent.fgdl5-3.fna.fbcdn.net/v/t39.30808-6/369048204_258384457086659_1446912744924971714_n.jpg?_nc_cat=1&ccb=1-7&_nc_sid=174925&_nc_eui2=AeHeDNmspFiKnrEWc6zuyW4_1lr8tUgt6iLWWvy1SC3qIqAHu4HprFqtOO357XRyq7VTC2xlD42sMSO0hSNleNsO&_nc_ohc=9F1V1e5b3uIAX9oh-jW&_nc_ht=scontent.fgdl5-3.fna&oh=00_AfCsahVwgafirlZl5bV4QgKweA3B6AQqndgAclM2vvEG_g&oe=64F371AC");
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
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