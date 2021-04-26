using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSourceConstructor : MonoBehaviour
{
    [SerializeField] private AudioSource _d6Sound;
    [SerializeField] private AudioSource _clickSound;

    [SerializeField] private Toggle _soundOn;

    private void Start()
    {
        _soundOn.isOn = true;
    }

    public void PlayD6Sound()
    {
        if (_soundOn.isOn)
            _d6Sound.Play();
    }

    public void PlayClickSound()
    {
        if (_soundOn.isOn)
            _clickSound.Play();
    }
}
