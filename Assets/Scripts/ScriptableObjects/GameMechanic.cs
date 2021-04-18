using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mechanic", menuName = "Create New Mechanic", order = 51)]
public class GameMechanic : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;  
    [Tooltip("Dimensional — (242, 110, 222)\nTrigger — (98, 141, 250)\nMental — (92, 221, 231)\nCombined — (233, 147, 87)")]
    [SerializeField] private Color _color;

    public string Name => _name;
    public Sprite Icon => _icon;
    public Color Color => _color;
}

