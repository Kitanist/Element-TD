using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
   

    public int skillPoint = 0;
    public int aqumentCount = 1;
    public int aqumentRollCount = 1; 
    public bool isBomberPointOpen = false;
    public bool isHealerPointOpen = false;
    public bool isMinePointOpen = false;
    public bool isTrapPointOpen = false;
    public SaveData( int sp,int ac,int arc, bool bomberPoint,bool healerPoint,bool minePoint,bool trapPoint)
    {
   
     skillPoint = sp;
    aqumentCount = ac;
    aqumentRollCount = arc;
    isBomberPointOpen = bomberPoint;
    isHealerPointOpen = healerPoint;
    isTrapPointOpen = trapPoint;
    isMinePointOpen = minePoint;

    }
    public SaveData()
    {

    }



}
