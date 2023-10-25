using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkilType
{
    AugmentCount1Type,
    AugmentCount2Type,
}
public class SkillManager : MonoBehaviour
{
    public GameObject SkillTreeTAB;
    public Button aproveButton;
    private bool isAprovePoints=true;
    bool changeHapend = false;
    public void OnOpenSkillTAB()
    {
        SkillTreeTAB.SetActive(true);
        isAprovePoints = true;
        changeHapend = false;

    }
public void OnClickPlus(SkillBar skill)
    {
        if (skill.cost <= GameManager.Instance.skillPoint)
        {
            GameManager.Instance.skillPoint -= skill.cost; //skill puan harcar
            skill.blurObject.SetActive(false);
            switch (skill.type)
            {
                case SkilType.AugmentCount1Type:
                    GameManager.Instance.aqumentCount++;
                    GameManager.Instance.isAqumentCount1Open=true;
                    skill.plusButton.interactable = false;
                    skill.minusButton.interactable= true;
                    skill.isOpen=true;
                    aproveButton.interactable = true;
                    changeHapend = true;
                break;
                case SkilType.AugmentCount2Type:
                    GameManager.Instance.aqumentCount++;
                    GameManager.Instance.isAqumentCount2Open = true;
                    skill.plusButton.interactable = false;
                    skill.minusButton.interactable = true;
                    skill.isOpen = true;
                    aproveButton.interactable = true;
                    changeHapend = true;
                    break;
            }
            



        }
    }
    public void OnClickMinus(SkillBar skill)
    {
       
            GameManager.Instance.skillPoint += skill.cost; //skill puan harcar
            skill.blurObject.SetActive(true);
            switch (skill.type)
            {
                case SkilType.AugmentCount1Type:
                    GameManager.Instance.aqumentCount--;
                GameManager.Instance.isAqumentCount1Open = false;
                skill.plusButton.interactable = true;
                    skill.minusButton.interactable = false;
                    skill.isOpen = false;
                    aproveButton.interactable = true;
                    changeHapend = true;
                break;
            case SkilType.AugmentCount2Type:
                GameManager.Instance.aqumentCount--;
                GameManager.Instance.isAqumentCount2Open = false;
                skill.plusButton.interactable = true;
                skill.minusButton.interactable = false;
                skill.isOpen = false;
                aproveButton.interactable = true;
                changeHapend = true;
                break;
        }




        
    }
    public void OnClickAprovePoint()
    {
        
        SaveSystem.Instance.JsonSave();
        SkillTreeTAB.SetActive(false);
        SkillTreeTAB.SetActive(true);
        aproveButton.interactable = false;
        isAprovePoints = true;
        changeHapend = false;//tiklamayi resetledik

        //Close Panal and Reopen;
    }
    public void OnCloseSkillTreeTAB()
    {
        if (isAprovePoints && !changeHapend)
        {
            SkillTreeTAB.SetActive(false);
            

        }
     
        else
        {
            Debug.Log("Skill Agacini Onaylamalisiniz");
        }
    }
}
