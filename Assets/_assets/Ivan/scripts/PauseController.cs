using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseCanvas;
    private void LateUpdate()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.Start))
        {
            PauseCanvas.SetActive(!PauseCanvas.active);
            Debug.Log("Press start: " + PauseCanvas.active);
        }
    }
}
