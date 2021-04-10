﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenChanger : MonoBehaviour
{
    [SerializeField] private GameObject _targetScreen;
    private GameObject _currentScreen;

    private float _alphaDuration;
    private bool _changePermission;

    private void Start()
    {
        _alphaDuration = 0.2f;
        _changePermission = false;
        _currentScreen = transform.parent.gameObject;
    }

    private void Update()
    {
        ChangeScreen(_currentScreen, _targetScreen);
    }

    public void ToStartScreenChange()
    {
        _changePermission = true;
        _currentScreen.GetComponent<CanvasGroup>().DOFade(0f, _alphaDuration);
        _targetScreen.GetComponent<CanvasGroup>().interactable = false;
    }

    private void ChangeScreen(GameObject currentScreen, GameObject targetScreen)
    {
        if (currentScreen.GetComponent<CanvasGroup>().alpha <= 0 && _changePermission)
        {
            currentScreen.SetActive(false);

            targetScreen.GetComponent<CanvasGroup>().alpha = 0.01f;
            targetScreen.SetActive(true);
            targetScreen.GetComponent<CanvasGroup>().DOFade(1f, _alphaDuration);
            targetScreen.GetComponent<CanvasGroup>().interactable = true;

            _changePermission = false;
        }
    }
}
