using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using DG.Tweening;

public class StoryRandomizer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _firstTextSpace;
    [SerializeField] private TextMeshProUGUI _secondTextSpace;
    [SerializeField] private TextMeshProUGUI _thirdTextSpace;
    [SerializeField] private TextMeshProUGUI _fourthTextSpace;

    [SerializeField] private TextAsset _nouns;
    [SerializeField] private TextAsset _adjectives;
    [SerializeField] private TextAsset _verbs;

    [SerializeField] private List<string> _heroArray;
    private List<string> _natureOfActionArray;
    private List<string> _actArray;
    private List<string> _subjectArray;

    private float _alphaDuration;
    private float _toStartNextRandomCount;
    private float _triggerRange;
    private bool _startTrigger;

    private void Start()
    {
        Debug.Log(_nouns.text);
        
        _alphaDuration = 0.5f;
        _triggerRange = 0.05f;
        _toStartNextRandomCount = 0.5f;

        _heroArray = _nouns.text.Split('\n').ToList();
        _natureOfActionArray = _adjectives.text.Split('\n').ToList();
        _actArray = _verbs.text.Split('\n').ToList();
        _subjectArray = _nouns.text.Split('\n').ToList();
    }

    private void Update()
    {
        TryRandomizeTextSpace(_fourthTextSpace, _firstTextSpace, _heroArray, _startTrigger);
        TryRandomizeTextSpace(_firstTextSpace, _secondTextSpace, _natureOfActionArray);
        TryRandomizeTextSpace(_secondTextSpace, _thirdTextSpace, _actArray);
        TryRandomizeTextSpace(_thirdTextSpace, _fourthTextSpace, _subjectArray);
    }

    public void ToStartRandomizeStory()
    {
        _startTrigger = true;
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void TryRandomizeTextSpace(TextMeshProUGUI alphaReferenceForStart, TextMeshProUGUI textSpace, List<string> array)
    {
        bool startTrigger = false;

        if (alphaReferenceForStart.alpha <= _toStartNextRandomCount && alphaReferenceForStart.alpha >= (_toStartNextRandomCount - _triggerRange))
            startTrigger = true;

        if (startTrigger)
            textSpace.DOFade(0, _alphaDuration);

        if (textSpace.alpha <= 0.01f)
        {
            textSpace.text = SetRandomWord(array);
            textSpace.DOFade(1, _alphaDuration);
        }
    }

    private void TryRandomizeTextSpace(TextMeshProUGUI alphaReferenceForStart, TextMeshProUGUI textSpace, List<string> array, bool startTrigger)
    {

        if (alphaReferenceForStart.alpha <= _toStartNextRandomCount)
            startTrigger = false;

        if (startTrigger)
            textSpace.DOFade(0, _alphaDuration);

        if (textSpace.alpha <= 0.01f)
        {
            textSpace.text = SetRandomWord(array);
            textSpace.DOFade(1, _alphaDuration);
        }

        _startTrigger = false;
    }

    private string SetRandomWord(List<string> array)
    {
        string word = array[Random.Range(0, _heroArray.Count - 1)];
        return word;
    }
}