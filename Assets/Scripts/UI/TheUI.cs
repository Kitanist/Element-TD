using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheUI : MonoSingeleton<TheUI>
{
    public CanvasGroup Shop1, Shop2, Shop3;
    public CanvasGroup UShop1, UShop2, UShop3;

    public RectTransform rectTreansform;

    public bool isOpen,isUpgrade,isArmy;

    public GameObject BackGround;
    public Button ShopButton1, ShopButton2, ShopButton3, UShopButton1, UShopButton2, UShopButton3;


    private void Start()
    {
        ControlTheUI();
       
        UShop1.LeanAlpha(0, 0.5f);
        UShop2.LeanAlpha(0, 0.5f);
        UShop3.LeanAlpha(0, 0.5f);
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

        if (!isArmy && !isUpgrade)
        {
            ShopButton1.gameObject.SetActive(true);
            ShopButton2.gameObject.SetActive(true);
            ShopButton3.gameObject.SetActive(true);
            Shop1.LeanAlpha(1, 0.5f);
            Shop2.LeanAlpha(1, 0.5f);
            Shop3.LeanAlpha(1, 0.5f);
            
            ShopButton1.interactable = true;
            ShopButton2.interactable = true;
            ShopButton3.interactable = true;

        }
        if (isUpgrade)
        {
            UShopButton1.gameObject.SetActive(true);
            UShopButton2.gameObject.SetActive(true);
            UShopButton3.gameObject.SetActive(true);
            UShop1.LeanAlpha(1, 0.5f);
            UShop2.LeanAlpha(1, 0.5f);
            UShop3.LeanAlpha(1, 0.5f);

            UShopButton1.interactable = true;
            UShopButton2.interactable = true;
            UShopButton3.interactable = true;
        }

    }
    public void ShopUIClose()
    {
      
        BackGround.transform.LeanMoveLocal(new Vector2(1000, 0), 1).setEaseInExpo();
        isOpen = false;
        if (!isArmy && !isUpgrade) { 
        Shop1.LeanAlpha(0, 0.5f);
        Shop2.LeanAlpha(0, 0.5f);
        Shop3.LeanAlpha(0, 0.5f);
        }
        if (isUpgrade)
        {
            UShop1.LeanAlpha(0, 0.5f);
            UShop2.LeanAlpha(0, 0.5f);
            UShop3.LeanAlpha(0, 0.5f);
        }
        StartCoroutine(ButtonEater());
        UShopButton1.interactable = false;
        UShopButton2.interactable = false;
        UShopButton3.interactable = false;
        ShopButton1.interactable = false;
        ShopButton2.interactable = false;
        ShopButton3.interactable = false;

    }
    IEnumerator ButtonEater()
    {
        yield return new WaitForSeconds(1);
       UShopButton1.gameObject.SetActive(false) ;
       UShopButton2.gameObject.SetActive(false) ;
       UShopButton3.gameObject.SetActive(false) ;
        ShopButton1.gameObject.SetActive(false) ;
        ShopButton2.gameObject.SetActive(false) ;
        ShopButton3.gameObject.SetActive(false) ;
    }
}
