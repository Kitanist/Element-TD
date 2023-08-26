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
   public enum UnitType{
    Normal,
    Speeder,
    Armored,
    Boss
   }
public class GameManager : MonoSingeleton<GameManager>
{

   public GameObject myCastle;
   [SerializeField]private float gold=0;
   public Transform CastleTransform;
   public bool playerIsAttack=false;
   public bool isGameContinue=true;
   
public AudioSource asource;
public AudioClip buttonClik1;
public AudioClip buttonClik2;
  public PathCreator levelPathCreator;
  public PathCreator attackPathCreator;

  public bool currentCamIsMineTerritory=true;
[Header("SKILL POINT")]
 [Space(5)]
public int skillPoint=0;

 [Header("MAP")]
 [Space(5)]
 public bool []levelsOpen;
 public float []levelStartGolds;

 public Map chosenLevel;

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
