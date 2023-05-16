using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationArmy : MonoBehaviour
{
    private FormationBase _formation;

    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }


}
