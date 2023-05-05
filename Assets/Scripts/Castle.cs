using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(HealthComponent))]

[RequireComponent (typeof(BoxCollider))]
public class Castle : MonoBehaviour
{

private void OnTriggerEnter(Collider other) {
      Debug.Log("hiiii");
    Debug.Log("other layer: "+ other.gameObject.layer +"    "+ " sorulan layer: "+LayerMask.NameToLayer("Enemy"));
    if(other.gameObject.layer==LayerMask.NameToLayer("Enemy")){
        GetComponent<HealthComponent>().GetDamage(other.transform.GetComponent<Unit>().unitDamage);
        other.gameObject.SetActive(false);
    }
}
private void OnCollisionEnter(Collision other) {
    Debug.Log("hiiii");
     Debug.Log("other layer: "+ other.gameObject.layer +"    "+ " sorulan layer: "+LayerMask.NameToLayer("Enemy"));
}


}
