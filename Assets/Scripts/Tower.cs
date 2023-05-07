using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    public Transform firePos;
    public Element_Type element_Type;
    public float Cost=100;
    public float damage=10;
    public int poolIndex=0;
     public float JumpForce=5;

     public float attackRadius=5;
     
     public float bulletSpeed=3;
     public float fireRate=5;
     
     protected bool reset=true;
     public LayerMask EnemyMask;
     public Ease easeType;
     [SerializeField] protected Collider [] targets;
     [SerializeField] protected Transform target;

    void Update()
    {
       targets= Physics.OverlapSphere(this.transform.position,attackRadius,EnemyMask);
       if(targets.Length>0){
        target=targets[0].transform;
        if(reset){
        reset=false;
        Fire();
        StartCoroutine(ResetTower());

        }
       }else{
        target=null;
       }
    }

    private void OnDrawGizmos() {
        Gizmos.color=Color.cyan;
        Gizmos.DrawWireSphere(transform.position,attackRadius);
    }

      public virtual void Fire () {
      
      GameObject bullet=ObjectPool.Instance.GetPooledObject(poolIndex);
      bullet.GetComponent<Bullet>().element_Type=element_Type;
      bullet.GetComponent<Bullet>().damage=damage;//merminin elementini kulenin elementi yapıyoruz
      bullet.transform.position=firePos.position;
      bullet.transform.DOJump(target.position,JumpForce,0,(fireRate/bulletSpeed),false).SetEase(easeType);
    


      
    }
     IEnumerator ResetTower(){
      
        yield return new WaitForSeconds(fireRate);
        
        reset=true;
    }
}
