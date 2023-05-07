using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : Bullet
{
    public float radius=5;
    public LayerMask mask;
    private void OnCollisionEnter(Collision other) {
        Collider [] objects =Physics.OverlapSphere(transform.position,radius,mask);
        foreach(var obj in objects) {
            obj.GetComponent<HealthComponent>().GetDamage(damage,element_Type);
        }
        
      this.gameObject.SetActive(false);
    }

private void OnDrawGizmos() {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position,radius);
}
}
