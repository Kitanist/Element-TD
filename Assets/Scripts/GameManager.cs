using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   public bool playerIsAttack=false;
 
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
