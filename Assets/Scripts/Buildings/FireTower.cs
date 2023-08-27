using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower :Tower
{
    public Collider[] UnTargets;
    public GameObject[] particles;
   // public GameObject rotatObject;
    private void Update()
    {

        if (reset)
        {
            Fire();

            StartCoroutine(ResetTower());
        }
    }
    public override void Fire()
    {
        reset = false; //yarý eksen gerekiyormuþ everlap box da dikkat edilmeli
        targets = Physics.OverlapBox(firePos.position, new Vector3(attackRadius / 2, attackRadius / 2, attackRadius / 2), Quaternion.identity, EnemyMask);
        UnTargets = Physics.OverlapBox(firePos.position, new Vector3((attackRadius / 3)*2, (attackRadius / 3) * 2 , (attackRadius / 3) * 2), Quaternion.identity, EnemyMask);
        foreach (var obj in targets)
        {
            //hasar ver

            obj.GetComponent<HealthComponent>().GetDamage(damage, element_Type);
            if(isIamBurningII)
            obj.GetComponent<HealthComponent>().isImBurningII = true;
            GameManager.Instance.asource.PlayOneShot(bulletSoundClip);
        }
     
        if (targets.Length > 0)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].SetActive(true);
                target = targets[0].transform;
            }
        }
        else
        {
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].SetActive(false);
                target = null;
            }
        }

    }
    private void FixedUpdate()
    {
        if (target)
        {

           // Vector3 Direction = (target.transform.position - transform.position);
           //
           // Quaternion rot = Quaternion.LookRotation(-Direction);
          //  rotatObject.transform.rotation = rot;


        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(firePos.position, new Vector3(attackRadius, attackRadius, attackRadius));
    }

    public override void LevelUp()
    {
        base.LevelUp();
    }
    private void OnMouseDown()
    {
        //TheUI.Instance.isButton=false;
        //TheUI.Instance.ShopUIClose();      
        Invoke("OpenUIUpgrade", .6f);
        BuildManager.Instance.currentUpgradementTower = this;
        HUD.Instance.InitShopHud();
    }

    IEnumerator ResetTower()
    {

        yield return new WaitForSeconds(fireRate);


        reset = true;
    }
}
