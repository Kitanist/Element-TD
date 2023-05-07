using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingeleton<WaveManager>
{
  public int currentWaveCount=1;
   public int maxWaweCount=10;
   public float waveWaitTime=30;
    public void StartWawe (int waveCount) {
    //sıradaki dalgayı başlat
}
public void EndWave () {
    // dalgayı bitir ve 30 sn bekle

    StartCoroutine(WaitWave());
}
IEnumerator WaitWave(){
    yield return new WaitForSeconds(waveWaitTime);
}
}
