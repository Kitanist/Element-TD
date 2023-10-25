using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class SaveSystem : MonoSingeleton<SaveSystem>
{
    public SaveData data;

    private void Start()
    {

    
    }
   
   

    public void JsonSave()
    {
        data.isBomberPointOpen = GameManager.Instance.isBomberPointOpen;
        data.isHealerPointOpen = GameManager.Instance.isHealerPointOpen;
        data.isMinePointOpen = GameManager.Instance.isMinePointOpen;
        data.isTrapPointOpen = GameManager.Instance.isTrapPointOpen;
        data.aqumentRollCount = GameManager.Instance.aqumentRollCount;
        data.aqumentCount = GameManager.Instance.aqumentCount;
        data.skillPoint = GameManager.Instance.skillPoint;
        data.isAqumentCount1Open = GameManager.Instance.isAqumentCount1Open;
        data.isAqumentCount2Open = GameManager.Instance.isAqumentCount2Open;
        string Str = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/Saves/SaveStat.json", Str);

    }


    public void JsonLoad()
    {
        string path = Application.dataPath + "/Saves/SaveStat.json";
        if (File.Exists(path))
        {
            string Str = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(Str);
           GameManager.Instance.isBomberPointOpen=data.isBomberPointOpen;
            GameManager.Instance.isHealerPointOpen=data.isHealerPointOpen;
           GameManager.Instance.isMinePointOpen=data.isMinePointOpen;
            GameManager.Instance.isTrapPointOpen = data.isTrapPointOpen;
            GameManager.Instance.aqumentRollCount = data.aqumentRollCount ;
             GameManager.Instance.aqumentCount=data.aqumentCount;
         GameManager.Instance.skillPoint=data.skillPoint;
            GameManager.Instance.isAqumentCount1Open = data.isAqumentCount1Open;
            GameManager.Instance.isAqumentCount2Open = data.isAqumentCount2Open;
        }
        else
        {
            Debug.Log("Dosya Bulunamadi");
        }
    }

}
