using System;
using System.Collections.Generic;
using ScrawledPixels.BattleLogic.SpellCast;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScrawledPixels.InputSystem
{
    public class InputPointManager : MonoBehaviour
    {
        private InputPoint[] _points;
        private List<InputPoint> _activePoints;
        [SerializeField] private Text _result;
        private SpellCaster _spellCaster;
        private TouchDetection _touchDetection;

        private void Awake()
        {
            _touchDetection = GetComponent<TouchDetection>();
            _touchDetection.OnEndTouch += FinishInput;
            _activePoints = new List<InputPoint>();
            _points = GetComponentsInChildren<InputPoint>();
            _spellCaster = GetComponentInParent<SpellCaster>();

            for (int i = 0; i < _points.Length; i++)
            {
                _points[i].Id = i;
            }

            foreach (var point in _points)
            {
                point.onPointerEnter.AddListener(() => ActivatePoint(point));
            }
        }

        private void OnDisable()
        {
            foreach (var point in _points)
            {
                point.onPointerEnter.RemoveListener(() => ActivatePoint(point));
            }
        }

        private void ActivatePoint(InputPoint point)
        {
            if (point.IsActivated == false)
            {
                Debug.Log(point.Id + " is active!");
                point.IsActivated = true;
                _activePoints.Add(point);
            }
        }

        private void FinishInput()
        {
            Debug.Log("Finish input");
            _spellCaster.CastSpell(GetKey());
        }

        private string GetKey()
        { 
            string key = "";
            foreach (var point in _activePoints)
            {
                key += point.Id;
                point.Deactivate();
            }
            
            Debug.Log($"SpellKey is {key}");
            _activePoints.Clear();
            return key;
        }
    }
}
