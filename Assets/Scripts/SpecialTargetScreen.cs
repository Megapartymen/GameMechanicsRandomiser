using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTargetScreen : MonoBehaviour
{
    [SerializeField] private GameObject _dummyScreen;
    [SerializeField] public GameObject TargetScreen;
    [SerializeField] private GameObject _findInfoScreenSpace;
    public string NameOfInfoScreen;

    public void SetSpecialTargetScreen()
    {
        GameObject tempForScreen = _findInfoScreenSpace.transform.Find(NameOfInfoScreen).gameObject; ;

        if (_findInfoScreenSpace != tempForScreen)
        {
            TargetScreen = tempForScreen;
        }
    }
}
