using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage=10;
   private void OnCollisionEnter(Collision other) {
    if(other.transform.CompareTag("Enemy")){
        other.transform.GetComponent<HealthComponent>().GetDamage(damage);
    }
    this.gameObject.SetActive(false);
   }
}
