using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoSingeleton<BattleManager>
{
   public List<Unit> unitList;
   public float spawnTime=2;
   private int spawnIndex=0;

   public void StartMyBattle () {
     StartCoroutine(EnterFight());
   }
   IEnumerator EnterFight(){
    yield return  new WaitForSeconds(spawnTime);
    if(spawnIndex<unitList.Count){
     Debug.Log("hi");
     Unit _unit=unitList[spawnIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     unit.GetComponent<Movement>().pathCreator=GameManager.Instance.attackPathCreator;
     spawnIndex++;
     StartCoroutine(EnterFight());
    }
    
   }
    public void AddUnit (Unit unit) {
        unitList.Add(unit);
     }
   
}
