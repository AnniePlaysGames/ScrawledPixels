using System;
using System.Collections.Generic;
using UnityEngine;
using ScrawledPixels.InputSystem;
using ScrawledPixels.OdinSerializer;

namespace ScrawledPixels.BattleLogic.SpellCast
{
     public class SpellCaster : MonoBehaviour
     {
          [SerializeField] private SpellData castedSpell;

          public void CastSpell(string key)
          {
               if (key == castedSpell.Key)
               {
                    foreach (var action in castedSpell.Actions)
                    {
                         GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
                         action.DoAction(targets[0].GetComponent<EnemyFighter>());
                    }
               }
          }
     }
}
