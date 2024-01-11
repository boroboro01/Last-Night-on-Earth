using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class Rocket : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera expandCam;
    [SerializeField] CinemachineVirtualCamera fullCam;

private void OnEnable() {
    SwitchCamera.Register(expandCam);
    SwitchCamera.Register(fullCam);
    SwitchCamera.Switching(expandCam);
} 
private void OnDisable() {
    SwitchCamera.Unregister(expandCam);
    SwitchCamera.Unregister(fullCam);
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(SwitchCamera.IsActiveCamera(expandCam)) {
                SwitchCamera.Switching(fullCam);
            } else if(SwitchCamera.IsActiveCamera(fullCam)) {
                SwitchCamera.Switching(expandCam);
            }
        }
    }
}
