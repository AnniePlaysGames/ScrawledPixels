using UnityEngine;
using UnityEngine.InputSystem;

namespace ScrawledPixels.InputSystem
{
    public class TouchDetection : MonoBehaviour
    {
        public delegate void EndTouch();
        public event EndTouch OnEndTouch;
        private InputActions _inputActions;

        private void Awake()
        {
            _inputActions = new InputActions();
            _inputActions.Touch.IsTouching.canceled += EndTouchPrimary;
        }

        private void OnEnable()
        {
            _inputActions.Touch.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Touch.Disable();
        }

        private void EndTouchPrimary(InputAction.CallbackContext context)
        {
            OnEndTouch?.Invoke();
        }
    }
}
