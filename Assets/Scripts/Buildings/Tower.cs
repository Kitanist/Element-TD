using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Tower : AqumentBase
{
    public bool isAlevliOklarEnabled;

    public Transform firePos;
    public GameObject rangeObject;
    public Element_Type element_Type;

    public Node node;
    public string Name = "Tower";

    public float damage = 10;
    public int poolIndex = 0;
    public float JumpForce = 5;

    public float attackRadius = 5;

    public float bulletSpeed = 3;
    public float fireRate = 5;

    protected bool reset = true;
    public LayerMask EnemyMask;
    public Ease easeType;

    public float elementChanceCost = 50;
    public float currentUpgradeCost = 100;
    [SerializeField] protected Transform target;



    public AudioClip buildSoundClip;
    public AudioClip bulletSoundClip;
    [Header("LEVEL")]
    [Space(5)]
    public int level = 1;
    public int maxLevel = 3;
    public GameObject[] openWithLevel;
    public GameObject[] closeWithLevel;
    public int[] DamageCounts;
    public int[] AttackRadiusCounts;
    public int upgradeCostforNextLevel;
    private float shortDis;
    public Collider[] targets;

    public bool towerIsPlayer = true;

    void Update()
    {


        UpdateTarget();
        if (reset && target)
        {
            reset = false;
            Fire();
            StartCoroutine(ResetTower());
        }


    }
    private void Start()
    {
        //InvokeRepeating("UpdateTarget",0,.5f);

    }
    public virtual void UpdateTarget()
    {
        if (target)
        {
            float dis = Vector3.Distance(target.transform.position, transform.position);
            if (dis > attackRadius || !target.gameObject.activeInHierarchy)
            {
                target = null;
            }
            else
                return;

        }
        else
        {
            targets = Physics.OverlapSphere(this.transform.position, attackRadius, EnemyMask);
            shortDis = attackRadius;

            foreach (var obj in targets)
            {
                if (Vector3.Distance(obj.transform.position, transform.position) < shortDis)
                {
                    target = obj.transform;
                    shortDis = Vector3.Distance(obj.transform.position, transform.position);

                }
            }
        }





    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public virtual void Fire()
    {


        GameObject bullet = ObjectPool.Instance.GetPooledObject(poolIndex);
        bullet.GetComponent<Bullet>().element_Type = element_Type;
        bullet.GetComponent<Bullet>().damage = damage;//merminin elementini kulenin elementi yapıyoruz
        if (isAlevliOklarEnabled)
        {
            bullet.GetComponent<Bullet>().damage += 3; // yanma olcak
        }
        bullet.transform.position = firePos.position;
        bullet.GetComponent<Bullet>().Seek(target);

        GameManager.Instance.asource.PlayOneShot(bulletSoundClip);
        //bullet.transform.DOJump(target.position,JumpForce,0,(fireRate/bulletSpeed),false).SetEase(easeType);

    }
    public virtual void LevelUp()
    {
        if (level < maxLevel)
        {
            int openLevelIndex = level;
            level++;
            damage = DamageCounts[openLevelIndex - 1];
            attackRadius = AttackRadiusCounts[openLevelIndex - 1];
            if (GetComponent<FireTower>())
            {
                rangeObject.transform.localScale = new Vector3(attackRadius, .1f, attackRadius);
            }
            else
            {
                rangeObject.transform.localScale = new Vector3(attackRadius * 2, .1f, attackRadius * 2);
            }
            for (int i = 0; i < closeWithLevel.Length; i++)
            {
                // hepsini kapa
                closeWithLevel[i].SetActive(false);
            }
            openWithLevel[openLevelIndex - 1].SetActive(true);

            GameObject particle = ObjectPool.Instance.GetPooledObject(34);
            particle.transform.position = node.GetBuildPosition();
            GameManager.Instance.asource.PlayOneShot(buildSoundClip);
        }
    }
    IEnumerator ResetTower()
    {

        yield return new WaitForSeconds(fireRate);

        reset = true;
    }
    private void OnMouseEnter()
    {

        rangeObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        rangeObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (towerIsPlayer)
        {
            //  TheUI.Instance.isButton=false;
            // TheUI.Instance.ShopUIClose();      
            Invoke("OpenUIUpgrade", .6f);

            BuildManager.Instance.node = node;
            BuildManager.Instance.currentUpgradementTower = this;
            HUD.Instance.InitShopHud();
        }

    }
    public void OpenUIUpgrade()
    {
        //TheUI.Instance.isTurret = false;
        //  TheUI.Instance.isUpgrade = true;
        // TheUI.Instance.isArmy = false;
        //TheUI.Instance.ShopUIOpen();
        if (GetComponent<GoldMine>())
        {

            // TheUI.Instance.UShopButton3.interactable = false;
        }
        else
        {

            // TheUI.Instance.UShopButton3.interactable = true;
        }
    }
}
