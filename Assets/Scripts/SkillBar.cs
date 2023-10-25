using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public SkilType type;
    public int cost=1;
    public GameObject blurObject;
    public Button plusButton;
    public Button minusButton;
    public bool isOpen = false;
    private void OnEnable()
    {
        switch (type)
        {
            case SkilType.AugmentCount1Type:
                isOpen = GameManager.Instance.isAqumentCount1Open;
                break;
            case SkilType.AugmentCount2Type:
                isOpen = GameManager.Instance.isAqumentCount2Open;
                break;


        }

        if (isOpen)
        {
            plusButton.interactable = false;
            minusButton.interactable = false;
            blurObject.SetActive(false);
        }
    }
}
    
   
  

