using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MechanicRandomizer : MonoBehaviour
{
    [SerializeField] private GameMechanic _actMechanic;
    [SerializeField] private List<GameMechanic> _dimensionalMechanics;
    [SerializeField] private List<GameMechanic> _triggerMechanics;
    [SerializeField] private List<GameMechanic> _mentalMechanics;
    [SerializeField] private List<GameMechanic> _combinedMechanics;    

    [Header("First random result")]
    [SerializeField] private Image _firstMechanicIcon;
    [SerializeField] private TextMeshProUGUI _firstMechanicName;
    [SerializeField] private SpecialTargetScreen _firstInfoButton;

    [Header("Second random result")]
    [SerializeField] private Image _secondMechanicIcon;
    [SerializeField] private TextMeshProUGUI _secondMechanicName;
    [SerializeField] private SpecialTargetScreen _secondInfoButton;

    [Header("Third random result")]
    [SerializeField] private Image _thirdMechanicIcon;
    [SerializeField] private TextMeshProUGUI _thirdMechanicName;
    [SerializeField] private SpecialTargetScreen _thirdInfoButton;

    [Header("Toggles")]
    [SerializeField] private Toggle _useAct;
    [SerializeField] private Toggle _useCombined;

    //public string _firstInfoScreenName;
    //public string _secondInfoScreenName;
    //public string _thirdInfoScreenName;

    private List<GameMechanic> _mechanicsForRandom;
    private GameMechanic _firstRandomResult;
    private GameMechanic _secondRandomResult;
    private GameMechanic _thirdRandomResult;

    
    private bool _useCombinedMechanics;
    private bool _useActMechanic;

    private float _alphaDuration;
    private float _toStartNextRandomCount;
    private float _triggerRange;
    private bool _startTrigger;

    private void Start()
    {
        _useCombinedMechanics = false;
        _useActMechanic = false;

        _alphaDuration = 0.5f;
        _triggerRange = 0.05f;
        _toStartNextRandomCount = 0.5f;
    }

    private void Update()
    {
        TryRandomizeMechanic(_thirdMechanicIcon, _firstMechanicIcon, _firstMechanicName, _firstInfoButton, _startTrigger);
        TryRandomizeMechanic(_firstMechanicIcon, _secondMechanicIcon, _secondMechanicName, _secondInfoButton);
        TryRandomizeMechanic(_secondMechanicIcon, _thirdMechanicIcon, _thirdMechanicName, _thirdInfoButton);
    }    
    
    public void RandomizeAllMechanic()
    {
        gameObject.GetComponent<AudioSource>().Play();

        _mechanicsForRandom = new List<GameMechanic>();        



        AddMechanicsToGlobalList(_mechanicsForRandom, _dimensionalMechanics);
        AddMechanicsToGlobalList(_mechanicsForRandom, _triggerMechanics);
        AddMechanicsToGlobalList(_mechanicsForRandom, _mentalMechanics);

        if (_useCombined.isOn)
        {
            AddMechanicsToGlobalList(_mechanicsForRandom, _combinedMechanics);
        }

        if (_useAct.isOn)
        {
            _mechanicsForRandom.Add(_actMechanic);
        }

        _startTrigger = true;

        //_firstRandomResult = RandomizeMechanic(_mechanicsForRandom);
        //ShowRandomResult(_firstRandomResult, _firstMechanicIcon, _firstMechanicName, _firstInfoButton);
        //_secondRandomResult = RandomizeMechanic(_mechanicsForRandom);
        //ShowRandomResult(_secondRandomResult, _secondMechanicIcon, _secondMechanicName, _secondInfoButton);
        //_thirdRandomResult = RandomizeMechanic(_mechanicsForRandom);
        //ShowRandomResult(_thirdRandomResult, _thirdMechanicIcon, _thirdMechanicName, _thirdInfoButton);
    }

    private void TryRandomizeMechanic(Image referenceIcon, Image icon, TextMeshProUGUI name, SpecialTargetScreen infoButton)
    {
        bool startTrigger = false;

        if (referenceIcon.GetComponent<CanvasGroup>().alpha <= _toStartNextRandomCount && referenceIcon.GetComponent<CanvasGroup>().alpha >= (_toStartNextRandomCount - _triggerRange))
            startTrigger = true;

        if (startTrigger)
            icon.GetComponent<CanvasGroup>().DOFade(0, _alphaDuration);

        if (icon.GetComponent<CanvasGroup>().alpha <= 0.01f)
        {
            ShowRandomResult(RandomizeMechanic(_mechanicsForRandom), icon, name, infoButton);
            icon.GetComponent<CanvasGroup>().DOFade(1, _alphaDuration);
        }
    }

    private void TryRandomizeMechanic(Image referenceIcon, Image icon, TextMeshProUGUI name, SpecialTargetScreen infoButton, bool startTrigger)
    {
        if (referenceIcon.GetComponent<CanvasGroup>().alpha <= _toStartNextRandomCount)
            startTrigger = false;

        if (startTrigger)
            icon.GetComponent<CanvasGroup>().DOFade(0, _alphaDuration);

        if (icon.GetComponent<CanvasGroup>().alpha <= 0.01f)
        {
            ShowRandomResult(RandomizeMechanic(_mechanicsForRandom), icon, name, infoButton);
            icon.GetComponent<CanvasGroup>().DOFade(1, _alphaDuration);
        }

        _startTrigger = false;
    }

    private GameMechanic RandomizeMechanic(List<GameMechanic> list)
    {
        GameMechanic mechanic = list[Random.Range(0, list.Count)];
        list.Remove(mechanic);

        return mechanic;
    }

    private void ShowRandomResult(GameMechanic mechanic, Image icon, TextMeshProUGUI name, SpecialTargetScreen infoButton)
    {
        icon.sprite = mechanic.Icon;
        name.text = mechanic.Name;
        icon.color = mechanic.Color;
        name.color = mechanic.Color;
        infoButton.NameOfInfoScreen = mechanic.NameOfInfoScreen;
    }

    private void AddMechanicsToGlobalList(List<GameMechanic> globalList, List<GameMechanic> sourceList)
    {
        foreach (var mechanic in sourceList)
        {
            globalList.Add(mechanic);
        }
    }

    public void SuperMethod(bool ass)
    {
        if (ass)
        {
            _useActMechanic = true;
        }
        else
        {
            _useActMechanic = false;
        }
    }
    
    public void AddCombinedMechanicsFromList()
    {
        _useCombinedMechanics = true;
    }

    public void NoAddCombinedMechanicsFromList()
    {
        _useCombinedMechanics = false;
    }

    public void AddActMechanicFromList()
    {
        _useActMechanic = true;
    }

    public void NoAddActMechanicFromList()
    {
        _useActMechanic = false;
    }

    //private void TuneAboutButtonOnRandomResult()
    //{
        //GameObject backButton = _targetScreen.transform.Find("BackButton").gameObject;

        //for (int i = 0; i < _targetScreen.transform.childCount; i++)
        //{
        //    if (_targetScreen.transform.GetChild(i).TryGetComponent<BackButton>(out BackButton dummy))
        //    {
        //        backButton = _targetScreen.transform.GetChild(i).gameObject;
        //        break;
        //    }
        //}

        //backButton.GetComponent<ScreenChanger>()._targetScreen = _currentScreen;
    //}

    //public void RandomizeAllMechanic()
    //{
    //    gameObject.GetComponent<AudioSource>().Play();

    //    List<GameMechanic> mechanicsForRandom = new List<GameMechanic>();



    //    AddMechanicsToGlobalList(mechanicsForRandom, _dimensionalMechanics);
    //    AddMechanicsToGlobalList(mechanicsForRandom, _triggerMechanics);
    //    AddMechanicsToGlobalList(mechanicsForRandom, _mentalMechanics);

    //    if (_useCombinedMechanics)
    //    {
    //        AddMechanicsToGlobalList(mechanicsForRandom, _combinedMechanics);
    //    }

    //    if (_useActMechanic)
    //    {
    //        mechanicsForRandom.Add(_actMechanic);
    //    }

    //    _firstRandomResult = RandomizeMechanic(mechanicsForRandom);
    //    ShowRandomResult(_firstRandomResult, _firstMechanicIcon, _firstMechanicName, _firstInfoButton);
    //    _secondRandomResult = RandomizeMechanic(mechanicsForRandom);
    //    ShowRandomResult(_secondRandomResult, _secondMechanicIcon, _secondMechanicName, _secondInfoButton);
    //    _thirdRandomResult = RandomizeMechanic(mechanicsForRandom);
    //    ShowRandomResult(_thirdRandomResult, _thirdMechanicIcon, _thirdMechanicName, _thirdInfoButton);
    //}
}
