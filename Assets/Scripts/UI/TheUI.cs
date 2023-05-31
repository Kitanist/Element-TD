using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheUI : MonoSingeleton<TheUI>
{
    public CanvasGroup Shop1, Shop2, Shop3,Shop4;
    public CanvasGroup UShop1, UShop2, UShop3,UShop4;
     public CanvasGroup AShop1, AShop2, AShop3;

    public RectTransform rectTreansform;

    public bool isOpen,isUpgrade,isArmy,isTurret;

    public GameObject BackGround;
    public Button ShopButton1, ShopButton2, ShopButton3,ShopButton4, UShopButton1, UShopButton2, UShopButton3,UShopButton4, AShopButton1, AShopButton2, AShopButton3;


    private void Start()
    {
        ShopUIClose();
       

    }
  
    public void ControlTheUI()
    {
     
            ShopUIOpen();

    }
  

    public void ShopUIOpen()
    {
       
        BackGround.transform.LeanMoveLocal(new Vector2(775, 0), 1).setEaseOutExpo();
       

        if (!isArmy && !isUpgrade && isTurret)
        {
            ShopButton1.gameObject.SetActive(true);
            ShopButton2.gameObject.SetActive(true);
            ShopButton3.gameObject.SetActive(true);
            ShopButton4.gameObject.SetActive(true);
            Shop1.LeanAlpha(1, 0.5f);
            Shop2.LeanAlpha(1, 0.5f);
            Shop3.LeanAlpha(1, 0.5f);
            Shop4.LeanAlpha(1, 0.5f);
            
            ShopButton1.interactable = true;
            ShopButton2.interactable = true;
            ShopButton3.interactable = true;

        }
         if (!isArmy && isUpgrade && !isTurret)
        {
        
            UShopButton1.gameObject.SetActive(true);
            UShopButton2.gameObject.SetActive(true);
            UShopButton3.gameObject.SetActive(true);
             UShopButton4.gameObject.SetActive(true);
            UShop1.LeanAlpha(1, 0.5f);
            UShop2.LeanAlpha(1, 0.5f);
            UShop3.LeanAlpha(1, 0.5f);
             UShop4.LeanAlpha(1, 0.5f);
            UShopButton1.interactable = true;
            UShopButton2.interactable = true;
            UShopButton3.interactable = true;
             UShopButton4.interactable = true;
        }
           if (isArmy && !isUpgrade && !isTurret)
        {
            AShopButton1.gameObject.SetActive(true);
            AShopButton2.gameObject.SetActive(true);
            AShopButton3.gameObject.SetActive(true);
            AShop1.LeanAlpha(1, 0.5f);
          AShop2.LeanAlpha(1, 0.5f);
            AShop3.LeanAlpha(1, 0.5f);

            AShopButton1.interactable = true;
           AShopButton2.interactable = true;
            AShopButton3.interactable = true;
        }

    }
    public void ShopUIClose()
    {
        HUD.Instance.AllUnitDeSelect();
        BackGround.transform.LeanMoveLocal(new Vector2(1000, 0), 1).setEaseInExpo();
       
       
        Shop1.LeanAlpha(0, 0.5f);
        Shop2.LeanAlpha(0, 0.5f);
        Shop3.LeanAlpha(0, 0.5f);
          Shop4.LeanAlpha(0, 0.5f);

        AShop1.LeanAlpha(0, 0.5f);
        AShop2.LeanAlpha(0, 0.5f);
        AShop3.LeanAlpha(0, 0.5f);
        
            UShop1.LeanAlpha(0, 0.5f);
            UShop2.LeanAlpha(0, 0.5f);
            UShop3.LeanAlpha(0, 0.5f);
             UShop4.LeanAlpha(0, 0.5f);
        
        StartCoroutine(ButtonEater());
        UShopButton1.interactable = false;
        UShopButton2.interactable = false;
        UShopButton3.interactable = false;
        UShopButton4.interactable = false;

        ShopButton1.interactable = false;
        ShopButton2.interactable = false;
        ShopButton3.interactable = false;
        AShopButton1.interactable = false;
     AShopButton2.interactable = false;
        AShopButton3.interactable = false;
         
    }
    IEnumerator ButtonEater()
    {
        yield return new WaitForSeconds(.5f);
       UShopButton1.gameObject.SetActive(false) ;
       UShopButton2.gameObject.SetActive(false) ;
       UShopButton3.gameObject.SetActive(false) ;
       UShopButton4.gameObject.SetActive(false) ;
        ShopButton1.gameObject.SetActive(false) ;
        ShopButton2.gameObject.SetActive(false) ;
        ShopButton3.gameObject.SetActive(false) ;
        ShopButton4.gameObject.SetActive(false) ;
        AShopButton1.gameObject.SetActive(false) ;
        AShopButton2.gameObject.SetActive(false) ;
        AShopButton3.gameObject.SetActive(false) ;
        HUD.Instance.elementUI.SetActive(false);
    }
}
