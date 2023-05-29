using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD :MonoSingeleton<HUD>
{
    [Header ("ELEMENT")]
    [Space(5)]
   [SerializeField] private bool elementTabOpen=false;
    public GameObject elementUI;
     public TMP_Text elementFireCostText;

    public TMP_Text  elementWatterCostText;

    public TMP_Text  elementAirCostText;

    public TMP_Text elementDirtCostText;

 public Button setVisionOrAttackHUD;
 public Unit normalUnit;
 public Unit speederUnit;
 public Unit armoredUnit;
    public TowerBlueprint ArrowedTower, BallTower, FireTower; 
    
    public TMP_Text normalUnitText;

    public TMP_Text speederUnitText;

    public TMP_Text armoredUnitText;

    public TMP_Text ArrowTowerText;

    public TMP_Text BallTowerText;

    public TMP_Text FireTowerText;

    public TMP_Text UpgradeText;

    public TMP_Text DestroyText;

    public TMP_Text InfoText;

    
    
    

 

public void Start () {
   InitShopHud();
}
public void InitShopHud () {
    normalUnitText.text=normalUnit.cost.ToString() + "$";
      speederUnitText.text=speederUnit.cost.ToString()+ "$";
        armoredUnitText.text=armoredUnit.cost.ToString()+ "$";
        ArrowTowerText.text = ArrowedTower.cost.ToString()+ "$";
        BallTowerText.text = BallTower.cost.ToString()+ "$";
        FireTowerText.text = FireTower.cost.ToString()+ "$";
   
        if(BuildManager.Instance.currentUpgradementTower){
        UpgradeText.text = BuildManager.Instance.currentUpgradementTower.currentUpgradeCost.ToString() + "$";
        elementFireCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementWatterCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementAirCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
         elementDirtCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        }
      
}       

    public void TakeUnit(Unit unit) {
        if (GameManager.Instance.Gold <= unit.cost) 
        {

            Debugger.Instance.Debuger(unit.name + "Satin almaya paran yetmedi gereken para :" + (unit.cost-GameManager.Instance.Gold));
        return;
        }
     GameManager.Instance.Gold-=unit.cost;
    if(unit==normalUnit)
    BattleManager.Instance.AddUnit(normalUnit);
    else if(unit==speederUnit)
    BattleManager.Instance.AddUnit(speederUnit);
    else if(unit==armoredUnit)
    BattleManager.Instance.AddUnit(armoredUnit);
   
  


 }
public void LevelUpTower () {   
       if(GameManager.Instance.Gold>= BuildManager.Instance.currentUpgradementTower.currentUpgradeCost){
        
    GameManager.Instance.Gold-=BuildManager.Instance.currentUpgradementTower.currentUpgradeCost;
            BuildManager.Instance.currentUpgradementTower.LevelUp();
            BuildManager.Instance.currentUpgradementTower.currentUpgradeCost= BuildManager.Instance.currentUpgradementTower.upgradeCostforNextLevel;
            InitShopHud();
        }
}
public void ElementTabOpen () {
    
    
    if(elementTabOpen){
        elementTabOpen=false;
        elementUI.SetActive(false);

    }
    else{
         elementTabOpen=true;
          elementUI.SetActive(true);
    }
}
public void ElementUIExit () {
        elementTabOpen=false;
        elementUI.SetActive(false);
}
public void SetTowerElement (int elementIndex) {
    if(BuildManager.Instance.currentUpgradementTower.element_Type==Element_Type.None&&GameManager.Instance.Gold>BuildManager.Instance.currentUpgradementTower.elementChanceCost){
        GameManager.Instance.Gold-=BuildManager.Instance.currentUpgradementTower.elementChanceCost;
         switch(elementIndex){
        case 0:
        BuildManager.Instance.currentUpgradementTower.element_Type=Element_Type.Fire;
        break;
          case 1:
        BuildManager.Instance.currentUpgradementTower.element_Type=Element_Type.Watter;
        break;
          case 2:
        BuildManager.Instance.currentUpgradementTower.element_Type=Element_Type.Air;
        break;
          case 3:
        BuildManager.Instance.currentUpgradementTower.element_Type=Element_Type.Dirt;
        break;

    }
    ElementUIExit();
    }
    else{
        Debugger.Instance.Debuger("Bu Kuleye zaten element atamasi yapildi");
    }
   
}

}
