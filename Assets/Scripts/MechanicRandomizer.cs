using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MechanicRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameMechanic> _dimensionalMechanics;
    [SerializeField] private List<GameMechanic> _triggerMechanics;
    [SerializeField] private List<GameMechanic> _mentalMechanics;
    [SerializeField] private List<GameMechanic> _combinedMechanics;    

    [SerializeField] private Image _firstMechanicIcon;
    [SerializeField] private TextMeshProUGUI _firstMechanicName;
    [SerializeField] private ScreenChanger _firstMechanicScreenChanger;
    [SerializeField] private Image _secondMechanicIcon;
    [SerializeField] private TextMeshProUGUI _secondMechanicName;
    [SerializeField] private ScreenChanger _secondMechanicScreenChanger;
    [SerializeField] private Image _thirdMechanicIcon;
    [SerializeField] private TextMeshProUGUI _thirdMechanicName;
    [SerializeField] private ScreenChanger _thirdMechanicScreenChanger;

    public string _firstInfoScreenName;
    public string _secondInfoScreenName;
    public string _thirdInfoScreenName;

    //private List<GameMechanic> _mechanicsForRandom;
    private GameMechanic _firstResultMechanic;
    private GameMechanic _secondResultMechanic;
    private GameMechanic _thirdResultMechanic;

    
    
    private bool _useCombinedMechanics = false;

    public void AddCombinedMechanicsFromList()
    {
        _useCombinedMechanics = true;
    }

    public void NoAddCombinedMechanicsFromList()
    {
        _useCombinedMechanics = false;
    }


    public void RandomizeAllMechanic(bool useCombinedMechanics)
    {
        List<GameMechanic> mechanicsForRandom = new List<GameMechanic>();

        AddMechanicsToGlobalList(mechanicsForRandom, _dimensionalMechanics);
        AddMechanicsToGlobalList(mechanicsForRandom, _triggerMechanics);
        AddMechanicsToGlobalList(mechanicsForRandom, _mentalMechanics);

        if (useCombinedMechanics)
        {
            AddMechanicsToGlobalList(mechanicsForRandom, _combinedMechanics);
        }
        
        _firstResultMechanic = RandomizeMechanic(mechanicsForRandom);
        ShowRandomResult(_firstResultMechanic, _firstMechanicIcon, _firstMechanicName, out _firstInfoScreenName);
        _secondResultMechanic = RandomizeMechanic(mechanicsForRandom);
        ShowRandomResult(_secondResultMechanic, _secondMechanicIcon, _secondMechanicName, out _secondInfoScreenName);
        _thirdResultMechanic = RandomizeMechanic(mechanicsForRandom);
        ShowRandomResult(_thirdResultMechanic, _thirdMechanicIcon, _thirdMechanicName, out _thirdInfoScreenName);
    }

    private GameMechanic RandomizeMechanic(List<GameMechanic> list)
    {
        GameMechanic mechanic = list[Random.Range(0, list.Count)];
        list.Remove(mechanic);

        return mechanic;
    }

    private void ShowRandomResult(GameMechanic mechanic, Image icon, TextMeshProUGUI name, out string infoScreenName)
    {
        icon.sprite = mechanic.Icon;
        name.text = mechanic.Name;
        icon.color = mechanic.Color;
        name.color = mechanic.Color;
        infoScreenName = mechanic.NameOfInfoScreen;
        //infoScreen.NameOfSpecialTargetScreen = mechanic.NameOfInfoScreen;
    }

    private void AddMechanicsToGlobalList(List<GameMechanic> globalList, List<GameMechanic> sourceList)
    {
        foreach (var mechanic in sourceList)
        {
            globalList.Add(mechanic);
        }
    }

    private void TuneAboutButtonOnRandomResult()
    {
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
    }
}
