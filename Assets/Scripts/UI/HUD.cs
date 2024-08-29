using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUD : MonoSingeleton<HUD>
{
    
    public Button setVisionOrAttackHUD;


    [Header("UNİT")]
    [Space(5)]
    public Unit normalFireUnit, normalWatterUnit, normalAirUnit, normalDirtUnit;
    public Unit normalUnit, normalSpeedUnit, normalArmoredUnit;
    public Unit speederFireUnit, speederWatterUnit, speederAirUnit, speederDirtUnit;
    public Unit armoredFireUnit, armoredWatterUnit, armoredAirUnit, armoredDirtUnit;

    [Header("UNİT TEXT")]
    [Space(5)]
    public TMP_Text normalUnitText;

    public TMP_Text speederUnitText;

    public TMP_Text armoredUnitText;

 

    [Header("INFO")]
    [Space(5)]

   

    [Header("UNİT COUNT")]
    [Space(5)]
    public GameObject[] AllUnitCountTexts;
    public GameObject[] AllMyUnitCountTexts;
    public int[] myUnitCounts;
    public Sprite fn_s, fa_s, fs_s, wn_s, wa_s, ws_s, an_s, aa_s, as_s, dn_s, da_s, ds_s;



    public void RefreshUnitCount()
    {
        if (WaveManager.Instance.currentWaveCount < WaveManager.Instance.waves.Length)
        {
            for (int i = 0; i < AllUnitCountTexts.Length; i++)
            {

                if (WaveManager.Instance.waves[WaveManager.Instance.currentWaveCount].diffrentUnitCounts[i] > 0)
                {
                    AllUnitCountTexts[i].SetActive(true);
                    AllUnitCountTexts[i].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + WaveManager.Instance.waves[WaveManager.Instance.currentWaveCount].diffrentUnitCounts[i].ToString();
                }
                else
                {
                    AllUnitCountTexts[i].SetActive(false);
                }

            }
        }

    }
    public void RefreshMyUnitCount(Unit unit)
    {
        if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Fire)
        {
            if (unit.unitType == UnitType.Normal)
            {
                AllMyUnitCountTexts[0].SetActive(true);
                myUnitCounts[0]++;
                AllMyUnitCountTexts[0].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[0].ToString();

                AllMyUnitCountTexts[0].GetComponent<Image>().sprite = fn_s;
            }
            else if (unit.unitType == UnitType.Speeder)
            {
                AllMyUnitCountTexts[1].SetActive(true);
                myUnitCounts[1]++;
                AllMyUnitCountTexts[1].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[1].ToString();
                AllMyUnitCountTexts[1].GetComponent<Image>().sprite = fs_s;
            }
            else if (unit.unitType == UnitType.Armored)
            {
                AllMyUnitCountTexts[2].SetActive(true);
                myUnitCounts[2]++;
                AllMyUnitCountTexts[2].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[2].ToString();
                AllMyUnitCountTexts[2].GetComponent<Image>().sprite = fa_s;
            }

        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Watter)
        {
            if (unit.unitType == UnitType.Normal)
            {
                AllMyUnitCountTexts[3].SetActive(true);
                myUnitCounts[3]++;
                AllMyUnitCountTexts[3].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[3].ToString();
                AllMyUnitCountTexts[3].GetComponent<Image>().sprite = wn_s;
            }
            else if (unit.unitType == UnitType.Speeder)
            {
                AllMyUnitCountTexts[4].SetActive(true);
                myUnitCounts[4]++;
                AllMyUnitCountTexts[4].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[4].ToString();
                AllMyUnitCountTexts[4].GetComponent<Image>().sprite = ws_s;
            }
            else if (unit.unitType == UnitType.Armored)
            {
                AllMyUnitCountTexts[5].SetActive(true);
                myUnitCounts[5]++;
                AllMyUnitCountTexts[5].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[5].ToString();
                AllMyUnitCountTexts[5].GetComponent<Image>().sprite = wa_s;
            }
        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Air)
        {
            if (unit.unitType == UnitType.Normal)
            {
                AllMyUnitCountTexts[6].SetActive(true);
                myUnitCounts[6]++;
                AllMyUnitCountTexts[6].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[6].ToString();
                AllMyUnitCountTexts[6].GetComponent<Image>().sprite = an_s;
            }
            else if (unit.unitType == UnitType.Speeder)
            {
                AllMyUnitCountTexts[7].SetActive(true);
                myUnitCounts[7]++;
                AllMyUnitCountTexts[7].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[7].ToString();
                AllMyUnitCountTexts[7].GetComponent<Image>().sprite = as_s;
            }
            else if (unit.unitType == UnitType.Armored)
            {
                AllMyUnitCountTexts[8].SetActive(true);
                myUnitCounts[8]++;
                AllMyUnitCountTexts[8].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[8].ToString();
                AllMyUnitCountTexts[8].GetComponent<Image>().sprite = aa_s;
            }

        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Dirt)
        {
            if (unit.unitType == UnitType.Normal)
            {
                AllMyUnitCountTexts[9].SetActive(true);
                myUnitCounts[9]++;
                AllMyUnitCountTexts[9].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[9].ToString();
                AllMyUnitCountTexts[9].GetComponent<Image>().sprite = dn_s;
            }
            else if (unit.unitType == UnitType.Speeder)
            {
                AllMyUnitCountTexts[10].SetActive(true);
                myUnitCounts[10]++;
                AllMyUnitCountTexts[10].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[10].ToString();
                AllMyUnitCountTexts[10].GetComponent<Image>().sprite = ds_s;
            }
            else if (unit.unitType == UnitType.Armored)
            {
                AllMyUnitCountTexts[11].SetActive(true);
                myUnitCounts[11]++;
                AllMyUnitCountTexts[11].transform.GetChild(0).GetComponent<TMP_Text>().text = " x" + myUnitCounts[11].ToString();
                AllMyUnitCountTexts[11].GetComponent<Image>().sprite = da_s;
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

    public void Start()
    {
        RefreshUnitCount();
       
    }
  
   
    public void TakeUnit(Unit unit)
    {

        if (UnityEngine.Random.Range(0, 2) == 1)
            GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
        else
            GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);


        if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Fire)
        {
            if (unit == normalFireUnit)
                BattleManager.Instance.AddUnit(normalFireUnit);
            else if (unit == speederFireUnit)
                BattleManager.Instance.AddUnit(speederFireUnit);
            else if (unit == armoredFireUnit)
                BattleManager.Instance.AddUnit(armoredFireUnit);
        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Watter)
        {
            if (unit == normalWatterUnit)
                BattleManager.Instance.AddUnit(normalWatterUnit);
            else if (unit == speederWatterUnit)
                BattleManager.Instance.AddUnit(speederWatterUnit);
            else if (unit == armoredWatterUnit)
                BattleManager.Instance.AddUnit(armoredWatterUnit);
        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Air)
        {
            if (unit == normalAirUnit)
                BattleManager.Instance.AddUnit(normalAirUnit);
            else if (unit == speederAirUnit)
                BattleManager.Instance.AddUnit(speederAirUnit);
            else if (unit == armoredAirUnit)
                BattleManager.Instance.AddUnit(armoredAirUnit);
        }
        else if (unit.GetComponent<HealthComponent>().myElement == Element_Type.Dirt)
        {
            if (unit == normalDirtUnit)
                BattleManager.Instance.AddUnit(normalDirtUnit);
            else if (unit == speederDirtUnit)
                BattleManager.Instance.AddUnit(speederDirtUnit);
            else if (unit == armoredDirtUnit)
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
    public void LevelUpTower()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
            GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
        else
            GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

        
    }
   


}
