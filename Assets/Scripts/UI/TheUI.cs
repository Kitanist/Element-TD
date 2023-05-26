using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheUI : MonoSingeleton<TheUI>
{
    public CanvasGroup Shop1, Shop2, Shop3;
    public RectTransform rectTreansform;
    public bool isOpen;
    public GameObject BackGround;
    public Button ShopButton1, ShopButton2, ShopButton3;


    private void Start()
    {
        ControlTheUI();
    }
    public void ControlTheUI()
    {
        if (!isOpen) // açýlýrken set ease out expo 
        {
            ShopUIOpen();

        }
        else // kapanýrken  set ease in expo 
        {
            ShopUIClose();
        }

    }
    public void ShopUIOpen()
    {
       
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
      
        BackGround.transform.LeanMoveLocal(new Vector2(1000, 0), 1).setEaseInExpo();
        isOpen = false;

        Shop1.LeanAlpha(0, 0.5f);
        Shop2.LeanAlpha(0, 0.5f);
        Shop3.LeanAlpha(0, 0.5f);
        

        ShopButton1.interactable = false;
        ShopButton2.interactable = false;
        ShopButton3.interactable = false;

    }
}
