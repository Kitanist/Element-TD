using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LookAtThisBird : MonoBehaviour
{
    public MainMenuCamController Cam;
    public Vector3 birdName;
    private void OnMouseEnter()
    {
        Cam.SetCam(birdName);
    }
    private void OnMouseExit()
    {
        Cam.SetCam(Cam.tmp);
    }
}
