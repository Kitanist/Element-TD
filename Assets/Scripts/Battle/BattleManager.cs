using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoSingeleton<BattleManager>
{
   public List<Unit> unitList;
   public float spawnTime=2;
   private int spawnIndex=0;
   private List<GameObject> hideUnitObject;

   public void StartMyBattle () {
     StartCoroutine(EnterFight());
   }
   IEnumerator EnterFight(){
    yield return  new WaitForSeconds(spawnTime);
    if(spawnIndex<unitList.Count){
     Debug.Log("hi");
     Unit _unit=unitList[spawnIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     hideUnitObject.Add(unit);
     unit.GetComponent<Movement>().pathCreator=GameManager.Instance.attackPathCreator;
     spawnIndex++;
     StartCoroutine(EnterFight());
    }
    
   }
    public void PassOtherScene () {
        StopCoroutine(EnterFight());
        spawnIndex=0;
        for(int i = 0; i < hideUnitObject.Count; i++) {
         hideUnitObject[i].SetActive(false);   
        }

    }
    public void AddUnit (Unit unit) {
        unitList.Add(unit);
     }
   
}
