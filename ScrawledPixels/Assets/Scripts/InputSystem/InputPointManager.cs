using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScrawledPixels.InputSystem
{
    public class InputPointManager : MonoBehaviour
    {
        public UnityEvent onFinishInput;

        private InputPoint[] _points;
        private List<InputPoint> _activePoints;
        [SerializeField] private Text _result;
        private TouchDetection _touchDetection;

        private void Awake()
        {
            _touchDetection = GetComponent<TouchDetection>();
            _touchDetection.OnEndTouch += FinishInput;
            _activePoints = new List<InputPoint>();
            _points = GetComponentsInChildren<InputPoint>();

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

        public void FinishInput()
        {
            Debug.Log("Finish");
            foreach (var point in _activePoints)
            {
                point.Deactivate();
            }
            
            onFinishInput.Invoke();
        }

        public string GetKey()
        {
            string key = "";
            foreach (var pointId in _activePoints)
            {
                key += pointId;
            }

            return key;
        }
    }
}
