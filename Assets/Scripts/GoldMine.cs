using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public float speed=5;
    public float collectRate=20;
    public float collectAmount=1;
     public int level=1;
    public int maxLevel=3;
    public GameObject[] openWithLevel;
    private void Start() {
        GetGold();
    }
   public void  GetGold () {
     StartCoroutine(ColletGold());
   }
   IEnumerator ColletGold(){
    yield return new WaitForSeconds(collectRate/speed);
    GameManager.Instance.Gold+=collectAmount;
    StartCoroutine(ColletGold());
   }
   public void LevelUp () {
   
      if(level<maxLevel){
            int openLevelIndex=level-1;
            level++;
            collectAmount+=2;
            for(int i = 0; i < openLevelIndex; i++) {
                openWithLevel[i].SetActive(true);
                
            }
        }
   }
  private void OnTriggerEnter(Collider other) {
    if(other.GetComponent<Unit>()){
        if(other.gameObject.layer==LayerMask.NameToLayer("Enemy")){
            Destroy(gameObject);
            //partickle effect girer
        }

    }
  }
}
