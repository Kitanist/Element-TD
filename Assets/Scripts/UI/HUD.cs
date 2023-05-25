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
 public TMP_Text  normalUnitText;
 
 public TMP_Text  speederUnitText;
 
 public TMP_Text  armoredUnitText;

 public GameObject UpgradeUI;

public void Start () {
    InitShopHud();
}
public void InitShopHud () {
    normalUnitText.text=normalUnit.cost.ToString();
      speederUnitText.text=speederUnit.cost.ToString();
        armoredUnitText.text=armoredUnit.cost.ToString();
}

 public void TakeUnit (Unit unit) {
   if(GameManager.Instance.Gold<=unit.cost){
        GameManager.Instance.Gold-=unit.cost;
    if(unit==normalUnit)
    BattleManager.Instance.AddUnit(normalUnit);
    else if(unit==speederUnit)
    BattleManager.Instance.AddUnit(speederUnit);
    else if(unit==armoredUnit)
    BattleManager.Instance.AddUnit(armoredUnit);
   }
   else { 
    //yeterli para yok 
   }


 }
public void LevelUpTower () {   
       if(GameManager.Instance.Gold>=GameManager.Instance.currentUpgradementTower.currentUpgradeCost){
        
    GameManager.Instance.Gold-=GameManager.Instance.currentUpgradementTower.currentUpgradeCost;
    GameManager.Instance.currentUpgradementTower.LevelUp();
    GameManager.Instance.currentUpgradementTower.currentUpgradeCost=GameManager.Instance.currentUpgradementTower.upgradeCostforNextLevel;
       }
}
}
