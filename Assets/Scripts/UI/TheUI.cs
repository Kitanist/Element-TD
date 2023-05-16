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

    // buton 350 sa�a gidicek  arkaplan sa�a gidicek butonlar �effafla�acak ve aktiflikleri kapanacak .  
    // kule geli�tirmesi oynan�nca sa�dan ba�ka u� a��l�p b�y�cek kapamaya bas�nca o da yava�ca kapanacak
    public void ControlTheUI()
    {
        if (!UIisOpen) // a��l�rken set ease out expo 
        {
            OpenButon.transform.LeanMoveLocal(new Vector2(0, 0),1).setEaseOutExpo();
            UIisOpen = false;
            
            foreach (GameObject UIElement in UIElements)
            {
                

            }
        }
        else // kapan�rken  set ease in expo 
        {
            OpenButon.transform.LeanMoveLocal(new Vector2(350, 0), 1).setEaseInExpo();
            UIisOpen = true;
            foreach (GameObject UIElement in UIElements)
            {
               

            }
            
        }

    }
}
