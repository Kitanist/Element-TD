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
    public float cost=50;
    public float price=10;
    public string unitName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("WaitArea") && gameObject.layer==7){
                gameObject.SetActive(false);
                Debug.Log("spriseee");
        }
    }
}
