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

 [Header("UNİT")]
  [Space(5)]
 public Unit normalFireUnit,normalWatterUnit,normalAirUnit,normalDirtUnit;
 public Unit speederFireUnit,speederWatterUnit,speederAirUnit,speederDirtUnit;
 public Unit armoredFireUnit,armoredWatterUnit,armoredAirUnit,armoredDirtUnit;
    public TowerBlueprint ArrowedTower, BallTower, FireTower; 
     [Header("UNİT TEXT")]
  [Space(5)]
    public TMP_Text normalFireUnitText;

    public TMP_Text speederFireUnitText;

    public TMP_Text armoredFireUnitText;

        public TMP_Text normalWatterUnitText;

    public TMP_Text speederWatterUnitText;

    public TMP_Text armoredWatterUnitText;

        public TMP_Text normalAirUnitText;

    public TMP_Text speederAirUnitText;

    public TMP_Text armoredAirUnitText;
        public TMP_Text normalDirtUnitText;

    public TMP_Text speederDirtUnitText;

    public TMP_Text armoredDirtUnitText;

 [Header("OTHER")]
  [Space(5)]

    public TMP_Text ArrowTowerText;

    public TMP_Text BallTowerText;

    public TMP_Text FireTowerText;

    public TMP_Text UpgradeText;

    public TMP_Text DestroyText;

    public TMP_Text InfoText;

    [Header("INFO")]
    [Space(5)]
    
    [SerializeField] private bool infoTabOpen=false;
    public GameObject infoUI;
    public TMP_Text towerNameText;
    public TMP_Text towerDamageText;

    public TMP_Text towerLevelText;

    public TMP_Text towerSpeedText;

     public TMP_Text towerElementText;
     public TMP_Text towerRangeText;

 [Header("UNİT COUNT")]
  [Space(5)]
   public GameObject[] AllUnitCountTexts;
   public GameObject[] AllMyUnitCountTexts;
   public int [] myUnitCounts;
 public void RefreshUnitCount () {
    
    for(int i = 0; i < AllUnitCountTexts.Length; i++) {
        if(WaveManager.Instance.waves[WaveManager.Instance.currentWaveCount].diffrentUnitCounts[i]>0){
             AllUnitCountTexts[i].SetActive(true);
             AllUnitCountTexts[i].transform.GetChild(0).GetComponent<TMP_Text>().text= " x"+WaveManager.Instance.waves[WaveManager.Instance.currentWaveCount].diffrentUnitCounts[i].ToString();
        }
        else{
            AllUnitCountTexts[i].SetActive(false);
        }
       
    }
 }
 public void RefreshMyUnitCount (Unit unit) {
    if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Fire){
       if( unit.unitType==UnitType.Normal){
            AllMyUnitCountTexts[0].SetActive(true);
            myUnitCounts[0]++;
             AllMyUnitCountTexts[0].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[0].ToString();
             AllMyUnitCountTexts[0].GetComponent<Image>().color=Color.red;
       }
      else if( unit.unitType==UnitType.Speeder){
            AllMyUnitCountTexts[1].SetActive(true);
            myUnitCounts[1]++;
             AllMyUnitCountTexts[1].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[1].ToString();
             AllMyUnitCountTexts[1].GetComponent<Image>().color=Color.red; 
       }
      else if( unit.unitType==UnitType.Armored){
            AllMyUnitCountTexts[2].SetActive(true);
            myUnitCounts[2]++;
             AllMyUnitCountTexts[2].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[2].ToString();
              AllMyUnitCountTexts[2].GetComponent<Image>().color=Color.red;
       }
    }
    else if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Watter){
          if( unit.unitType==UnitType.Normal){
            AllMyUnitCountTexts[3].SetActive(true);
            myUnitCounts[3]++;
             AllMyUnitCountTexts[3].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[3].ToString();
              AllMyUnitCountTexts[3].GetComponent<Image>().color=Color.blue;
       }
      else if( unit.unitType==UnitType.Speeder){
            AllMyUnitCountTexts[4].SetActive(true);
            myUnitCounts[4]++;
             AllMyUnitCountTexts[4].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[4].ToString();
              AllMyUnitCountTexts[4].GetComponent<Image>().color=Color.blue;
       }
      else if( unit.unitType==UnitType.Armored){
            AllMyUnitCountTexts[5].SetActive(true);
            myUnitCounts[5]++;
             AllMyUnitCountTexts[5].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[5].ToString();
                       AllMyUnitCountTexts[5].GetComponent<Image>().color=Color.blue;
       }
    }
     else if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Air){
          if( unit.unitType==UnitType.Normal){
            AllMyUnitCountTexts[6].SetActive(true);
            myUnitCounts[6]++;
             AllMyUnitCountTexts[6].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[6].ToString();
                       AllMyUnitCountTexts[6].GetComponent<Image>().color=Color.cyan;
       }
       else if( unit.unitType==UnitType.Speeder){
            AllMyUnitCountTexts[7].SetActive(true);
            myUnitCounts[7]++;
             AllMyUnitCountTexts[7].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[7].ToString();
                    AllMyUnitCountTexts[7].GetComponent<Image>().color=Color.cyan;
       }
       else if( unit.unitType==UnitType.Armored){
            AllMyUnitCountTexts[8].SetActive(true);
            myUnitCounts[8]++;
             AllMyUnitCountTexts[8].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[8].ToString();
                    AllMyUnitCountTexts[8].GetComponent<Image>().color=Color.cyan;
       }
    }
     else if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Dirt){
          if( unit.unitType==UnitType.Normal){
            AllMyUnitCountTexts[9].SetActive(true);
            myUnitCounts[9]++;
             AllMyUnitCountTexts[9].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[9].ToString();
                    AllMyUnitCountTexts[9].GetComponent<Image>().color=Color.yellow;
       }
      else if( unit.unitType==UnitType.Speeder){
            AllMyUnitCountTexts[10].SetActive(true);
            myUnitCounts[10]++;
             AllMyUnitCountTexts[10].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[10].ToString();
              AllMyUnitCountTexts[10].GetComponent<Image>().color=Color.yellow;
       }
      else if( unit.unitType==UnitType.Armored){
            AllMyUnitCountTexts[11].SetActive(true);
            myUnitCounts[11]++;
             AllMyUnitCountTexts[11].transform.GetChild(0).GetComponent<TMP_Text>().text=" x"+ myUnitCounts[11].ToString();
              AllMyUnitCountTexts[11].GetComponent<Image>().color=Color.yellow;
       }
    }
 }

public void Start () {
    RefreshUnitCount();
   InitShopHud();
}
public void InitShopHud () {
    normalFireUnitText.text=normalFireUnit.cost.ToString() + "$";
      speederFireUnitText.text=speederFireUnit.cost.ToString()+ "$";
        armoredFireUnitText.text=armoredFireUnit.cost.ToString()+ "$";
    /* normalWatterUnitText.text=normalWatterUnit.cost.ToString() + "$";
      speederWatterUnitText.text=speederWatterUnit.cost.ToString()+ "$";
        armoredWatterUnitText.text=armoredWatterUnit.cost.ToString()+ "$";   
    normalAirUnitText.text=normalAirUnit.cost.ToString() + "$";
      speederAirUnitText.text=speederAirUnit.cost.ToString()+ "$";
        armoredAirUnitText.text=armoredAirUnit.cost.ToString()+ "$";    
    normalDirtUnitText.text=normalDirtUnit.cost.ToString() + "$";
      speederDirtUnitText.text=speederDirtUnit.cost.ToString()+ "$";
        armoredDirtUnitText.text=armoredDirtUnit.cost.ToString()+ "$";   */




        ArrowTowerText.text = ArrowedTower.cost.ToString()+ "$";
        BallTowerText.text = BallTower.cost.ToString()+ "$";
        FireTowerText.text = FireTower.cost.ToString()+ "$";
   
        if(BuildManager.Instance.currentUpgradementTower){
        UpgradeText.text = BuildManager.Instance.currentUpgradementTower.currentUpgradeCost.ToString() + "$";
        elementFireCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementWatterCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementAirCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementDirtCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        //alt kısımda info ekranı set edilcek
        towerDamageText.text=BuildManager.Instance.currentUpgradementTower.damage.ToString();
        towerElementText.text=BuildManager.Instance.currentUpgradementTower.element_Type.ToString();
        towerLevelText.text=BuildManager.Instance.currentUpgradementTower.level.ToString();
        towerSpeedText.text=BuildManager.Instance.currentUpgradementTower.fireRate.ToString();
        towerRangeText.text=BuildManager.Instance.currentUpgradementTower.attackRadius.ToString();
        towerNameText.text=BuildManager.Instance.currentUpgradementTower.Name;

        }
      
}       

    public void TakeUnit(Unit unit) {
        if (GameManager.Instance.Gold <= unit.cost) 
        {

            Debugger.Instance.Debuger(unit.name + "Satin almaya paran yetmedi gereken para :" + (unit.cost-GameManager.Instance.Gold));
        return;

        }
        Debug.Log("saaaaaaaaaaaaaaaaaa");
     GameManager.Instance.Gold-=unit.cost;
   if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Fire){
    if(unit==normalFireUnit)
    BattleManager.Instance.AddUnit(normalFireUnit);
    else if(unit==speederFireUnit)
    BattleManager.Instance.AddUnit(speederFireUnit);
    else if(unit==armoredFireUnit)
    BattleManager.Instance.AddUnit(armoredFireUnit);
    }
    else  if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Watter){
    if(unit==normalWatterUnit)
    BattleManager.Instance.AddUnit(normalWatterUnit);
    else if(unit==speederWatterUnit)
    BattleManager.Instance.AddUnit(speederWatterUnit);
    else if(unit==armoredWatterUnit)
    BattleManager.Instance.AddUnit(armoredWatterUnit);
    }
    else  if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Air){
    if(unit==normalAirUnit)
    BattleManager.Instance.AddUnit(normalAirUnit);
    else if(unit==speederAirUnit)
    BattleManager.Instance.AddUnit(speederAirUnit);
    else if(unit==armoredAirUnit)
    BattleManager.Instance.AddUnit(armoredAirUnit);
    }
     else  if(unit.GetComponent<HealthComponent>().myElement==Element_Type.Dirt){
    if(unit==normalDirtUnit)
    BattleManager.Instance.AddUnit(normalDirtUnit);
    else if(unit==speederDirtUnit)
    BattleManager.Instance.AddUnit(speederDirtUnit);
    else if(unit==armoredDirtUnit)
    BattleManager.Instance.AddUnit(armoredDirtUnit);
    }
    
   
  RefreshMyUnitCount(unit);


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

public void OpenInfoUI () {
    InitShopHud();
    if(infoTabOpen){
        infoTabOpen=false;
        infoUI.SetActive(false);

    }
    else{
         infoTabOpen=true;
          infoUI.SetActive(true);
    }
}
public void ExitInfoUI () {
         infoTabOpen=false;
        infoUI.SetActive(false);
}
}
