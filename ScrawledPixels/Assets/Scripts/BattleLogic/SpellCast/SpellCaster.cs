using System.Collections.Generic;
using UnityEngine;
using ScrawledPixels.InputSystem;

namespace ScrawledPixels.BattleLogic.SpellCast
{
     public class SpellCaster : MonoBehaviour
     {
          private InputPointManager _inputPointManager;
          private Dictionary<string, SpellData> _spellDictionary;

          private void Awake()
          {
               _inputPointManager = GetComponentInChildren<InputPointManager>();
               _inputPointManager.onFinishInput.AddListener(() => CastSpell(_inputPointManager.GetKey()));
          }

          private void CastSpell(string key)
          {
               _spellDictionary.TryGetValue(key, out SpellData castedSpell);
               if (castedSpell && castedSpell.IsAble)
               {
                    foreach (var action in castedSpell.Actions)
                    {
                         action.DoAction(castedSpell.TargetType.GetTarget());
                    }
               }
          }
     }
}
