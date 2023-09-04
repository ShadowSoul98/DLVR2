using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class pauseProfile : MonoBehaviour
{
    public RawImage imageProfile;
    public TextMeshProUGUI nameProfile;
    public playerProfile profile;
    public string imageUrl;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        nameProfile.text = profile.DBuser.name;
        imageUrl = profile.DBuser.imguser;
        StartCoroutine(GetTextures());
     
    }

    [System.Obsolete]
    IEnumerator GetTextures()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        Debug.Log(www.url);
        yield return www.SendWebRequest();
        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            imageProfile.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
}
