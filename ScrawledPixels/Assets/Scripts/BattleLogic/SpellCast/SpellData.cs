using System.Collections.Generic;
using ScrawledPixels.BattleLogic.TargetTypes;
using UnityEngine;

namespace ScrawledPixels.BattleLogic.SpellCast
{
    [CreateAssetMenu(fileName = "New SpellData", menuName = "Spell", order = 51)]
    public class SpellData : ScriptableObject
    {
        [Range(1, 5)] [SerializeField] private int _castCount = 1;
        [SerializeField] private int _id;
        [SerializeField] private string _name;
        
        public List<SpellAction> Actions => _actions;
        [SerializeField] private List<SpellAction> _actions;
        [SerializeField] private List<int> _lol;
        public ITargetType TargetType => _targetType;
        [SerializeField] private ITargetType _targetType;
        public string Key => _key;
        [SerializeField] private string _key;
        
        public bool IsAble => _isAble;
        [SerializeField] private bool _isAble;
    }
}
