using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class TheUI : MonoBehaviour
{
    public List<GameObject> UIElements;
    public RectTransform rectTreansform;
   public void OpenTheUI()
    {
        foreach (GameObject UIElement in UIElements)
        {
            UIElement.SetActive(true);
            
        }
        rectTreansform.DOAnchorPos(new Vector2(0, 0), 1f, false);
    }
    public void CloseTheUI()
    {
        rectTreansform.DOAnchorPos(new Vector2(0, 1000), 1f, false);
        foreach (GameObject UIElement in UIElements)
        {
            UIElement.SetActive(false);

        }

    }
}
