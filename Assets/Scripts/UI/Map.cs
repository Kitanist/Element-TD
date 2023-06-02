using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Map : MonoBehaviour
{
    public Image img;
   public GameObject parentFront;
   public int levelId; // harita id leri 0 dan başlar 
    void Start()
    {
        img=GetComponent<Image>();
        img.alphaHitTestMinimumThreshold=0.1f;// resimin sekline göre buton etkileşimi kabul eder hatalı
        if(GameManager.Instance.levelsOpen[levelId]){ // level açıldıysa butonu aktif et
            GetComponent<Button>().enabled=true;
        }
        else{
              GetComponent<Button>().enabled=false;
        }
    }
  
   public void  LoadLevelPanel () {
  
        GameManager.Instance.chosenLevel=this;
         parentFront.SetActive(true);
     parentFront.gameObject.GetComponent<CanvasGroup>().LeanAlpha(1,1);
     parentFront.transform.GetChild(0).GetComponent<Image>().sprite=GameManager.Instance.chosenLevel.img.sprite;
     parentFront.transform.GetChild(0).GetComponent<Image>().transform.DOScale(new Vector3(6,6,0),2);

      
   }
    

             
    
}
