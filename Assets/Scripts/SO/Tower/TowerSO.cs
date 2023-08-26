using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Tower", menuName = "GameObjects/Tower")]
public class TowerSO : ScriptableObject
{
   public GameObject prefab;

   public GameObject SelectThis()
   {
      return prefab;
   }
}
