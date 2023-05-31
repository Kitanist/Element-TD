using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
   
    private void Update() {
  
    if(reset){
        Fire();
       
        StartCoroutine(ResetTower());
    }
    }
    public override void Fire()
    {
        reset=false; //yarı eksen gerekiyormuş everlap box da dikkat edilmeli
        targets= Physics.OverlapBox(firePos.position,new Vector3(attackRadius/2,attackRadius/2,attackRadius/2),Quaternion.identity,EnemyMask);
        foreach(var obj in targets) {
            //hasar ver
            obj.GetComponent<HealthComponent>().GetDamage(damage,element_Type);        
        }
     
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.cyan;
        Gizmos.DrawWireCube(firePos.position,new Vector3(attackRadius,attackRadius,attackRadius));
    }

    public override void LevelUp()
    {
        base.LevelUp();
    } 
     private void OnMouseDown() {
         TheUI.Instance.ShopUIClose();      
        Invoke("OpenUIUpgrade",.6f);
        BuildManager.Instance.currentUpgradementTower=this;
         HUD.Instance.InitShopHud();
    }

     IEnumerator ResetTower(){
      
        yield return new WaitForSeconds(fireRate);
        
        reset=true;
    }
}
