using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static LTGUI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

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
    public SkinnedMeshRenderer mesh;
    public Material damageMatarial;
    Material firstMatarial;
    public AudioClip hitSound;


    public bool isIlkDarbe;
    public bool isIlkDarbeUse;

    public bool isImBurning;
    public bool isImBurningII;
    public bool don;
    public bool coss;
    public bool isBass;
    public GameObject fireParticle;
    public GameObject waterParticle;
    public GameObject earthParticle;
    public GameObject airParticle;
    public Transform EffectTransform;
    private void Start() {
        if (isUnit)
        {
            mesh = transform.GetChild(1).GetChild(1).GetComponent<SkinnedMeshRenderer>(); // hasar yerken slime fpx e ulaşıp mataryeli değiştiriyor
            firstMatarial = mesh.material;
        }
   
}
    public void GetFloatingText (string damage) {
         text=ObjectPool.Instance.GetPooledObject(26);
        text.transform.SetParent(this.transform);
        text.transform.position=transform.position;
        if (text.GetComponent<TextMesh>())
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
        if (this.gameObject.activeInHierarchy)
            mesh.material=firstMatarial;
    }
   public void GetDamage (float damage,Element_Type damagerType,Color col) {
    
    float _damage=SetElementDamage(damage,damagerType);
    if(isUnit && myElement!=Element_Type.None)
    CreateParticleHit(damagerType); 
        if (!isIlkDarbeUse && isIlkDarbe)
        {
            isIlkDarbeUse = true;
            _damage += _damage;
               
        }
       if (isImBurning)
        {
            GetComponent<Unit>().speed += 2 ;
            _damage += _damage + _damage +_damage;
            StartCoroutine(ReturnNormalSpeed(3));
        }

       if (isImBurningII)
        {
            GetComponent<Unit>().speed += 1;
            _damage += 3;
            StartCoroutine(ReturnNormalSpeed(.5f));
        }
        if (don)
        {
            GetComponent<Unit>().speed =0;
            StartCoroutine(ReturnNormalSpeed(.4f));
        }
        if (coss &&myElement==Element_Type.Fire)
        {
            Health = 0;
            HealtBar.DOValue(0, .5f, false);
            Die();
        }
        if (isBass)
        {
            GetComponent<Unit>().speed = -GetComponent<Unit>().maxSpeed;
            StartCoroutine(ReturnNormalSpeed(.3f));
        }
        if(damage>0)
        GetFloatingText("-"+_damage.ToString());
        else
        GetFloatingText("+" + _damage.ToString());
        text.GetComponent<TextMesh>().color=col;
    GameManager.Instance.asource.PlayOneShot(hitSound);
    if(Health<=_damage){
        Health=0;      
        HealtBar.DOValue(0,.5f,false);

        Die();
    }
    else if (Health > maxHealth)
        {
            Health = maxHealth;
            HealtBar.DOValue(1, .5f, false);
        }
    else{
        if(isUnit && gameObject.activeInHierarchy){
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
            if(this.gameObject.activeInHierarchy)
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

            StopAllCoroutines();
      
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
        SceneManager.LoadScene(0);
    }
    else{
         Debug.Log("kazandiniz");
          SceneManager.LoadScene(0);
       }
    
    }
   
   }
   public void CreateParticleHit(Element_Type element_Type)
   {
       switch (element_Type)
       {
           case Element_Type.None:
               break;
           case Element_Type.Fire:
               GameObject obj1=Instantiate(fireParticle,EffectTransform.position, Quaternion.identity);
               Destroy(obj1.gameObject,1);
            
               break;
           case Element_Type.Watter:
               GameObject obj2=Instantiate(waterParticle,  EffectTransform.position, Quaternion.identity);
               
               Destroy(obj2.gameObject,1);
            
               break;
           case Element_Type.Dirt:
               GameObject obj3= Instantiate(earthParticle, EffectTransform.position, Quaternion.identity);
               
               Destroy(obj3.gameObject,1);
            
               break;
           case Element_Type.Air:
               GameObject obj4=  Instantiate(airParticle, EffectTransform.position, Quaternion.identity);
               
               Destroy(obj4.gameObject,1);
              
               break;
           default:
            
               break;
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
         
            Health -= _damage;
            HealtBar.DOValue(Health / maxHealth, .5f, false);

            yield return new WaitForSeconds(1);

        }
    }
    public IEnumerator ReturnNormalSpeed(float timer)
    {
        yield return new WaitForSeconds(timer);
        isImBurning = false;
        don = false;
        isImBurningII = false;
        GetComponent<Unit>().speed = GetComponent<Unit>().maxSpeed;
    }
}
