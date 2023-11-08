using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class AgumentManager : MonoSingeleton<AgumentManager>
{
    public GameObject exitButton;
    public GameObject[] augmentPrefabs;
    public Agument_SO[] aquments;
    public Agument_SO[] UnitAquments;
    public Agument_SO Returner;
    public Image icon1, icon2, icon3;
    public TextMeshProUGUI Name1, Name2, Name3, Desc1, Desc2, Desc3, cost1, cost2, cost3, refreshCount1, refreshCount2, refreshCount3;
    public int final1=-1, final2=-1, final3=-1;
    public int Ufinal1 = -1, Ufinal2 = -1, Ufinal3 = -1;
    public bool isOpenTab = false;
    public bool isUnitTabOpen= false;
    public bool isIn= false;

    public int augment1RollCont, augment2RolCont, augment3RollCont;
    public int Uaugment1RollCont, Uaugment2RolCont, Uaugment3RollCont;
    public bool isRooling=false;
    public CanvasGroup aqumentCanvasGroup;
    public RectTransform aqumentRectTransform;
    public float fadeTimeAqument;
    public void OpenAugmentTAB()
    {


        if (isOpenTab)
        {
            return;
        }

        exitButton.SetActive(true);
        isOpenTab = true;
        StartCoroutine(OpenAgumentTabEnum());
    

    }
    public void OpenUnitAugmentTAB()
    {
       
        if (isOpenTab)
        {
            return;
        }
        exitButton.SetActive(true);

        isUnitTabOpen = true;
        isOpenTab = true;
        StartCoroutine(OpenAgumentUnitTabEnum());
        

    }
   

    public void CloseAugmentTAB()
    {
        //augmentTab.SetActive(false);
        isOpenTab = false;
        isUnitTabOpen = false;
        isIn= false;
        exitButton.SetActive(false);
        AqumentFadeOut();
    }
    public void IsRolling()
    {
        isRooling = true;
    }
    public void AugmentUpdate()

    {
        if(isIn)
        {
          
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    if(final1==-1 || (isRooling && augment1RollCont < GameManager.Instance.aqumentRollCount))
                    {
                        final1 = Random.Range(0, UnitAquments.Length);
                        augment1RollCont++;
                    }
                
                    icon1.sprite = UnitAquments[final1].sprite;
                    Desc1.text = UnitAquments[final1].agumentDescription;
                    Name1.text = UnitAquments[final1].agumentName;
                    cost1.text = UnitAquments[final1].Cost.ToString();
                    refreshCount1.text = (GameManager.Instance.aqumentRollCount- augment1RollCont).ToString();
                }
                else
                {
                    if (Ufinal1 == -1 || (isRooling && Uaugment1RollCont < GameManager.Instance.aqumentRollCount))
                    {
                        Ufinal1 = Random.Range(0, aquments.Length);
                        Uaugment1RollCont++;
                    }
                    
                    icon1.sprite = aquments[Ufinal1].sprite;
                    Desc1.text = aquments[Ufinal1].agumentDescription;
                    Name1.text = aquments[Ufinal1].agumentName;
                    cost1.text = aquments[Ufinal1].Cost.ToString();
                    refreshCount1.text =(GameManager.Instance.aqumentRollCount - Uaugment1RollCont).ToString();
                }
                GameManager.Instance.Gold -= 10;
            }
            else
            {

            }
        }
          else
         {

            if (isUnitTabOpen)
             {
                 if (final1 == -1 || (isRooling && augment1RollCont < GameManager.Instance.aqumentRollCount))
                 {
                     final1 = Random.Range(0, UnitAquments.Length);
                     augment1RollCont++;
                 }

                 icon1.sprite = UnitAquments[
                 final1].sprite;
                 Desc1.text = UnitAquments[final1].agumentDescription;
                 Name1.text = UnitAquments[final1].agumentName;
                 cost1.text = UnitAquments[final1].Cost.ToString();
                refreshCount1.text = (GameManager.Instance.aqumentRollCount- augment1RollCont).ToString();
            }
             else
             {

                 if (Ufinal1 == -1 || (isRooling && Uaugment1RollCont < GameManager.Instance.aqumentRollCount))
                 {
                     Ufinal1 = Random.Range(0, aquments.Length);
                    // Uaugment1RollCont++; //buralarda arttırınca fazladan hata veriyor bu ilk açılış için olduğundan  ilk açılış için -1 se kontrolü zaten sağlanıyor
                 }

                 icon1.sprite = aquments[Ufinal1].sprite;
                 Desc1.text = aquments[Ufinal1].agumentDescription;
                 Name1.text = aquments[Ufinal1].agumentName;
                 cost1.text = aquments[Ufinal1].Cost.ToString();
                refreshCount1.text = (GameManager.Instance.aqumentRollCount- Uaugment1RollCont) .ToString();
            }
         }


        isRooling = false;

    }
    public void AugmentUpdate2()
    {
        if (isIn)
        {
   
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    
                    if (final2 == -1 || (isRooling && augment2RolCont< GameManager.Instance.aqumentRollCount))
                    {
                        final2= Random.Range(0, UnitAquments.Length);
                        augment2RolCont++;
                    }
                    icon2.sprite = UnitAquments[final2].sprite;
                    Desc2.text = UnitAquments[final2].agumentDescription;
                    Name2.text = UnitAquments[final2].agumentName;
                    cost2.text = UnitAquments[final2].Cost.ToString();
                    refreshCount2.text = (GameManager.Instance.aqumentRollCount- augment2RolCont).ToString();

                }
                else
                {
                    
                    if (Ufinal2 == -1 || (isRooling && Uaugment2RolCont < GameManager.Instance.aqumentRollCount))
                    {
                        Ufinal2 = Random.Range(0, aquments.Length);
                       Uaugment2RolCont++;
                    }
                    icon2.sprite = aquments[Ufinal2].sprite;
                    Desc2.text = aquments[Ufinal2].agumentDescription;
                    Name2.text = aquments[Ufinal2].agumentName;
                    cost2.text = aquments[Ufinal2].Cost.ToString();
                    refreshCount2.text =(GameManager.Instance.aqumentRollCount- Uaugment2RolCont) .ToString();
                }
                GameManager.Instance.Gold -= 10;
            }
            else
            {

            }


        }
        else
        {
            if (isUnitTabOpen)
            {
                if (final2 == -1 || (isRooling && augment2RolCont < GameManager.Instance.aqumentRollCount))
                {
                    final2 = Random.Range(0, UnitAquments.Length);
                 augment2RolCont++;
                }
                icon2.sprite = UnitAquments[final2].sprite;
                Desc2.text = UnitAquments[final2].agumentDescription;
                Name2.text = UnitAquments[final2].agumentName;
                cost2.text = UnitAquments[final2].Cost.ToString();
                refreshCount2.text = (GameManager.Instance.aqumentRollCount- augment2RolCont).ToString();
            }
            else
            {
                if (Ufinal2 == -1 || (isRooling && Uaugment2RolCont < GameManager.Instance.aqumentRollCount))
                {
                    Ufinal2 = Random.Range(0, aquments.Length);
               //  Uaugment2RolCont++;
                }
                icon2.sprite = aquments[Ufinal2].sprite;
                Desc2.text = aquments[Ufinal2].agumentDescription;
                Name2.text = aquments[Ufinal2].agumentName;
                cost2.text = aquments[Ufinal2].Cost.ToString();
                refreshCount2.text =(GameManager.Instance.aqumentRollCount- Uaugment2RolCont) .ToString();
            }
        }

        isRooling = false;
    }
    public void AugmentUpdate3()
    {
        if (isIn)
        {
          
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    
                    if (final3 == -1 || (isRooling && augment3RollCont < GameManager.Instance.aqumentRollCount))
                    {
                        final3 = Random.Range(0, UnitAquments.Length);
                        augment3RollCont++;
                    }
                    icon3.sprite = UnitAquments[final3].sprite;
                    Desc3.text = UnitAquments[final3].agumentDescription;
                    Name3.text = UnitAquments[final3].agumentName;
                    cost3.text = UnitAquments[final3].Cost.ToString();
                    refreshCount3.text =(GameManager.Instance.aqumentRollCount- augment3RollCont) .ToString();
                }
                else
                {
                    
                    if (Ufinal3 == -1 || (isRooling &&Uaugment3RollCont< GameManager.Instance.aqumentRollCount))
                    {
                        Ufinal3 = Random.Range(0, aquments.Length);
                      Uaugment3RollCont++;
                    }
                    icon3.sprite = aquments[Ufinal3].sprite;
                    Desc3.text = aquments[Ufinal3].agumentDescription;
                    Name3.text = aquments[Ufinal3].agumentName;
                    cost3.text = aquments[Ufinal3].Cost.ToString();
                    refreshCount3.text = (GameManager.Instance.aqumentRollCount- Uaugment3RollCont).ToString();
                }
                GameManager.Instance.Gold -= 10;
            }
            else
            {

            }
        }
        else
        {
            if (isUnitTabOpen)
            {
                if (final3 == -1 || (isRooling && augment3RollCont < GameManager.Instance.aqumentRollCount))
                {
                    final3 = Random.Range(0, UnitAquments.Length);
                    augment3RollCont++;
                }
                icon3.sprite = UnitAquments[final3].sprite;
                Desc3.text = UnitAquments[final3].agumentDescription;
                Name3.text = UnitAquments[final3].agumentName;
                cost3.text = UnitAquments[final3].Cost.ToString();
                refreshCount3.text =(GameManager.Instance.aqumentRollCount- augment3RollCont) .ToString();
            }
            else
            {
                if (Ufinal3 == -1 || (isRooling && Uaugment3RollCont < GameManager.Instance.aqumentRollCount))
                {
                    Ufinal3 = Random.Range(0, aquments.Length);
                  //  Uaugment3RollCont++;
                }
                icon3.sprite = aquments[Ufinal3].sprite;
                Desc3.text = aquments[Ufinal3].agumentDescription;
                Name3.text = aquments[Ufinal3].agumentName;
                cost3.text = aquments[Ufinal3].Cost.ToString();
                refreshCount3.text = (GameManager.Instance.aqumentRollCount- Uaugment3RollCont).ToString();
            }
        }
        isRooling = false;
    }


   public void UnitAugmentUpdate()
    {


        if (final1 == -1 || (isRooling && augment1RollCont < GameManager.Instance.aqumentRollCount))
        {

            final1 = Random.Range(0, UnitAquments.Length);
          // augment1RollCont++;
        }
        icon1.sprite = UnitAquments[final1].sprite;
            Desc1.text = UnitAquments[final1].agumentDescription;
            Name1.text = UnitAquments[final1].agumentName;
            cost1.text = UnitAquments[final1].Cost.ToString();
          refreshCount1.text =(GameManager.Instance.aqumentRollCount - augment1RollCont).ToString();

        isRooling = false;
    }
    public void UnitAugmentUpdate2()
    {
        if (final2 == -1 || (isRooling && augment2RolCont < GameManager.Instance.aqumentRollCount))
        {
            final2 = Random.Range(0, UnitAquments.Length);
          //  augment2RolCont++;
        }
        icon2.sprite = UnitAquments[final2].sprite;
        Desc2.text = UnitAquments[final2].agumentDescription;
        Name2.text = UnitAquments[final2].agumentName;
        cost1.text = UnitAquments[final2].Cost.ToString();
        refreshCount2.text = (GameManager.Instance.aqumentRollCount- augment2RolCont).ToString();
        isRooling = false;
    }
    public void UnitAugmentUpdate3()
    {
      
        if (final3 == -1 || (isRooling && augment3RollCont < GameManager.Instance.aqumentRollCount))
        {
            final3 = Random.Range(0, UnitAquments.Length);
            //
            //augment3RollCont++;
        }
        icon3.sprite = UnitAquments[final3].sprite;
        Desc3.text = UnitAquments[final3].agumentDescription;
        Name3.text = UnitAquments[final3].agumentName;
        cost1.text = UnitAquments[final3].Cost.ToString();
        refreshCount3.text = (GameManager.Instance.aqumentRollCount- augment3RollCont).ToString();
        isRooling = false;
    }
    public void OnClickAuqments(int index)
    {
        switch (index)
        {
            case 0:
                 if(isUnitTabOpen)
                {
                    if(GameManager.Instance.Gold >= UnitAquments[final1].Cost)
                    {
                        GameManager.Instance.Gold -= UnitAquments[final1].Cost;
                      
                        for (int i = 0; i < UnitAquments[final1].AmountSoldier; i++)
                        {
                           
                            HUD.Instance.TakeUnit(UnitAquments[final1].prefab.GetComponent<Unit>());
                            CloseAugmentTAB();

                        }
                        final1 = -1;
                    }
                  
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[Ufinal1].Cost)
                    {
                      
                        GameManager.Instance.Gold -= aquments[Ufinal1].Cost;
                    

                        BuildManager.Instance.towerToBuild = aquments[Ufinal1];

                        BuildManager.Instance.BuildTowerOn();

                        CloseAugmentTAB();
                    }
                    Ufinal1 = -1;

                }
              


                break;
            case 1:

                if (isUnitTabOpen)
                {
                    if (GameManager.Instance.Gold >= UnitAquments[final2].Cost)
                    {
                        GameManager.Instance.Gold -= UnitAquments[final2].Cost;
                        for (int i = 0; i < UnitAquments[final2].AmountSoldier; i++)
                        {
                           
                            HUD.Instance.TakeUnit(UnitAquments[final2].prefab.GetComponent<Unit>());
                            CloseAugmentTAB();

                        }
                        final2 = -1;
                    }
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[Ufinal2].Cost)
                    {
                        GameManager.Instance.Gold -= aquments[Ufinal2].Cost;

                        BuildManager.Instance.towerToBuild = aquments[Ufinal2];

                        BuildManager.Instance.BuildTowerOn();
                        CloseAugmentTAB();
                        Ufinal2 = -1;
                    }
                    
                }
     

                break;
            case 2:
                if (isUnitTabOpen)
                {

                    if (GameManager.Instance.Gold >= UnitAquments[final3].Cost) 
                    {
                        GameManager.Instance.Gold -= UnitAquments[final3].Cost;
                        for (int i = 0; i < UnitAquments[final3].AmountSoldier; i++)
                        {
                         
                            HUD.Instance.TakeUnit(UnitAquments[final3].prefab.GetComponent<Unit>());

                            CloseAugmentTAB();
                        }
                        final3 = -1;
                    }
                
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[Ufinal3].Cost)
                    {
                        GameManager.Instance.Gold -= aquments[Ufinal3].Cost;
                        BuildManager.Instance.towerToBuild = aquments[Ufinal3];

                        BuildManager.Instance.BuildTowerOn();
                        CloseAugmentTAB();
                        Ufinal3 = -1;
                    }
                  
                }
      
                break;
            default:
                break;
        }
        CloseAugmentTAB(); 
    }
    public IEnumerator OpenAgumentTabEnum() 
    {
        // Openin animation enter and wait for anim end
        yield return new WaitForSeconds(.1f);
      
       // augmentTab.SetActive(true);
        AugmentUpdate();
        AugmentUpdate2();
        AugmentUpdate3();
        AqumentFadeIn();
        isIn = true;

    }

    public IEnumerator OpenAgumentUnitTabEnum()
    {
        // Openin animation enter and wait for anim end
        yield return new WaitForSeconds(.1f);

        // augmentTab.SetActive(true);
   
        UnitAugmentUpdate();
        UnitAugmentUpdate2();
        UnitAugmentUpdate3();
        AqumentFadeIn();
        isIn = true;
    }

    public void AqumentFadeIn()
    {
        aqumentCanvasGroup.alpha = 0;
        aqumentRectTransform.transform.localPosition = new Vector3(0, 1000, 0);
        aqumentRectTransform.DOAnchorPos(new Vector2(0, 0), fadeTimeAqument, false).SetEase(Ease.OutElastic);
        aqumentCanvasGroup.DOFade(1, fadeTimeAqument);
        foreach (var prefabs in augmentPrefabs)
        {
            prefabs.SetActive(true);
            prefabs.GetComponent<CanvasGroup>().DOFade(1, fadeTimeAqument);

            prefabs.transform.DOShakeRotation(fadeTimeAqument,30,10,30,true,ShakeRandomnessMode.Full).SetEase(Ease.OutElastic);
        }
        StartCoroutine(FadeInAnim());

    }
    public void AqumentFadeOut()
    {
        aqumentCanvasGroup.alpha = 1;
        aqumentRectTransform.transform.localPosition = new Vector3(0, 0, 0);
        aqumentRectTransform.DOAnchorPos(new Vector2(0, 1000), fadeTimeAqument, false).SetEase(Ease.Linear);
        aqumentCanvasGroup.DOFade(0, fadeTimeAqument);
        foreach (var prefabs in augmentPrefabs)
        {
            prefabs.GetComponent<CanvasGroup>().DOFade(0, fadeTimeAqument);
        
        }
    }
    IEnumerator FadeInAnim()
    {

        foreach (var prefabs in augmentPrefabs)
        {
            prefabs.transform.localScale = Vector3.zero;
         
         }
        foreach (var prefabs in augmentPrefabs)
        {
            prefabs.transform.DOScale(Vector3.one, fadeTimeAqument).SetEase(Ease.OutBounce);
      
            yield return new WaitForSeconds(.25f);
        }

      
    }
}


public enum AqumentType
{
    Tower,
    Army,
    Mine
}
