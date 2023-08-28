using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Element_Type element_Type;
    public float damage = 10;
    public Transform target;
    public float speed = 70;
    public bool isBurned;
    public bool isIlkDarbe;
    public bool isIamBrning;
   

    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (!target)
        {
            gameObject.SetActive(false);
            return;
        }
        Vector3 dir = transform.position - target.position;
        float distanceFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceFrame)
        {
            target.GetComponent<HealthComponent>().GetDamage(damage, element_Type);
            if (isBurned)
            {
                target.GetComponent<HealthComponent>().GetBurnedDamage(damage, element_Type);
                Debug.Log("Yanma Hasarý Start");
            }
            if (isIlkDarbe )
            {
                target.GetComponent<HealthComponent>().isIlkDarbe = true;
                    
            }
            if (isIamBrning)
            {
                target.GetComponent<HealthComponent>().isImBurning = true;
            }
       

            gameObject.SetActive(false);

        }
        transform.Translate(-dir.normalized * distanceFrame, Space.World);
    }
   
    
}
