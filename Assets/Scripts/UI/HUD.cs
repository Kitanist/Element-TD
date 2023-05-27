using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD :MonoSingeleton<HUD>
{
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
        UpgradeText.text = BuildManager.Instance.currentUpgradementTower.currentUpgradeCost.ToString() + "$";
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
}
