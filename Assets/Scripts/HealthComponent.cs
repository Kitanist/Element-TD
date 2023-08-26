using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static LTGUI;
using static UnityEngine.GraphicsBuffer;

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
    GameObject text;
    public MeshRenderer mesh;
    public Material damageMatarial;
    Material firstMatarial;
    public AudioClip hitSound;
private void Start() {
    mesh=GetComponent<MeshRenderer>();
    firstMatarial=mesh.material;
}
    public void GetFloatingText (string damage) {
         text=ObjectPool.Instance.GetPooledObject(26);
        text.transform.SetParent(this.transform);
        text.transform.position=transform.position;
        text.GetComponent<TextMesh>().text=damage;
    
    }
     public void GetFloatingText2 (string gold) {
         text=ObjectPool.Instance.GetPooledObject(26);        
        text.transform.position=transform.position;
         text.transform.position+=new Vector3(0,2,0);
         text.transform.localScale=new Vector3(1.5f,1.5f,1.5f);
         //text.transform.LeanScale(new Vector3(1,1,1),text.GetComponent<FloatingText>().speed);
        text.GetComponent<TextMesh>().text=gold;
    
    }

    IEnumerator fixMatarial(){
        yield return new WaitForSeconds(.1f);
        mesh.material=firstMatarial;
    }
   public void GetDamage (float damage,Element_Type damagerType) {
    float _damage=SetElementDamage(damage,damagerType);
    GetFloatingText("-"+_damage.ToString());
    text.GetComponent<TextMesh>().color=Color.cyan;
    GameManager.Instance.asource.PlayOneShot(hitSound);
    if(Health<=_damage){
        Health=0;      
        HealtBar.DOValue(0,.5f,false);

        Die();
    }
    else{
        if(isUnit){
            mesh.material=damageMatarial;
            StartCoroutine(fixMatarial());
        }
        
        Health-=_damage;
        HealtBar.DOValue(Health/maxHealth,.5f,false);
        
    }


   }
    public void GetBurnedDamage(float damage, Element_Type damagerType)
    {
        float _damage = SetElementDamage(damage, damagerType);
      
        
        if (Health <= _damage)
        {
            Health = 0;
            HealtBar.DOValue(0, .5f, false);

            Die();
        }
        else
        {
        
            StartCoroutine(BurnedDamage(0,_damage/3));

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

        
      
        if(gameObject.layer==LayerMask.NameToLayer("Enemy")){
            WaveManager.Instance.destroyedUnitCount++;
            GameManager.Instance.Gold+=gameObject.GetComponent<Unit>().price;
            GetFloatingText2("+"+gameObject.GetComponent<Unit>().price.ToString());
            text.GetComponent<TextMesh>().color=Color.yellow;
             
        }
        else if(gameObject.layer==LayerMask.NameToLayer("Ally")){
           BattleManager.Instance.KilledPlayerUnitCount++;
        }

        gameObject.SetActive(false);
        Health=maxHealth;
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
    public IEnumerator BurnedDamage(int cnt,float _damage)
    {


        while (cnt!=3)
        {
            cnt++;
            if (isUnit)
            {
                mesh.material = damageMatarial;
                StartCoroutine(fixMatarial());
            }
            if (Health <= _damage)
            {
                Health = 0;
                HealtBar.DOValue(0, .5f, false);

                Die();
            }
            GetFloatingText("-" + ((int)_damage).ToString());
            text.GetComponent<TextMesh>().color = Color.cyan;
            Debug.Log("Yandim Anam");
            Health -= _damage;
            HealtBar.DOValue(Health / maxHealth, .5f, false);

            yield return new WaitForSeconds(1);

        }
    }
}
