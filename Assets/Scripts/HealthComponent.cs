using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthComponent : MonoBehaviour
{
    public Slider HealtBar;
   public float Health=100;
   public float maxHealth=100;
   public bool isUnit=true;
   public bool isPlayerBase=false;

   public void GetDamage (float damage) {
    if(Health<=damage){
        Health=0;      
        HealtBar.DOValue(0,.5f,false);

        Die();
    }
    else{
        Health-=damage;
        HealtBar.DOValue(Health/maxHealth,.5f,false);
        
    }


   }

   public void Die () {
    if(isUnit){
        gameObject.SetActive(false);
      Debug.Log(LayerMask.NameToLayer("Enemy"))  ;
        if(gameObject.layer==LayerMask.NameToLayer("Enemy")){
            
            GameManager.Instance.Gold+=10;
        }
    }
    else{
         if(isPlayerBase){
        Debug.Log("kaybettiniz");
    }
    else{
         Debug.Log("kazandiniz");
    }
    
    }
   
   }
}
