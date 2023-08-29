using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseCanvas;
    [SerializeField]
    private Camera CameraL, CamaraR, CamaraC;
    private static bool gamestop;
    private void LateUpdate()         
    {
        if (OVRInput.GetUp(OVRInput.RawButton.Start))
        {
            PauseCanvas.SetActive(!PauseCanvas.activeSelf);
            Debug.Log("Press start: " + PauseCanvas.activeSelf);
        }
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("Start");
    }

    public void StartBtn()
    {
        gamestop = !gamestop;
        PauseGame();
    }

    void PauseGame()
    {
        if (gamestop)
        {
            Time.timeScale = 0f;
            CamaraC.clearFlags = CameraClearFlags.SolidColor;
            CamaraC.backgroundColor = Color.red;
        }
        else
        {
            Time.timeScale = 1f;
            CamaraC.clearFlags = CameraClearFlags.Skybox;
            CamaraC.backgroundColor = Color.blue;
        }
    }
}
