using System;
using System.Collections.Generic;
using UnityEngine;
using ScrawledPixels.InputSystem;
using ScrawledPixels.OdinSerializer;
using UnityEngine.PlayerLoop;

namespace ScrawledPixels.BattleLogic.SpellCast
{
     public class SpellCaster : MonoBehaviour
     {
          private Dictionary<string, SpellData> _spellDataBase;

          private void Awake()
          {
               _spellDataBase = InitSpellDatabase();
          }

          public void CastSpell(string key)
          {
               if (_spellDataBase.TryGetValue(key, out SpellData castedSpell))
               {
                    Debug.Log($"{castedSpell.Name} was casted");
                    foreach (var action in castedSpell.Actions)
                    {
                         GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
                         action.DoAction(targets[0].GetComponent<EnemyFighter>());
                    }
               }
          }

          private Dictionary<string,SpellData> InitSpellDatabase()
          {
               var spellDataBase = new Dictionary<string,SpellData>();
               SpellData[] _spellDataArray = Resources.LoadAll<SpellData>("Spells");
               for (int i = 0; i < _spellDataArray.Length; i++)
               {
                    spellDataBase.Add(_spellDataArray[i].Key,_spellDataArray[i]); 
               }

               return spellDataBase;
          }
     }
}
