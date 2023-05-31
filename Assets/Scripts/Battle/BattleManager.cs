using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class BattleManager : MonoSingeleton<BattleManager>
{
   public List<Unit> unitList;
   public float spawnTime=2;
   [SerializeField]private int spawnIndex=0;
   public List<GameObject> hideUnitObject;
   public PathCreator attackPathCreatorOtherSceene;
  
    public int killedPlayerUnitCount=0;


private void Update() {
    if(killedPlayerUnitCount>=unitList.Count &&  unitList.Count>0){
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

   //rakip sahaya geçince once bunu cağır 
    public void PassOtherScene () {
      //HUD.Instance.setVisionOrAttackHUD.enabled=false;
      
         WaveManager.Instance.attackButton.enabled=false;
        spawnIndex=0;
        for(int i = 0; i < hideUnitObject.Count; i++) {
         hideUnitObject[i].SetActive(false);   
        }
          StopAllCoroutines();
          StartCoroutine(Fight());
           

    }
    public void AddUnit (Unit unit) {
        unitList.Add(unit);
     }
     public void EndAttack () {
        //HUD.Instance.setVisionOrAttackHUD.enabled=true;
        spawnIndex=0;
        WaveManager.Instance.MotherlandCam.enabled = true;
        WaveManager.Instance.EnemySideCam.enabled = false;
        WaveManager.Instance.remainingTime= WaveManager.Instance.waveWaitTime;
        unitList.RemoveRange(0,unitList.Count);
        hideUnitObject.RemoveRange(0,hideUnitObject.Count);
      StartCoroutine(WaveManager.Instance.WaitWave());
        WaveManager.Instance.attackButton.enabled=true;
        GameManager.Instance.playerIsAttack=false;
      for(int i = 0; i <HUD.Instance.myUnitCounts.Length; i++) {
         HUD.Instance.myUnitCounts[i]=0;
         HUD.Instance.AllMyUnitCountTexts[i].SetActive(false);
      }
     
     }
   
}
