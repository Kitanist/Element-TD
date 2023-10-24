using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class OpenAbleBase : MonoBehaviour
{

    public GameObject UIPanel;
    public GameObject extraPanel;
    public GameObject LockPanel;
    public int Cost;
    public Sprite ImageSprite;
    public Image sprite;
    public TMP_Text costText;
    private bool isOpen=false;
    public GameObject OldMesh;
    public GameObject NewMesh;
    public OpenableType type;
    public float workTimeLimit=10;
    GameObject text;

    [Header("MINE")] //inspectorda eger mine degilse bu verilerin doldurulmasina gerek yok
    [Space(5)]

    public float speed = 5;
    public float collectRate = 20;
    public float collectAmount = 1;
    private float fireRate;
    [Header("TRAP")] //inspectorda eger mine degilse bu verilerin doldurulmasina gerek yok
    [Space(5)]
    public float damage = 10; //bomber için de gerekli
    public LayerMask targetMask; //heal için de gerekli
    public Element_Type Element;
    [Header("HEAL")] //inspectorda eger mine degilse bu verilerin doldurulmasina gerek yok
    [Space(5)]

    public float healAmount = 10;
    [Header("BOMBER")] //inspectorda eger mine degilse bu verilerin doldurulmasina gerek yok
    [Space(5)]
    public GameObject bombreadyParticle;
    private  void Start()
    {
        sprite.sprite= ImageSprite;
        costText.text = Cost.ToString();
    }
 
    private void OnMouseEnter()
    {

        if (type == OpenableType.Bomber)
        {
            if (!GameManager.Instance.isBomberPointOpen)
            {
                LockPanel.SetActive(true);
                return;
            }
              
        }
        if (type == OpenableType.Healer)
        {
            if (!GameManager.Instance.isHealerPointOpen)
            {
                LockPanel.SetActive(true);
                return;
            }
              
        }
        if (type == OpenableType.Mine)
        {
            if (!GameManager.Instance.isMinePointOpen)
            {
                LockPanel.SetActive(true);
                return;
            }
              
        }
        if (type == OpenableType.Trap)
        {
            if (!GameManager.Instance.isTrapPointOpen)
            {
                LockPanel.SetActive(true);
                return;
            }
            
        }
        if (!isOpen)
        UIPanel.SetActive(true);
        else
        {
            if(type == OpenableType.Bomber||type == OpenableType.Mine ||type==OpenableType.Healer)
            {
                extraPanel.SetActive(true);
            }
            
            
        }
    }
    private void OnMouseExit()
    {
        if (type == OpenableType.Bomber)
        {
            if (!GameManager.Instance.isBomberPointOpen)
            {
                LockPanel.SetActive(false);
                return;
            }
              
        }
        if (type == OpenableType.Healer)
        {
            if (!GameManager.Instance.isHealerPointOpen)
            {
                LockPanel.SetActive(false);
                return;
            }
        }
        if (type == OpenableType.Mine)
        {
            if (!GameManager.Instance.isMinePointOpen)
            {
                LockPanel.SetActive(false);
                return;
            }
                
        }
        if (type == OpenableType.Trap)
        {
            if (!GameManager.Instance.isTrapPointOpen)
            {
                LockPanel.SetActive(false);
                return;
            }
              
        }
        UIPanel.SetActive(false);
        extraPanel.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (type == OpenableType.Bomber)
        {
            if (!GameManager.Instance.isBomberPointOpen)
                return;
        }
        if (type == OpenableType.Healer)
        {
            if (!GameManager.Instance.isHealerPointOpen)
                return;
        }
        if (type == OpenableType.Mine)
        {
            if (!GameManager.Instance.isMinePointOpen)
                return;
        }
        if (type == OpenableType.Trap)
        {
            if (!GameManager.Instance.isTrapPointOpen)
                return;
        }
        if (isOpen && type == OpenableType.Bomber)
        {
            Collider[] Enemys = Physics.OverlapSphere(transform.position, 10,targetMask);
            foreach (var enemy in Enemys)
            {
                enemy.GetComponent<HealthComponent>().GetDamage(damage, Element, Color.cyan);
                Debug.Log("bomb");
            }
            OldMesh.SetActive(true);
            NewMesh.SetActive(false);
            UIPanel.SetActive(true);
            extraPanel.SetActive(false);
            isOpen = false;
            bombreadyParticle.SetActive(false);
        }
       else if (GameManager.Instance.Gold > Cost &&!isOpen)
        {

            GameManager.Instance.Gold -= Cost;
            OldMesh.SetActive(false);
            NewMesh.SetActive(true);
            UIPanel.SetActive(false);
            extraPanel.SetActive(false);
            ActiveBase();
            isOpen = true;
            if(type!=OpenableType.Bomber)
            StartCoroutine(StopBase());
        }
      
    }
    public virtual void ActiveBase()
    {
        
        switch (type)
        {
            case OpenableType.Mine:
                UIPanel.SetActive(false);
                extraPanel.SetActive(true);
                StartCoroutine(ColletGold()); // Suresi dolunca stop coroutine diyip altin eklenesini durdurcaz
         
                break;
            case OpenableType.Trap:
                StartCoroutine(Damager());
             break;
            case OpenableType.Healer:
                UIPanel.SetActive(false);
                extraPanel.SetActive(true);
                StartCoroutine(Healer());
                break;
            case OpenableType.Bomber:
                UIPanel.SetActive(false);
                extraPanel.SetActive(true);
                bombreadyParticle.SetActive(true);
                break;
        }
      
    }
    public void GetFloatingText(string str,Color clr)
    {
        text = ObjectPool.Instance.GetPooledObject(26);
        text.transform.SetParent(this.transform);
        text.transform.position = transform.position;
        text.transform.localScale = new Vector3(5, 5, 5);
       
        if (text.GetComponent<TextMesh>())
        {
            text.GetComponent<TextMesh>().text = str;
            text.GetComponent<TextMesh>().color = clr;
        }
           

    }
    IEnumerator StopBase()
    {
        yield return new WaitForSeconds(workTimeLimit);
        StopAllCoroutines();
        StopCoroutine(ColletGold());
        StopCoroutine(Damager());
        StopCoroutine(Healer());
        OldMesh.SetActive(true);
        NewMesh.SetActive(false);
        isOpen = false;
    }

    IEnumerator ColletGold()
    {
        fireRate = collectRate / speed;
        yield return new WaitForSeconds(fireRate);
        GameManager.Instance.Gold += collectAmount;
        GetFloatingText("+ "+collectAmount.ToString(),Color.yellow);
        StartCoroutine(ColletGold());
    }
    IEnumerator Damager()
    { 
        yield return new WaitForSeconds(1);
        Collider[]  Enemys = Physics.OverlapSphere(transform.position,7.5f,targetMask);
        foreach (var enemy in Enemys)
        {
            enemy.GetComponent<HealthComponent>().GetDamage(damage, Element, Color.cyan);
           
        }
        StartCoroutine(Damager());
    }

    IEnumerator Healer()
    {
        yield return new WaitForSeconds(1);
        Collider[] Ally = Physics.OverlapSphere(transform.position, 7.5f, targetMask);
        foreach (var ally in Ally)
        {
            ally.GetComponent<HealthComponent>().GetDamage(-healAmount, Element_Type.None, Color.green);
           
        }
        StartCoroutine(Healer());
    }

        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 7.5f);
    }
}
public enum OpenableType
{
   None,
   Trap,
   Mine,
   Healer,
   Bomber
}
