using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Element_Type element_Type;
    public float damage=10;
   private  void OnCollisionEnter(Collision other) {
    if(other.transform.CompareTag("Enemy")){
        other.transform.GetComponent<HealthComponent>().GetDamage(damage,element_Type);
    }
    this.gameObject.SetActive(false);
   }
}
