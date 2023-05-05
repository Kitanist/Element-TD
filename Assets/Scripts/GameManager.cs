using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingeleton<GameManager>
{
   [SerializeField]private float gold=0;
   public int currentWaveCount=1;
   public int maxWaweCount=10;
   public float waveWaitTime=30;
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
public void StartWawe (int waveCount) {
    //sıradaki dalgayı başlat
}
public void EndWave () {
    // dalgayı bitir ve 30 sn bekle
}
IEnumerator WaitWave(){
    yield return new WaitForSeconds(waveWaitTime);
}
}
