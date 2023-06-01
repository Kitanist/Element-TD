using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MainMenuCamController : MonoSingeleton<MainMenuCamController>
{
    public Vector3 Start,tmp;
    public bool OnButton = false;
    public bool onUI;
    public void SetCam(Vector3 Rotater)
    {
        if (!OnButton)
        {
            gameObject.transform.DORotate(Rotater, 1);
            
        }
        
       
    }
    public void SetCamPos(Vector3 Mover)
    {
        gameObject.transform.DOMove(Mover, 1);
    }
}
