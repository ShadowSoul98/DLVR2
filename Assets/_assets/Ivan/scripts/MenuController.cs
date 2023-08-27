using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseCanvas;
    public void StartBtn()
    {
        SceneManager.LoadScene("Demo");
    }
}
