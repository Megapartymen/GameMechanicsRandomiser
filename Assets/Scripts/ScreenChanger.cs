using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject _targetScreen;
    private GameObject _currentScreen;

    private float _alphaDuration;
    private bool _loadPermission;

    //[SerializeField] string NameOfSpecialTargetScreen;

    private void Start()
    {
        _alphaDuration = 0.2f;
        _loadPermission = false;
        _currentScreen = transform.parent.gameObject;
    }

    private void Update()
    {
        TryLoadScreen();
    }

    public void ToStartScreenChange()
    {
        _loadPermission = true;
        //TryGetSpecialTargetScreen();
        _currentScreen.GetComponent<CanvasGroup>().DOFade(0f, _alphaDuration);
        _targetScreen.GetComponent<CanvasGroup>().interactable = false;
    }

    private void TryLoadScreen()
    {
        if (_currentScreen.GetComponent<CanvasGroup>().alpha <= 0 && _loadPermission)
        {
            _currentScreen.SetActive(false);

            if (gameObject.TryGetComponent<SpecialTargetScreen>(out SpecialTargetScreen specialTargetScreen))
            {
                _targetScreen = specialTargetScreen.TargetScreen;
            }

            TuneBackButtonOnTargetScreen();

            _targetScreen.GetComponent<CanvasGroup>().alpha = 0.01f;
            _targetScreen.SetActive(true);
            _targetScreen.GetComponent<CanvasGroup>().DOFade(1f, _alphaDuration);
            _targetScreen.GetComponent<CanvasGroup>().interactable = true;

            _loadPermission = false;
        }
    }

    private void TuneBackButtonOnTargetScreen()
    {
        for (int i = 0; i < _targetScreen.transform.childCount; i++)
        {
            if (_targetScreen.transform.GetChild(i).TryGetComponent<BackButton>(out BackButton dummy))
            {
                _targetScreen.transform.GetChild(i).gameObject.GetComponent<ScreenChanger>()._targetScreen = _currentScreen;
                break;
            }
        }
    }

    //private void TryGetSpecialTargetScreen()
    //{
    //    if (NameOfSpecialTargetScreen != null)
    //    {
    //        _targetScreen = GameObject.Find(NameOfSpecialTargetScreen);
    //    }               
    //}
}
