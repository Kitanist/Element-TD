using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotator : MonoSingeleton<CameraRotator>
{
    public Camera cam;
    private Vector3 previosPositoion;
    public Transform target;
    public float offset=-10;
    public float zoomSense = .6f;
    public bool isCamChange=false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previosPositoion = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previosPositoion - cam.ScreenToViewportPoint(Input.mousePosition);

          //  cam.transform.position = target.position;
        
           target.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
           target.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
           
           LimitRot();
     
            //cam.transform.Translate(new Vector3(0, 0, offset));
           // cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, -50, 10), Mathf.Clamp(cam.transform.position.y, 0, 32),transform.position.z);

            //Mathf.Clamp(cam.transform.rotation.y, 0, 180);


            previosPositoion = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0 &&offset<-20)
        {
         
            offset += zoomSense;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, offset);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && offset > -40)
        {
            
            offset -= zoomSense;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, offset);
        }
        if (isCamChange)
        {
            offset = cam.transform.position.z;
            isCamChange = false;
        }
    }
    public void LimitRot()
    {
        Vector3 eulerAngels = target.transform.rotation.eulerAngles;
        eulerAngels.x = (eulerAngels.x > 180) ? eulerAngels.x - 360 : eulerAngels.x;
        eulerAngels.x = Mathf.Clamp(eulerAngels.x, -25, 60);
        target.transform.rotation = Quaternion.Euler(eulerAngels);

    }
}
