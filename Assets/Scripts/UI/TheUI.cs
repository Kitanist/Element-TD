using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheUI : MonoBehaviour
{
    public List<GameObject> UIElements;
    public RectTransform rectTreansform;
    public bool UIisOpen = true;
    public GameObject OpenButon;

    // buton 350 saða gidicek  arkaplan saða gidicek butonlar þeffaflaþacak ve aktiflikleri kapanacak .  
    // kule geliþtirmesi oynanýnca saðdan baþka uý açýlýp büyücek kapamaya basýnca o da yavaþca kapanacak
    public void ControlTheUI()
    {
        if (!UIisOpen) // açýlýrken set ease out expo 
        {
            OpenButon.transform.LeanMoveLocal(new Vector2(0, 0),1).setEaseOutExpo();
            UIisOpen = false;
            
            foreach (GameObject UIElement in UIElements)
            {
                

            }
        }
        else // kapanýrken  set ease in expo 
        {
            OpenButon.transform.LeanMoveLocal(new Vector2(350, 0), 1).setEaseInExpo();
            UIisOpen = true;
            foreach (GameObject UIElement in UIElements)
            {
               

            }
            
        }

    }
}
