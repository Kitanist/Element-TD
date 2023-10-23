﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
   public GameObject mySoytari;
   [SerializeField]private float gold=0;
   public Transform CastleTransform;
   public bool playerIsAttack=false;
   public bool isGameContinue=true;
   
public AudioSource asource;
public AudioClip buttonClik1;
public AudioClip buttonClik2;


    public PathNode[] startUnitNode;
    public PathNode[] endUnitNode;

    public bool currentCamIsMineTerritory=true;
[Header("SKILL POINT")]
 [Space(5)]
public int skillPoint=0;
public int aqumentCount = 1; //aqument count arttıkca çıkacak eklenti sayısı artar
public int aqumentCountMax = 3;
public int aqumentRollCount = 1; //aqument roll sayısı gelisimi ve max rolleme sayısı
public int aqumentRollCountMax = 3;

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
