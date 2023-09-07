using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(HealthComponent))]

[RequireComponent (typeof(BoxCollider))]
public class Castle : MonoBehaviour
{
    public bool isSoytariActive=false;
    /*
public void  OpenUnitPanelButton () {
   // TheUI.Instance.isButton=true;
  //  TheUI.Instance.ShopUIClose();
    Invoke("OpenUIUnit",.6f);
    if(Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
}
    
public void OpenUIUnit () {
    //TheUI.Instance.isTurret = false;
    //TheUI.Instance.isUpgrade = false;
    //TheUI.Instance.isArmy = true;
   // TheUI.Instance.ShopUIOpen();
}*/
private void OnTriggerEnter(Collider other) {
 
  if(GetComponent<HealthComponent>().isPlayerBase){
        Debug.Log("other layer: "+ other.gameObject.layer +"    "+ " sorulan layer: "+LayerMask.NameToLayer("Enemy"));
         if(other.gameObject.layer==LayerMask.NameToLayer("Enemy")){
        GetComponent<HealthComponent>().GetDamage(other.transform.GetComponent<Unit>().unitDamage,other.GetComponent<HealthComponent>().myElement);
        other.GetComponent<HealthComponent>().GetDamage(other.GetComponent<HealthComponent>().maxHealth,Element_Type.None);// kendisi de hasar yiyerek ölsün

            }
     if(!isSoytariActive){
        isSoytariActive=true;
        GameManager.Instance.mySoytari.SetActive(true);
        Debug.Log("nedeeeeene tanrım nedennn");
    }
     }
     else{
        if(other.gameObject.layer==LayerMask.NameToLayer("Ally")){
        GetComponent<HealthComponent>().GetDamage(other.transform.GetComponent<Unit>().unitDamage,other.GetComponent<HealthComponent>().myElement);
        other.GetComponent<HealthComponent>().GetDamage(other.GetComponent<HealthComponent>().maxHealth,Element_Type.None);// kendisi de hasar yiyerek ölsün

            }

   
     }
    
      
}



}
