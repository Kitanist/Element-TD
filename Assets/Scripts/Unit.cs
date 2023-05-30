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
    public float cost=50;
    public string unitName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
