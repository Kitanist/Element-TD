using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(HealthComponent))]

public class Unit : MonoBehaviour
{
    public UnitType unitType;
    public float unitDamage=10;
    public int myPoolIndex=1;
    public float speed=5;
    public float maxSpeed = 5;

    public float price=10;
    public string unitName;
    public PathNode nextPathNode;
    public bool isBackPath=false;
    public float turnSpeed=.1f;

   
  

    public void GoNextLocation()
    {

     
       
        Vector3 target = (nextPathNode.transform.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed);

        transform.position += target * speed * Time.deltaTime;


    }
    // Update is called once per frame
    void Update()
    {
        GoNextLocation();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("WaitArea") && gameObject.layer==7){
                gameObject.SetActive(false);
               
        }
    }
    
}
