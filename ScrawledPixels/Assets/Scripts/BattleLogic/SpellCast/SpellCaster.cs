using System.Collections.Generic;
using UnityEngine;
using ScrawledPixels.InputSystem;
using ScrawledPixels.OdinSerializer;

namespace ScrawledPixels.BattleLogic.SpellCast
{
     public class SpellCaster : SerializedMonoBehaviour
     {
          private InputPointManager _inputPointManager;
          [SerializeField] private SpellData castedSpell;

          private void Awake()
          {
               _inputPointManager = GetComponentInChildren<InputPointManager>();
               _inputPointManager.onFinishInput.AddListener(() => CastSpell(_inputPointManager.GetKey()));
          }

          private void CastSpell(string key)
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
