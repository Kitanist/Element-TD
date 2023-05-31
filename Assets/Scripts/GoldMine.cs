using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : Tower
{
    public float speed=5;
    public float collectRate=20;
    public float collectAmount=1;
    
    private void Start() {
        GetGold();
    }
   public void  GetGold () {
     StartCoroutine(ColletGold());
   }
   IEnumerator ColletGold(){
    fireRate=collectRate/speed;
    yield return new WaitForSeconds(fireRate);
    GameManager.Instance.Gold+=collectAmount;
    StartCoroutine(ColletGold());
   }
   public override void LevelUp () {
   
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
            Debug.Log("GOLD MİNE YIKILIR");
            //partickle effect girer
        }

    }
  }

   private void OnMouseDown() {
         TheUI.Instance.ShopUIClose();      
        Invoke("OpenUIUpgrade",.6f);
        BuildManager.Instance.currentUpgradementTower=this;
         HUD.Instance.InitShopHud();
    }
}
