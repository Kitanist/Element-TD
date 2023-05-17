using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Element_Type element_Type;
    public float damage=10;
    private Transform target;
    public float speed=70;
  
   public void Seek ( Transform _target) {
    target=_target;
   }
   private void Update() {
    if(!target){
        gameObject.SetActive(false);
        return;
    }
    Vector3 dir= transform.position-target.position;
    float distanceFrame=speed*Time.deltaTime;
    if(dir.magnitude<=distanceFrame){
        target.GetComponent<HealthComponent>().GetDamage(damage,element_Type);
        gameObject.SetActive(false);
        Debug.Log("Hit");
    }
    transform.Translate(-dir.normalized*distanceFrame,Space.World);
   }
}
