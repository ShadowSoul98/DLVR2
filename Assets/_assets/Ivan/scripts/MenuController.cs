using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
