using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LookAtThisBird : MonoBehaviour
{
    public MainMenuCamController Cam;
    public Vector3 birdName;
    
  

    public void ClickedOn()
    {
        Cam.SetCam(birdName);
    }

    public void ClickedBackOn()
    {
        StartCoroutine(OnButtonEnum());
    }
    
    IEnumerator OnButtonEnum()
    {
        Debug.Log("girdim");
        yield return new WaitForSeconds(0.01f);
        MainMenuCamController.Instance.OnButton = false;
        Cam.SetCam(Cam.tmp);
        Debug.Log("��kt�m");

    }
}
