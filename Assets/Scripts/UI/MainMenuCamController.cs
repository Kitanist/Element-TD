using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MainMenuCamController : MonoBehaviour
{
    public Vector3 Start,tmp;

    public void SetCam(Vector3 Rotater)
    {
        gameObject.transform.DORotate(Rotater,1);
    }
}
