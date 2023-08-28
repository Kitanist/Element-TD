using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MapPanel : MonoBehaviour
{
    
  
    public void ExitPanel () {
   
       this.gameObject.transform.GetChild(0).GetComponent<Image>().transform.DOScale(new Vector3(1,1,0),1);
       this.gameObject.GetComponent<CanvasGroup>().LeanAlpha(0,1).setOnComplete( ()=> { this.gameObject.SetActive(false); } );  

   
        StartCoroutine(CloseDelay());
    }
    IEnumerator CloseDelay(){
        yield return new WaitForSeconds(2);
       
        this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite=null;
        GameManager.Instance.chosenLevel=null;
        

    }
    public void EnterLevel () {
             SceneManager.LoadScene(GameManager.Instance.chosenLevel.levelId);// +1 eklememizin sebebi 1 tane menü levelinin olması 
    }
}
