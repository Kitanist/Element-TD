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
        if (!MainMenuCamController.Instance.onUI)
        {
            Cam.SetCam(birdName);
            MainMenuCamController.Instance.OnButton = true;
            StopCoroutine(OnButtonEnum());
        }
       
    }
    private void OnMouseExit()
    {
        if (!MainMenuCamController.Instance.onUI)
        {
            StartCoroutine(OnButtonEnum());
        }
        
        
       
    }
    IEnumerator OnButtonEnum()
    {
        Debug.Log("girdim");
        yield return new WaitForSeconds(0.01f);
        MainMenuCamController.Instance.OnButton = false;
        Cam.SetCam(Cam.tmp);
        Debug.Log("çýktým");

    }
}
