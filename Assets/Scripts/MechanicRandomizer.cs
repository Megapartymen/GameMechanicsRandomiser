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
    [SerializeField] private Image _secondMechanicIcon;
    [SerializeField] private TextMeshProUGUI _secondMechanicName;
    [SerializeField] private Image _thirdMechanicIcon;
    [SerializeField] private TextMeshProUGUI _thirdMechanicName;

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
        ShowRandomResult(_firstResultMechanic, _firstMechanicIcon, _firstMechanicName);
        _secondResultMechanic = RandomizeMechanic(mechanicsForRandom);
        ShowRandomResult(_secondResultMechanic, _secondMechanicIcon, _secondMechanicName);
        _thirdResultMechanic = RandomizeMechanic(mechanicsForRandom);
        ShowRandomResult(_thirdResultMechanic, _thirdMechanicIcon, _thirdMechanicName);
    }

    private GameMechanic RandomizeMechanic(List<GameMechanic> list)
    {
        GameMechanic mechanic = list[Random.Range(0, list.Count)];
        list.Remove(mechanic);

        return mechanic;
    }

    private void ShowRandomResult(GameMechanic mechanic, Image icon, TextMeshProUGUI name)
    {
        icon.sprite = mechanic.Icon;
        name.text = mechanic.Name;
        icon.color = mechanic.Color;
        name.color = mechanic.Color;
    }

    private void AddMechanicsToGlobalList(List<GameMechanic> globalList, List<GameMechanic> sourceList)
    {
        foreach (var mechanic in sourceList)
        {
            globalList.Add(mechanic);
        }
    }




    //public void RandomizeMechanic()
    //{
    //    //заполнить поля с исключениями

    //    if (_firstMechanicForExclude != null || _secondMechanicForExclude != null)
    //    {
    //        _mechanicsForRandom.Remove(_firstMechanicForExclude);
    //        _mechanicsForRandom.Remove(_secondMechanicForExclude);
    //    }

    //    _resultMechanic = _mechanicsForRandom[Random.Range(0, _mechanicsForRandom.Count)];

    //    _icon.sprite = _resultMechanic.Icon;
    //    _name.text = _resultMechanic.Name;
    //    _icon.color = _resultMechanic.Color;
    //    _name.color = _resultMechanic.Color;
    //}
}
