using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public static class SwitchCamera
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;
    public static bool IsActiveCamera(CinemachineVirtualCamera camera) {
        return camera == ActiveCamera;
    }
    public static void Switching (CinemachineVirtualCamera camera) {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach(CinemachineVirtualCamera c in cameras) {
            if(c != camera && c.Priority != 0) {
                c.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera Registered : " + camera);
    }
    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera Unregistered : " + camera);
    }
}
