using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AgumentManager : MonoSingeleton<AgumentManager>
{
    public GameObject augmentTab;
    public Agument_SO[] aquments;
    public Agument_SO Returner;
    public Image icon1, icon2, icon3;
    public TextMeshProUGUI Name1, Name2, Name3, Desc1, Desc2, Desc3;
    public int final1, final2, final3;
    public bool isOpenTab = false;


    public void OpenAugmentTAB()
    {
        if (isOpenTab)
        {
            return;
        }
       
         isOpenTab = true;
        StartCoroutine(OpenAgumentTabEnum());

    }
    
    public void CloseAugmentTAB()
    {
        augmentTab.SetActive(false);
        isOpenTab = false;
    }
    public void AugmentUpdate()
    {
        final1 = Random.Range(0, aquments.Length);
        icon1.sprite = aquments[final1].sprite;
        Desc1.text = aquments[final1].agumentDescription;
        Name1.text = aquments[final1].agumentName;

    }
    public void AugmentUpdate2()
    {
        final2 = Random.Range(0, aquments.Length);
        icon2.sprite = aquments[final2].sprite;
        Desc2.text = aquments[final2].agumentDescription;
        Name2.text = aquments[final2].agumentName;
    }
    public void AugmentUpdate3()
    {
        final3 = Random.Range(0, aquments.Length);
        icon3.sprite = aquments[final3].sprite;
        Desc3.text = aquments[final3].agumentDescription;
        Name3.text = aquments[final3].agumentName;
    }
    public void OnClickAuqments(int index)
    {
        switch (index)
        {
            case 0:
              BuildManager.Instance.towerToBuild =  aquments[final1];
                aquments[final1].Effect.Raise();
                BuildManager.Instance.BuildTowerOn();


                break;
            case 1:
               
                BuildManager.Instance.towerToBuild = aquments[final2];
                aquments[final2].Effect.Raise();
                BuildManager.Instance.BuildTowerOn();

                break;
            case 2:

                BuildManager.Instance.towerToBuild = aquments[final3];
                aquments[final3].Effect.Raise();
                BuildManager.Instance.BuildTowerOn();
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

    }
 

}

public enum AqumentType
{
    Tower,
    Army,
    Mine
}
