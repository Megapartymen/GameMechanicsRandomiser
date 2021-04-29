using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LogoScreenAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _nextScreen;
    
    private float _alphaDuration;

    
    private void Start()
    {
        _alphaDuration = 0.8f;

        StartCoroutine(PlayLogoScreenAnimation());
    }

    private void Update()
    {
        TryLoadNextScreen();
    }

    private IEnumerator PlayLogoScreenAnimation()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0.02f;
        gameObject.GetComponent<CanvasGroup>().DOFade(1, _alphaDuration);

        yield return new WaitForSeconds(1);

        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().DOFade(0, _alphaDuration);                            
    }

    private void TryLoadNextScreen()
    {
        if (gameObject.GetComponent<CanvasGroup>().alpha <= 0.01f)
        {
            gameObject.SetActive(false);

            _nextScreen.GetComponent<CanvasGroup>().alpha = 0.01f;
            _nextScreen.SetActive(true);
            _nextScreen.GetComponent<CanvasGroup>().DOFade(1f, _alphaDuration);
            _nextScreen.GetComponent<CanvasGroup>().interactable = true;
        }
    }
}
