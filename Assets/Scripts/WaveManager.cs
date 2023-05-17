using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
 
public class WaveManager : MonoSingeleton<WaveManager>
{
    [Serializable]
    public struct Wave
    {
         public List<Unit> WaveUnits;
       
    }
     [SerializeField] public Wave[] waves;
    [Header("Variable")]
    public int destroyedUnitCount=0;
    public int currentWaveCount=0;
    public float waveWaitTime = 30;
    public float unitSpawnTime = 2;
    private int nextUnitIndex = 0;
    private bool canStop = false;
    public float remainingTime;
    public Camera MotherlandCam, EnemySideCam;
    [Header("Textler")]
    public TextMeshProUGUI WaveCountDownText;
    public TextMeshProUGUI MoneyText;

    

   public Transform unitSpawnTransform;

    private void Update() {
    if(currentWaveCount<waves.Length)//wave sayısından büyük olmaz şu anki wave
    if(destroyedUnitCount>=waves[currentWaveCount].WaveUnits.Count)
        EndWave();
    }
   private void Start() {
        remainingTime=waveWaitTime;
      StartCoroutine(WaitWave());
   }
   
    public void StartWawe (int waveCount) {
        if(currentWaveCount<waves.Length && GameManager.Instance.isGameContinue){
          StartCoroutine(UnitSawnWait(waveCount));
        }
        else{
  Debug.Log("GameOver");
  GameManager.Instance.isGameContinue=false;
        }
      

    
}
public void EndWave () {
    // dalgayı bitir ve 30 sn bekle
    //eğer dalgadaki bütün düşmanlar ölmüşse diğer dalgaya  hazırlık yap
        Debug.Log(waves[currentWaveCount].WaveUnits.Count);
        InvokeRepeating("decreseRemainTime",0,1);
        StartCoroutine(WaitWave());
        destroyedUnitCount=0;
        Debug.Log("dalga bitmesi bekleni ve siradaki dalga cagirildi");
        nextUnitIndex=0;
        currentWaveCount++;
   
    
}
public void decreseRemainTime () {
    if(remainingTime>=0){
         remainingTime--;
            UIUpdate();
    }
   
    else
    CancelInvoke();
}
    public void UIUpdate()
    {
        WaveCountDownText.text = "Kalan Wave \n " + remainingTime.ToString();
        MoneyText.text = "Para : " + GameManager.Instance.Gold.ToString();
    }
public IEnumerator WaitWave(){
    canStop=true;
    HUD.Instance.setVisionOrAttackHUD.GetComponent<Image>().color=Color.red;
    yield return new WaitForSeconds(waveWaitTime);
    StartWawe(currentWaveCount);
    canStop=false;
    HUD.Instance.setVisionOrAttackHUD.GetComponent<Image>().color=Color.blue;
}
IEnumerator UnitSawnWait(int waveCount){
    
    yield return new WaitForSeconds(unitSpawnTime);
    if(nextUnitIndex <waves[waveCount].WaveUnits.Count){
     Unit _unit=waves[waveCount].WaveUnits[nextUnitIndex];   
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
     unit.GetComponent<Movement>().pathCreator=GameManager.Instance.levelPathCreator;
     unit.transform.position=unitSpawnTransform.position;
     nextUnitIndex++;
     StartCoroutine(UnitSawnWait(currentWaveCount));
    }
    else{
        Debug.Log("bu dalgadaki unitlerin spawnlanmasi bitmiştir");
        StopCoroutine(UnitSawnWait(currentWaveCount));
      if(destroyedUnitCount>=waves[currentWaveCount].WaveUnits.Count)
        EndWave(); //30 sn bekle
        
       
       
        yield return null;

    }
    
}
public void AttackOrSetCameraVision () {
    if(!GameManager.Instance.playerIsAttack){
        if(canStop){
        //eger stop wave arasındaysa  butona tıkladığında atağa geçer 
        //butonun sekli degisir
    
        GameManager.Instance.playerIsAttack=true;
        BattleManager.Instance.StartMyBattle();
        StopAllCoroutines();
        Debug.Log("saldir");
    }else{
       Debug.Log("kamera deei");
                //kamera açısı değişir rakip alanı görürüz
                MotherlandCam.enabled = false;
                EnemySideCam.enabled = true;
            } 
    }
    else{
         Debug.Log("kamera degis");
            //kamera açısı değişir rakip alanı görürüz
            MotherlandCam.enabled = false;
            EnemySideCam.enabled = true;
            BattleManager.Instance.PassOtherScene();
    }
   
    
}
}