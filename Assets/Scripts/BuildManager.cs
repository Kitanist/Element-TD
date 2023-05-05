using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject insaedilcekturret;

    public static BuildManager instance;
    public GameObject ArrowTower;
    private void Start()
    {
        insaedilcekturret = ArrowTower;
    }
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public GameObject GetTower()
    {
        return insaedilcekturret;
    }
}
