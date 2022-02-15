using UnityEngine;
using UnityEngine.InputSystem;

namespace ScrawledPixels.InputSystem
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private GameObject _onlooker;
        [SerializeField] private Camera _mainCamera;

        private Vector3 _lookDirection;
        private Vector3 _cursorPosition;

        public void OnMouseLook(InputAction.CallbackContext context)
        {
            _cursorPosition = context.ReadValue<Vector2>();
            _cursorPosition = _mainCamera.ScreenToWorldPoint(_cursorPosition);
            Vector3 vectorToCursor = _cursorPosition - transform.position;
            Vector3 rotatedVectorToCursor = Quaternion.Euler(0, 0, 90) * vectorToCursor;
            _onlooker.transform.rotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToCursor);
        }
    }
}
