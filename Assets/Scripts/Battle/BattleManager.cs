using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class BattleManager : MonoSingeleton<BattleManager>
{
   public List<Unit> unitList;
   public float spawnTime=2;
   [SerializeField]private int spawnIndex=0;
   private List<GameObject> hideUnitObject;
   public PathCreator attackPathCreatorOtherSceene;

    public int killedPlayerUnitCount=0;


private void Update() {
    if(killedPlayerUnitCount>=unitList.Count){
        // atak fail olmustur savas turunu bitir sayacı baslat
      killedPlayerUnitCount=0;
        EndAttack();
    }
}
   public void StartMyBattle () {
     StartCoroutine(EnterFight());
   }
   IEnumerator EnterFight(){
    yield return  new WaitForSeconds(spawnTime);
    if(spawnIndex<unitList.Count){
     
     Unit _unit=unitList[spawnIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     hideUnitObject.Add(unit);
     unit.GetComponent<Movement>().pathCreator=GameManager.Instance.attackPathCreator;
     spawnIndex++;
     StartCoroutine(EnterFight());
    }
   }
public IEnumerator Fight(){
    yield return  new WaitForSeconds(spawnTime);
    if(spawnIndex<unitList.Count){   
     Unit _unit=unitList[spawnIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     hideUnitObject.Add(unit);
     unit.GetComponent<Movement>().pathCreator=attackPathCreatorOtherSceene;
     spawnIndex++;
     StartCoroutine(Fight());
    }
    
   }

   //rakip sahaya geçince once bunu cağır sonra 
    public void PassOtherScene () {
        StopCoroutine(EnterFight());
        spawnIndex=0;
        for(int i = 0; i < hideUnitObject.Count; i++) {
         hideUnitObject[i].SetActive(false);   
        }
          StartCoroutine(Fight());

    }
    public void AddUnit (Unit unit) {
        unitList.Add(unit);
     }
     public void EndAttack () {
        
        WaveManager.Instance.remainingTime= WaveManager.Instance.waveWaitTime;
      StartCoroutine(WaveManager.Instance.WaitWave());
     }
   
}
