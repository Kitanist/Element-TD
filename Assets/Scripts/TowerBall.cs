using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TowerBall : Tower
{
   

    public GameObject rotatObject;
   void Update()
    {
        
        
       UpdateTarget();
        if(reset && target){
        reset=false;
        Fire();
        StartCoroutine(ResetTower());
       }
    }

     IEnumerator ResetTower(){
      
        yield return new WaitForSeconds(fireRate);
        
        reset=true;
    }
    public override void LevelUp()
    {
        base.LevelUp();
    }
    public override void UpdateTarget()
    {
        base.UpdateTarget();
    }
    public override void Fire()
    {
      GameObject bullet=ObjectPool.Instance.GetPooledObject(poolIndex);
      bullet.GetComponent<BallBullet>().element_Type=element_Type;
      bullet.GetComponent<BallBullet>().damage=damage;//merminin elementini kulenin elementi yapıyoruz
      bullet.transform.position=firePos.position;  
 
      bullet.transform.DOJump(target.position,JumpForce,0,(fireRate/bulletSpeed),false).SetEase(easeType);
    }
     private void OnDrawGizmos() {
        Gizmos.color=Color.cyan;
        Gizmos.DrawWireSphere(transform.position,attackRadius);
    }
     private void FixedUpdate() {
          if(target){
        rotatObject.transform.LookAt(target,Vector3.up);
       }
    }
}
