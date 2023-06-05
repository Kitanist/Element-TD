using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrrainController : MonoBehaviour
{
   
   private void OnMouseDown() {
     TheUI.Instance.isTurret = false;
        TheUI.Instance.isUpgrade = false;
        TheUI.Instance.isArmy = false;
          TheUI.Instance.isButton=false;
    TheUI.Instance.ShopUIClose();
  
      
   }
}
