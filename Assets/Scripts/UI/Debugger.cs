using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Debugger : MonoSingeleton<Debugger>
{

    public TextMeshProUGUI DebugLogText;
    
  public void Debuger(string first)
    {
        DebugLogText.text = first;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first,string second)
    {
        DebugLogText.text = first + second;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first, string second,string ucuncu)
    {
        DebugLogText.text = first + second + ucuncu;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first, float second)
    {
        DebugLogText.text = first + second.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, string second)
    {
        DebugLogText.text = first.ToString() + second;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, float second)
    {
        DebugLogText.text = first.ToString() + second.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, string second, string ucuncu)
    {
        DebugLogText.text = first.ToString() + second + ucuncu;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first, float second, string ucuncu)
    {
        DebugLogText.text = first + second.ToString() + ucuncu;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first, string second, float ucuncu)
    {
        DebugLogText.text = first + second + ucuncu.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, float second, string ucuncu)
    {
        DebugLogText.text = first.ToString() + second.ToString() + ucuncu;
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(string first, float second, float ucuncu)
    {
        DebugLogText.text = first + second.ToString() + ucuncu.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, string second, float ucuncu)
    {
        DebugLogText.text = first.ToString() + second + ucuncu.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public void Debuger(float first, float second, float ucuncu)
    {
        DebugLogText.text = first.ToString() + second.ToString() + ucuncu.ToString();
        StartCoroutine(DebugTimeReser(1));
    }
    public IEnumerator DebugTimeReser(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        DebugLogText.text = null;
    }
}
