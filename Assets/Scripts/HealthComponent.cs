using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthComponent : MonoBehaviour
{
    public Slider HealtBar;
    public Element_Type myElement;
   public float Health=100;
   public float maxHealth=100;

   public float critiDamageMultipler=1.2f;
    public float lessDamageMultipler=.8f;
   public bool isUnit=true;
   public bool isPlayerBase=false;

   public void GetDamage (float damage,Element_Type damagerType) {
    float _damage=SetElementDamage(damage,damagerType);
  
    if(Health<=_damage){
        Health=0;      
        HealtBar.DOValue(0,.5f,false);

        Die();
    }
    else{
        Health-=_damage;
        HealtBar.DOValue(Health/maxHealth,.5f,false);
        
    }


   }

    public float SetElementDamage (float damage,Element_Type damagerType) {
        if(damagerType==Element_Type.Fire){
            if(myElement==Element_Type.Watter){
                damage=damage*lessDamageMultipler;
                return damage;
            }
            else if(myElement==Element_Type.Air){
                 damage=damage*critiDamageMultipler;
                return damage;
            }
            else{
                return damage;
            }
        }
        else if(damagerType==Element_Type.Watter){
            if(myElement==Element_Type.Fire){
                damage=damage*critiDamageMultipler;
                return damage;
            }
            else if(myElement==Element_Type.Dirt){
                 damage=damage*lessDamageMultipler;
                return damage;
            }
            else{
                return damage;
            }
        }
           else if(damagerType==Element_Type.Dirt){
            if(myElement==Element_Type.Watter){
                damage=damage*critiDamageMultipler;
                return damage;
            }
            else if(myElement==Element_Type.Air){
                 damage=damage*lessDamageMultipler;
                return damage;
            }
            else{
                return damage;
            }
        }
         else if(damagerType==Element_Type.Air){
            if(myElement==Element_Type.Dirt){
                damage=damage*critiDamageMultipler;
                return damage;
            }
            else if(myElement==Element_Type.Fire){
                 damage=damage*lessDamageMultipler;
                return damage;
            }
            else{
                return damage;
            }
        }

        
        return damage;
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
