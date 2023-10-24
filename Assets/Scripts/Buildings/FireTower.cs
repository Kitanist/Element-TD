using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower :Tower
{
  
    public GameObject particles;
   // public GameObject rotatObject;
    private void Update()
    {
    if( targets.Length>0)
    particles.SetActive(true);
    else
    particles.SetActive(false);
        if (reset)
        {
            Fire();

            StartCoroutine(ResetTower());
        }
    }
    public override void Fire()
    {
        reset = false; //yar� eksen gerekiyormu� everlap box da dikkat edilmeli
        if (firePos)
        {      
            targets= Physics.OverlapSphere(firePos.position,attackRadius,EnemyMask);
            foreach (var obj in targets)
            {
                //hasar ver
               

                obj.GetComponent<HealthComponent>().GetDamage(damage, element_Type, Color.cyan);
                if (isIamBurningII)
                    obj.GetComponent<HealthComponent>().isImBurningII = true;
                GameManager.Instance.asource.PlayOneShot(bulletSoundClip);
            }
            Lights.SetActive(true);
            StartCoroutine(ResetLight());

        }
          
     
     /*   if (targets.Length > 0)
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
        }*/
       

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
    IEnumerator ResetLight()
    {
        yield return new WaitForSeconds(.3f);
        Lights.SetActive(false);
    }
}
