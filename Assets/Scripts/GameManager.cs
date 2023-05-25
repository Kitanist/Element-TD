using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

  public enum Element_Type{
    None,
    Fire,
    Watter,
    Dirt,
    Air
   }
public class GameManager : MonoSingeleton<GameManager>
{
   [SerializeField]private float gold=0;
   public Transform CastleTransform;
   public bool playerIsAttack=false;
   public bool isGameContinue=true;
   public Tower currentUpgradementTower;

  public PathCreator levelPathCreator;
  public PathCreator attackPathCreator;
 
  public float Gold
 {
     get { return gold; }
     set
     {
         if(value < 0)
             gold = 0;
         else
            gold = value;
     }
 }

}
