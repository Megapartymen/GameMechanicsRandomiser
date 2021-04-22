using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTargetScreen : MonoBehaviour
{
    [SerializeField] public GameObject TargetScreen;
    [SerializeField] private GameObject _randomResultSpace;
    [SerializeField] private string _NameOfTargetScreen;

    private void Update()
    {
        _NameOfTargetScreen = _randomResultSpace.GetComponent<MechanicRandomizer>()._firstInfoScreenName;
        TargetScreen = GameObject.Find(_NameOfTargetScreen);
        TargetScreen.
    }
}
