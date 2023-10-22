using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class BattleManager : MonoSingeleton<BattleManager>
{
  
   public List<Unit> unitList;
    public Transform attackTransform;
    public float spawnTime=2;
   [SerializeField]private int spawnIndex=0;
   public List<GameObject> hideUnitObject;
  // public PathCreator attackPathCreatorOtherSceene;
    public PathNode attackUnitNode;
    public bool isAttackedThisTurn = false;
    private int _killedPlayerUnitCount;

    public int KilledPlayerUnitCount
    {
        get
        {
           return _killedPlayerUnitCount;
        } 
        set
        {
            _killedPlayerUnitCount = value;
            if(KilledPlayerUnitCount>=unitList.Count &&  unitList.Count>0){
                // atak fail olmustur savas turunu bitir sayacı baslat
                KilledPlayerUnitCount=0;
                EndAttack();
            }
        } 
    }


 
   public void StartMyBattle () {
     StartCoroutine(EnterFight());
   }
   IEnumerator EnterFight(){
    
    while (true)
    {
        yield return  new WaitForSeconds(spawnTime);
        
        if(spawnIndex>=unitList.Count)
            break;
        Unit _unit=unitList[spawnIndex];   
        GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
        hideUnitObject.Add(unit);
            // unit.GetComponent<Movement>().pathCreator=GameManager.Instance.attackPathCreator;
            unit.transform.position = GameManager.Instance.myCastle.transform.position;
            unit.GetComponent<Unit>().isBackPath = true;
            unit.GetComponent<Unit>().nextPathNode = GameManager.Instance.endUnitNode;
       // karakterimizin başlanılç noktası son nodumuz ve geridoğru hareket etmesini istiyoruz

        spawnIndex++;
    }
   }
public IEnumerator Fight(){
    yield return  new WaitForSeconds(spawnTime);
    if(spawnIndex<unitList.Count){   
     Unit _unit=unitList[spawnIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     hideUnitObject.Add(unit);
            //unit.GetComponent<Movement>().pathCreator=attackPathCreatorOtherSceene;
            unit.transform.position = attackTransform.position;
            unit.GetComponent<Unit>().nextPathNode = attackUnitNode; // attak yolunu takip etmesini istiyoruz
     spawnIndex++;
     StartCoroutine(Fight());

    }
    
   }

   //rakip sahaya geçince once bunu cağır 
    public void PassOtherScene () {
  
      
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
        WaveManager.Instance.SetCamerVision();
        WaveManager.Instance.remainingTime= WaveManager.Instance.waveWaitTime;
        unitList.RemoveRange(0,unitList.Count);
        hideUnitObject.RemoveRange(0,hideUnitObject.Count);
      StartCoroutine(WaveManager.Instance.WaitWave());
        // buraya bu tur saldırıldı mı onu ölçen bişi lazım
        if (isAttackedThisTurn)
        {
            WaveManager.Instance.attackButton.enabled = false;
        }
       

        GameManager.Instance.playerIsAttack=false;
      for(int i = 0; i <HUD.Instance.myUnitCounts.Length; i++) {
         HUD.Instance.myUnitCounts[i]=0;
         HUD.Instance.AllMyUnitCountTexts[i].SetActive(false);
      }
     
     }
   
}
