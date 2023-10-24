using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public float speed=5;
    public float collectRate=20;
    public float collectAmount=1;
    private float fireRate;


    private void Start() {
        GetGold();
    }
   public void  GetGold () {
     StartCoroutine(ColletGold());
   }
   IEnumerator ColletGold(){
    fireRate=collectRate/speed;
    yield return new WaitForSeconds(fireRate);
    GameManager.Instance.Gold+=collectAmount;
    StartCoroutine(ColletGold());
   }


   
}
