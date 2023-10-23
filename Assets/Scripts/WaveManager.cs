using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WaveManager : MonoSingeleton<WaveManager>
{
    [Serializable]
    public struct Wave
    {
         public List<Unit> WaveUnits;
         public List <int> diffrentUnitCounts;
    }
     [SerializeField] public Wave[] waves;
    [Header("Variable")]
    public int destroyedUnitCount=0;
    public int currentWaveCount=0;
    public float waveWaitTime = 30;
    public float unitSpawnTime = 2;
    private int nextUnitIndex = 0;
    public bool canStop = false;
   
    public float remainingTime;
    public Camera MotherlandCam, EnemySideCam;
    public Transform MotherTargetCamOffset, EnemyTargetCamOffset;
    [Header("Textler")]
    public TextMeshProUGUI WaveCountDownText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI WaveLeft;
    public Button attackButton;
    

   public Transform unitSpawnTransform;

public AudioClip timeClip;
public AudioClip timeClip2;
public AudioClip timeClip3;
public AudioClip dangerClip;
    private void Update() {
     
      
           
      
    
    if(currentWaveCount<waves.Length)//wave sayısından büyük olmaz şu anki wave
    if(destroyedUnitCount>=waves[currentWaveCount].WaveUnits.Count)
        EndWave();
        UIUpdate();
    }
    
   private void Start() {
        MotherlandCam.enabled = true;
        EnemySideCam.enabled = false;
        CameraRotator.Instance.cam = MotherlandCam;
        CameraRotator.Instance.target = MotherTargetCamOffset;
        CameraRotator.Instance.isCamChange = true;
        
        UIUpdate();
        remainingTime =waveWaitTime;
      StartCoroutine(WaitWave());
       
    }
  
    public void StartWawe (int waveCount) {
        if(currentWaveCount<waves.Length && GameManager.Instance.isGameContinue){
          
          StartCoroutine(UnitSawnWait(waveCount));
        }
        else{
  Debug.Log("GameOver");
            SceneManager.LoadScene(0);
  GameManager.Instance.isGameContinue=false;
        }
      

    
}
public void EndWave () {
    // dalgayı bitir ve 30 sn bekle
    //eğer dalgadaki bütün düşmanlar ölmüşse diğer dalgaya  hazırlık yap
       // Debug.Log(waves[currentWaveCount].WaveUnits.Count);
       
        StartCoroutine(WaitWave());
       GameManager.Instance.myCastle.GetComponent<Castle>().isSoytariActive=false;
        GameManager.Instance.mySoytari.SetActive(false);
        destroyedUnitCount=0;
        Debugger.Instance.Debuger("Wait For Next Wave ");
        nextUnitIndex =0;
        currentWaveCount++;
        HUD.Instance.RefreshUnitCount();
        
    
}
public void decreseRemainTime () {
        
       
    if(remainingTime>0 && !GameManager.Instance.playerIsAttack){
         remainingTime--;
         if(remainingTime>=4 ){
            if(remainingTime%2==0)
               GameManager.Instance.asource.PlayOneShot(timeClip);
         }
      
         else{
            if(remainingTime%2==0){
                GameManager.Instance.asource.PlayOneShot(timeClip2);
            }
            else
             GameManager.Instance.asource.PlayOneShot(timeClip3);
         }
          
            UIUpdate();
    }

        else { 
                GameManager.Instance.asource.PlayOneShot(dangerClip);
    CancelInvoke();
        remainingTime = waveWaitTime;
}}
   
    public void UIUpdate()
    {
        if(canStop)
        WaveCountDownText.text = "NextWave: " + remainingTime.ToString();
        else
          WaveCountDownText.text = "Wave Coming ";
        MoneyText.text = "Gold: " + GameManager.Instance.Gold.ToString();
        WaveLeft.text = currentWaveCount + " / " + waves.Length + "  Wave Left";
    }
public IEnumerator WaitWave(){
        BattleManager.Instance.isAttackedThisTurn = false;
        remainingTime = waveWaitTime;
        InvokeRepeating("decreseRemainTime", 0, 1);
        UIUpdate();
        canStop =true;
   
   
    yield return new WaitForSeconds(waveWaitTime);
    
    StartWawe(currentWaveCount);
    canStop=false;
    UIUpdate();

}
  
IEnumerator UnitSawnWait(int waveCount){
    
    yield return new WaitForSeconds(unitSpawnTime);
    if(nextUnitIndex <waves[waveCount].WaveUnits.Count){
 
     Unit _unit=waves[waveCount].WaveUnits[nextUnitIndex];   
     
     GameObject unit =ObjectPool.Instance.GetPooledObject(_unit.myPoolIndex);
          
            unit.transform.position = unitSpawnTransform.position;
            //  unit.GetComponent<Movement>().pathCreator=GameManager.Instance.levelPathCreator;
            var rand = Random.Range(0, GameManager.Instance.startUnitNode.Length);
            unit.GetComponent<Unit>().nextPathNode = GameManager.Instance.startUnitNode[rand];

            nextUnitIndex++;
     StartCoroutine(UnitSawnWait(currentWaveCount));
    }
    else{
            Debugger.Instance.Debuger("This Wave Spawn Ended");
        StopCoroutine(UnitSawnWait(currentWaveCount));
      if(destroyedUnitCount>=waves[currentWaveCount].WaveUnits.Count)
        EndWave(); //30 sn bekle
        
       
       
        yield return null;

    }
    
}

public void SetCamerVision () {

    if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);

         if(GameManager.Instance.currentCamIsMineTerritory){
        GameManager.Instance.currentCamIsMineTerritory = false;
              MotherlandCam.enabled = false;
                EnemySideCam.enabled = true;
            CameraRotator.Instance.cam = EnemySideCam;
            CameraRotator.Instance.target = EnemyTargetCamOffset;
            CameraRotator.Instance.isCamChange = true;
        }
         else{
                    GameManager.Instance.currentCamIsMineTerritory = true;
             MotherlandCam.enabled = true;
                EnemySideCam.enabled = false;
            CameraRotator.Instance.cam = MotherlandCam;
            CameraRotator.Instance.target = MotherTargetCamOffset;
            CameraRotator.Instance.isCamChange = true;
        }
                //kamera açısı değişir rakip alanı görürüz
}
public void Attack() {
    if(UnityEngine.Random.Range(0,2)==1)
    GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik1);
    else
      GameManager.Instance.asource.PlayOneShot(GameManager.Instance.buttonClik2);
      
    if(!GameManager.Instance.playerIsAttack){
        if(BattleManager.Instance.unitList.Count>0 && canStop){
         //eger stop wave arasındaysa  butona tıkladığında atağa geçer 
        
        GameManager.Instance.playerIsAttack=true;
        BattleManager.Instance.StartMyBattle();
        
        StopAllCoroutines();
                BattleManager.Instance.isAttackedThisTurn = true;
       }
       else{
        Debugger.Instance.Debuger("U can Not Attack For Now");
       }
    }
    else{ // 
         
      
          //kamera açısı değişir rakip alanı görürüz
          SetCamerVision();
      BattleManager.Instance.PassOtherScene();
            
            
    }
   
    
}
}