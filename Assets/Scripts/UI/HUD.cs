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

    public GameObject normalFireUI, normalWaterUI, normalAirUI, normalEarthUI,normalNormalUI;
    public GameObject speedFireUI, speedWaterUI, speedAirUI, speedEarthUI, speedNormalUI;
    public GameObject armoredFireUI, armoredWaterUI, armoredAirUI, armoredEarthUI, armoredNormalUI;

    public TMP_Text elementFireCostText;

    public TMP_Text  elementWatterCostText;

    public TMP_Text  elementAirCostText;

    public TMP_Text elementDirtCostText;

 public Button setVisionOrAttackHUD;

 [Header("UNİT")]
  [Space(5)]
 public Unit normalFireUnit,normalWatterUnit,normalAirUnit,normalDirtUnit;
 public Unit normalUnit, normalSpeedUnit, normalArmoredUnit;
    public Unit speederFireUnit,speederWatterUnit,speederAirUnit,speederDirtUnit;
 public Unit armoredFireUnit,armoredWatterUnit,armoredAirUnit,armoredDirtUnit;
    public TowerBlueprint ArrowedTower, BallTower, FireTower,GoldMine; 
     [Header("UNİT TEXT")]
  [Space(5)]
    public TMP_Text normalUnitText;

    public TMP_Text speederUnitText;

    public TMP_Text armoredUnitText;

  

 [Header("OTHER")]
  [Space(5)]

    public TMP_Text ArrowTowerText;

    public TMP_Text BallTowerText;

    public TMP_Text FireTowerText;

    public TMP_Text GoldTowerText;

    public TMP_Text UpgradeText;

    public TMP_Text DestroyText;

    public TMP_Text InfoText;

    [Header("INFO")]
    [Space(5)]
    
    [SerializeField] private bool infoTabOpen=false;
    public GameObject infoUI;

    public TMP_Text towerDamageNameText;
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
    if(WaveManager.Instance.currentWaveCount<WaveManager.Instance.waves.Length){
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
     else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.None)
        {
            if (unit.unitType == UnitType.Normal)
            {
                AllMyUnitCountTexts[12].SetActive(true);
                myUnitCounts[12]++;
                AllMyUnitCountTexts[12].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[12].ToString();
                AllMyUnitCountTexts[12].GetComponent<Image>().color = Color.white;
            }
            else if (unit.unitType == UnitType.Speeder)
            {
                AllMyUnitCountTexts[13].SetActive(true);
                myUnitCounts[13]++;
                AllMyUnitCountTexts[13].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[13].ToString();
                AllMyUnitCountTexts[13].GetComponent<Image>().color = Color.white;
            }
            else if (unit.unitType == UnitType.Armored)
            {
                AllMyUnitCountTexts[14].SetActive(true);
                myUnitCounts[14]++;
                AllMyUnitCountTexts[14].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[14].ToString();
                AllMyUnitCountTexts[14].GetComponent<Image>().color = Color.white;
            }
            else if (unit.unitType == UnitType.Boss)
            {
                AllMyUnitCountTexts[15].SetActive(true);
                myUnitCounts[15]++;
                AllMyUnitCountTexts[15].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[14].ToString();
                AllMyUnitCountTexts[15].GetComponent<Image>().color = Color.white;
            }

        }
    }

public void Start () {
    RefreshUnitCount();
   InitShopHud();
}
public void InitShopHud () {
    normalUnitText.text=normalFireUnit.cost.ToString() + "$";
      speederUnitText.text=speederFireUnit.cost.ToString()+ "$";
        armoredUnitText.text=armoredFireUnit.cost.ToString()+ "$";
  



        ArrowTowerText.text = ArrowedTower.cost.ToString()+ "$";
        BallTowerText.text = BallTower.cost.ToString()+ "$";
        FireTowerText.text = FireTower.cost.ToString()+ "$";
        GoldTowerText.text =GoldMine.cost.ToString()+ "$";
   
        if(BuildManager.Instance.currentUpgradementTower){
        UpgradeText.text = BuildManager.Instance.currentUpgradementTower.currentUpgradeCost.ToString() + "$";
        elementFireCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementWatterCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementAirCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        elementDirtCostText.text= BuildManager.Instance.currentUpgradementTower.elementChanceCost.ToString()+ "$";
        //alt kısımda info ekranı set edilcek
       if( BuildManager.Instance.currentUpgradementTower.GetComponent<GoldMine>()){
         towerDamageText.text=BuildManager.Instance.currentUpgradementTower.GetComponent<GoldMine>().collectAmount.ToString();
         towerDamageNameText.text="Collect Amount:";
       }
       else{
         towerDamageText.text=BuildManager.Instance.currentUpgradementTower.damage.ToString();
         towerDamageNameText.text="Damage     :";
       }
       
        towerElementText.text=BuildManager.Instance.currentUpgradementTower.element_Type.ToString();
        towerLevelText.text=BuildManager.Instance.currentUpgradementTower.level.ToString();
          if( BuildManager.Instance.currentUpgradementTower.GetComponent<GoldMine>()){
         towerSpeedText.text=(BuildManager.Instance.currentUpgradementTower.GetComponent<GoldMine>().collectRate/BuildManager.Instance.currentUpgradementTower.GetComponent<GoldMine>().speed).ToString();
       }
       else
        towerSpeedText.text=BuildManager.Instance.currentUpgradementTower.fireRate.ToString();
        towerRangeText.text=BuildManager.Instance.currentUpgradementTower.attackRadius.ToString();
        towerNameText.text=BuildManager.Instance.currentUpgradementTower.Name;

        }
      
}       
    public void UnitNormalElementSelect()
    {

 if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        normalAirUI.SetActive(true);
        normalEarthUI.SetActive(true);
        normalWaterUI.SetActive(true);
        normalFireUI.SetActive(true);
        normalNormalUI.SetActive(true);
        UnitSpeedDeElementSelect();
        UnitArmoredDeElementSelect();
        TheUI.Instance.AShopButton1.image.enabled = false ;
        TheUI.Instance.AShop1.transform.GetChild(0).GetComponent<TMP_Text>().text="";

    }
    public void UnitNormalDeElementSelect()
    {
        normalAirUI.SetActive(false);
        normalEarthUI.SetActive(false);
        normalWaterUI.SetActive(false);
        normalFireUI.SetActive(false);
        normalNormalUI.SetActive(false);
        TheUI.Instance.AShopButton1.image.enabled = true;
        TheUI.Instance.AShop1.transform.GetChild(0).GetComponent<TMP_Text>().text="Normal Unit";
    }
    public void UnitSpeedElementSelect()
    {
         if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        speedAirUI.SetActive(true);
        speedEarthUI.SetActive(true);
        speedWaterUI.SetActive(true);
        speedFireUI.SetActive(true);
        speedNormalUI.SetActive(true);
        UnitNormalDeElementSelect();
        UnitArmoredDeElementSelect();
        TheUI.Instance.AShopButton2.image.enabled = false;
         TheUI.Instance.AShop2.transform.GetChild(0).GetComponent<TMP_Text>().text="";
    }
    public void UnitSpeedDeElementSelect()
    {
        speedAirUI.SetActive(false);
        speedEarthUI.SetActive(false);
        speedWaterUI.SetActive(false);
        speedFireUI.SetActive(false);
        speedNormalUI.SetActive(false);
        TheUI.Instance.AShopButton2.image.enabled = true;
         TheUI.Instance.AShop2.transform.GetChild(0).GetComponent<TMP_Text>().text="Fast Unit";
    }
    public void UnitArmoredElementSelect()
    {
         if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        armoredAirUI.SetActive(true);
        armoredEarthUI.SetActive(true);
        armoredWaterUI.SetActive(true);
        armoredFireUI.SetActive(true);
        armoredNormalUI.SetActive(true);
        UnitNormalDeElementSelect();
        UnitSpeedDeElementSelect();
        TheUI.Instance.AShopButton3.image.enabled = false;
              TheUI.Instance.AShop3.transform.GetChild(0).GetComponent<TMP_Text>().text="";
    }
    public void UnitArmoredDeElementSelect()
    {
        armoredAirUI.SetActive(false);
        armoredEarthUI.SetActive(false);
        armoredWaterUI.SetActive(false);
        armoredFireUI.SetActive(false);
        armoredNormalUI.SetActive(false);
        TheUI.Instance.AShopButton3.image.enabled = true;
        TheUI.Instance.AShop3.transform.GetChild(0).GetComponent<TMP_Text>().text="Armored Unit";

    }
    public void AllUnitDeSelect()
    {
        UnitNormalDeElementSelect();
        UnitSpeedDeElementSelect();
        UnitArmoredDeElementSelect();
    }
    public void TakeUnit(Unit unit) {
        if (GameManager.Instance.Gold < unit.cost) 
        {

            Debugger.Instance.Debuger(unit.unitName + "for need Gold:" + (unit.cost-GameManager.Instance.Gold));
        return;

        }
     
      if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
      
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
    else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.None)
    {
        if (unit == normalUnit)
            BattleManager.Instance.AddUnit(normalUnit);
        else if (unit == normalSpeedUnit)
            BattleManager.Instance.AddUnit(normalSpeedUnit);
        else if (unit == normalArmoredUnit)
            BattleManager.Instance.AddUnit(normalArmoredUnit);
    }

        RefreshMyUnitCount(unit);


 }
public void LevelUpTower () {   
    if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

       if(GameManager.Instance.Gold>= BuildManager.Instance.currentUpgradementTower.currentUpgradeCost){
        
    GameManager.Instance.Gold-=BuildManager.Instance.currentUpgradementTower.currentUpgradeCost;
            BuildManager.Instance.currentUpgradementTower.LevelUp();
            BuildManager.Instance.currentUpgradementTower.currentUpgradeCost= BuildManager.Instance.currentUpgradementTower.upgradeCostforNextLevel;
            InitShopHud();
        }
}
public void ElementTabOpen () {
     if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
    
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
     if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        elementTabOpen=false;
        elementUI.SetActive(false);
}
public void SetTowerElement (int elementIndex) {
    if(BuildManager.Instance.currentUpgradementTower.element_Type==Element_Type.None&&GameManager.Instance.Gold>BuildManager.Instance.currentUpgradementTower.elementChanceCost){
       if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
      
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
        Debugger.Instance.Debuger("Already has Elment");
    }
   
}

public void OpenInfoUI () {
     if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
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
     if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
         infoTabOpen=false;
        infoUI.SetActive(false);
}
}
