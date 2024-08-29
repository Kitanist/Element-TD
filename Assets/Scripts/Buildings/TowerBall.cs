using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TowerBall : Tower
{

    public bool isUseFirstImpact;
    public GameObject rotatObject;
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
    private void FixedUpdate()
    {
        if (target)
        {

           // Vector3 Direction = (target.transform.position - transform.position);
           //
           // Quaternion rot = Quaternion.LookRotation(Direction);
           // rotatObject.transform.rotation = rot;



        }
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
    public override void LevelUp()
    {
        base.LevelUp();
    }
    public override void UpdateTarget()
    {
        base.UpdateTarget();
    }
    public override void Fire()
    {
        if (isCantPass)
        {
            targets = Physics.OverlapSphere(transform.position, attackRadius,EnemyMask);
            foreach (var item in targets)
            {
                item.GetComponent<Unit>().speed -= 1;
                StartCoroutine(ReturnNormalSpeed(item));
            }
            Lights.SetActive(true);
            StartCoroutine(ResetLight());
        }
        else
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject(poolIndex);

            bullet.GetComponent<BallBullet>().damage = damage;//merminin elementini kulenin elementi yapıyoruz
            bullet.GetComponent<BallBullet>().element_Type = element_Type;
            bullet.transform.position = firePos.position;

            bullet.transform.DOJump(target.position, JumpForce, 0, (fireRate / bulletSpeed), false).SetEase(easeType);
            GameManager.Instance.asource.PlayOneShot(bulletSoundClip);

            if (isFistImpact && !isUseFirstImpact)
            {
                bullet.GetComponent<BallBullet>().damage += damage;
                isUseFirstImpact = true;
                Lights.SetActive(true);
                StartCoroutine(ResetLight());
            }
            Lights.SetActive(true);
            StartCoroutine(ResetLight());
        }
        



    }
    


    private void OnMouseDown()
    {
        // TheUI.Instance.isButton=false;
        // TheUI.Instance.ShopUIClose();      
        Invoke("OpenUIUpgrade", .6f);
     
       
    }
    IEnumerator ReturnNormalSpeed(Collider targett )
    {
        yield return new WaitForSeconds(1f);
       
        
          targett.GetComponent<Unit>().speed = targett.GetComponent<Unit>().maxSpeed;
        
    }
}
