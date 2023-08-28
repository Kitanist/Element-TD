using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AgumentManager : MonoSingeleton<AgumentManager>
{
    public GameObject augmentTab;
    public Agument_SO[] aquments;
    public Agument_SO[] UnitAquments;
    public Agument_SO Returner;
    public Image icon1, icon2, icon3;
    public TextMeshProUGUI Name1, Name2, Name3, Desc1, Desc2, Desc3,cost1,cost2,cost3;
    public int final1, final2, final3;
    public bool isOpenTab = false;
    public bool isUnitTabOpen= false;
    public bool isIn= false;
    public void OpenAugmentTAB()
    {

        if (isOpenTab)
        {
            return;
        }
    
         isOpenTab = true;
        StartCoroutine(OpenAgumentTabEnum());


    }
    public void OpenUnitAugmentTAB()
    {

        if (isOpenTab)
        {
            return;
        }
       
        isUnitTabOpen = true;
        isOpenTab = true;
        StartCoroutine(OpenAgumentUnitTabEnum());
     

    }
   

    public void CloseAugmentTAB()
    {
        augmentTab.SetActive(false);
        isOpenTab = false;
        isUnitTabOpen = false;
        isIn= false;
    }
    public void AugmentUpdate()

    {
        if(isIn)
        {
          
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    final1 = Random.Range(0, UnitAquments.Length);
                    icon1.sprite = UnitAquments[final1].sprite;
                    Desc1.text = UnitAquments[final1].agumentDescription;
                    Name1.text = UnitAquments[final1].agumentName;
                    cost1.text = UnitAquments[final1].Cost.ToString();
                }
                else
                {

                    final1 = Random.Range(0, aquments.Length);
                    icon1.sprite = aquments[final1].sprite;
                    Desc1.text = aquments[final1].agumentDescription;
                    Name1.text = aquments[final1].agumentName;
                    cost1.text = aquments[final1].Cost.ToString();
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
                final1 = Random.Range(0, UnitAquments.Length);
                icon1.sprite = UnitAquments[final1].sprite;
                Desc1.text = UnitAquments[final1].agumentDescription;
                Name1.text = UnitAquments[final1].agumentName;
                cost1.text = UnitAquments[final1].Cost.ToString();
            }
            else
            {

                final1 = Random.Range(0, aquments.Length);
                icon1.sprite = aquments[final1].sprite;
                Desc1.text = aquments[final1].agumentDescription;
                Name1.text = aquments[final1].agumentName;
                cost1.text = aquments[final1].Cost.ToString();
            }
        }
    


    }
    public void AugmentUpdate2()
    {
        if (isIn)
        {
   
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    final2 = Random.Range(0, UnitAquments.Length);
                    icon2.sprite = UnitAquments[final2].sprite;
                    Desc2.text = UnitAquments[final2].agumentDescription;
                    Name2.text = UnitAquments[final2].agumentName;
                    cost2.text = UnitAquments[final2].Cost.ToString();

                }
                else
                {
                    final2 = Random.Range(0, aquments.Length);
                    icon2.sprite = aquments[final2].sprite;
                    Desc2.text = aquments[final2].agumentDescription;
                    Name2.text = aquments[final2].agumentName;
                    cost2.text = aquments[final2].Cost.ToString();
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
                final2 = Random.Range(0, UnitAquments.Length);
                icon2.sprite = UnitAquments[final2].sprite;
                Desc2.text = UnitAquments[final2].agumentDescription;
                Name2.text = UnitAquments[final2].agumentName;
                cost2.text = UnitAquments[final2].Cost.ToString();

            }
            else
            {
                final2 = Random.Range(0, aquments.Length);
                icon2.sprite = aquments[final2].sprite;
                Desc2.text = aquments[final2].agumentDescription;
                Name2.text = aquments[final2].agumentName;
                cost2.text = aquments[final2].Cost.ToString();
            }
        }
       
    
    }
    public void AugmentUpdate3()
    {
        if (isIn)
        {
            Debug.Log("hiii");
            if (GameManager.Instance.Gold > 10)
            {
                if (isUnitTabOpen)
                {
                    final3 = Random.Range(0, UnitAquments.Length);
                    icon3.sprite = UnitAquments[final3].sprite;
                    Desc3.text = UnitAquments[final3].agumentDescription;
                    Name3.text = UnitAquments[final3].agumentName;
                    cost3.text = UnitAquments[final3].Cost.ToString();
                }
                else
                {
                    final3 = Random.Range(0, aquments.Length);
                    icon3.sprite = aquments[final3].sprite;
                    Desc3.text = aquments[final3].agumentDescription;
                    Name3.text = aquments[final3].agumentName;
                    cost3.text = aquments[final3].Cost.ToString();
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
                final3 = Random.Range(0, UnitAquments.Length);
                icon3.sprite = UnitAquments[final3].sprite;
                Desc3.text = UnitAquments[final3].agumentDescription;
                Name3.text = UnitAquments[final3].agumentName;
                cost3.text = UnitAquments[final3].Cost.ToString();
            }
            else
            {
                final3 = Random.Range(0, aquments.Length);
                icon3.sprite = aquments[final3].sprite;
                Desc3.text = aquments[final3].agumentDescription;
                Name3.text = aquments[final3].agumentName;
                cost3.text = aquments[final3].Cost.ToString();
            }
        }
      
    }


    public void UnitAugmentUpdate()
    {

       
        
            final1 = Random.Range(0, UnitAquments.Length);
            icon1.sprite = UnitAquments[final1].sprite;
            Desc1.text = UnitAquments[final1].agumentDescription;
            Name1.text = UnitAquments[final1].agumentName;
            cost1.text = UnitAquments[final1].Cost.ToString();
        


    }
    public void UnitAugmentUpdate2()
    {
        final2 = Random.Range(0, UnitAquments.Length);
        icon2.sprite = UnitAquments[final2].sprite;
        Desc2.text = UnitAquments[final2].agumentDescription;
        Name2.text = UnitAquments[final2].agumentName;
        cost1.text = UnitAquments[final2].Cost.ToString();
    }
    public void UnitAugmentUpdate3()
    {
        final3 = Random.Range(0, UnitAquments.Length);
        icon3.sprite = UnitAquments[final3].sprite;
        Desc3.text = UnitAquments[final3].agumentDescription;
        Name3.text = UnitAquments[final3].agumentName;
        cost1.text = UnitAquments[final3].Cost.ToString();
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

                    }
                  
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[final1].Cost)
                    {
                        GameManager.Instance.Gold -= aquments[final1].Cost;

                        BuildManager.Instance.towerToBuild = aquments[final1];

                        BuildManager.Instance.BuildTowerOn();
                        CloseAugmentTAB();
                    }

                  
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

                    }
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[final2].Cost)
                    {
                        GameManager.Instance.Gold -= aquments[final2].Cost;

                        BuildManager.Instance.towerToBuild = aquments[final2];

                        BuildManager.Instance.BuildTowerOn();
                        CloseAugmentTAB();
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

                    }
                
                }
                else
                {
                    if (GameManager.Instance.Gold >= aquments[final3].Cost)
                    {
                        GameManager.Instance.Gold -= aquments[final3].Cost;
                        BuildManager.Instance.towerToBuild = aquments[final3];

                        BuildManager.Instance.BuildTowerOn();
                        CloseAugmentTAB();

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

        augmentTab.SetActive(true);
        AugmentUpdate();
        AugmentUpdate2();
        AugmentUpdate3();
        isIn = true;

    }

    public IEnumerator OpenAgumentUnitTabEnum()
    {
        // Openin animation enter and wait for anim end
        yield return new WaitForSeconds(.1f);

       augmentTab.SetActive(true);
        
        UnitAugmentUpdate();
        UnitAugmentUpdate2();
        UnitAugmentUpdate3();
        isIn = true;
    }

}

public enum AqumentType
{
    Tower,
    Army,
    Mine
}
