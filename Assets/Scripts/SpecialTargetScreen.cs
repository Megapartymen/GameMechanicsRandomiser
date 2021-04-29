using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTargetScreen : MonoBehaviour
{
    [SerializeField] private GameObject _findInfoScreenSpace;
    [HideInInspector] public string NameOfInfoScreen;
    private GameObject _targetScreen;

    public GameObject TargetScreen => _targetScreen;

    public void SetSpecialTargetScreen()
    {
        GameObject tempForScreen = _findInfoScreenSpace.transform.Find(NameOfInfoScreen).gameObject; ;

        if (_findInfoScreenSpace != tempForScreen)
        {
            _targetScreen = tempForScreen;
        }
    }
}
