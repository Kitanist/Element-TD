using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : MonoBehaviour
{
    public float radius=5;
     public Element_Type element_Type;
    public float damage=10;
    public LayerMask mask;
    private void OnCollisionEnter(Collision other) {
        Collider [] objects =Physics.OverlapSphere(transform.position,radius,mask);
        foreach(var obj in objects) {
            obj.GetComponent<HealthComponent>().GetDamage(damage,element_Type,Color.cyan);
        }
        
      this.gameObject.SetActive(false);
    }

private void OnDrawGizmos() {
    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position,radius);
}
}
