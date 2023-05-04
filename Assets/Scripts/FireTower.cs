using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{

    private void Update() {
     targets= Physics.OverlapBox(firePos.position,new Vector3(attackRadius,attackRadius,attackRadius),Quaternion.identity,EnemyMask);
    if(reset){
        Fire();
       
        StartCoroutine(ResetTower());
    }
    }
    public override void Fire()
    {
        reset=false;
        foreach(var obj in targets) {
            //hasar ver
            
        }
     
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.cyan;
        Gizmos.DrawWireCube(firePos.position,new Vector3(attackRadius,attackRadius,attackRadius));
    }

     IEnumerator ResetTower(){
      
        yield return new WaitForSeconds(fireRate);
        
        reset=true;
    }
}
