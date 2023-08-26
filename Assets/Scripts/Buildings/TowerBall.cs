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

            Vector3 Direction = (target.transform.position - transform.position);

            Quaternion rot = Quaternion.LookRotation(Direction);
            rotatObject.transform.rotation = rot;



        }
    }
    IEnumerator ResetTower()
    {

        yield return new WaitForSeconds(fireRate);

        reset = true;
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
        }



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }



    private void OnMouseDown()
    {
        // TheUI.Instance.isButton=false;
        // TheUI.Instance.ShopUIClose();      
        Invoke("OpenUIUpgrade", .6f);
        BuildManager.Instance.currentUpgradementTower = this;
        HUD.Instance.InitShopHud();
    }
}
