using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheUI : MonoBehaviour
{
    public CanvasGroup Shop1, Shop2, Shop3;
    public RectTransform rectTreansform;
    public bool isOpen;
    public GameObject OpenButon,BackGround;
    public Button ShopButton1, ShopButton2, ShopButton3;

 
    // kule geli�tirmesi oynan�nca sa�dan ba�ka u� a��l�p b�y�cek kapamaya bas�nca o da yava�ca kapanacak
    public void ControlTheUI()
    {
        if (!isOpen) // a��l�rken set ease out expo 
        {
            ShopUIOpen();

        }
        else // kapan�rken  set ease in expo 
        {
            ShopUIClose();
        }

    }
    public void ShopUIOpen()
    {
        OpenButon.transform.LeanMoveLocal(new Vector2(0, 0), 1).setEaseOutExpo();
        BackGround.transform.LeanMoveLocal(new Vector2(775, 0), 1).setEaseOutExpo();
        isOpen = true;


        Shop1.LeanAlpha(1, 0.5f);
        Shop2.LeanAlpha(1, 0.5f);
        Shop3.LeanAlpha(1, 0.5f);

        ShopButton1.interactable = true;
        ShopButton2.interactable = true;
        ShopButton3.interactable = true;

    }
    public void ShopUIClose()
    {
        OpenButon.transform.LeanMoveLocal(new Vector2(350, 0), 1).setEaseInExpo();
        BackGround.transform.LeanMoveLocal(new Vector2(1000, 0), 1).setEaseInExpo();
        isOpen = false;

        Shop1.LeanAlpha(0, 0.5f);
        Shop2.LeanAlpha(0, 0.5f);
        Shop3.LeanAlpha(0, 0.5f);
        Debug.Log("�effaf");

        ShopButton1.interactable = false;
        ShopButton2.interactable = false;
        ShopButton3.interactable = false;

    }
}
