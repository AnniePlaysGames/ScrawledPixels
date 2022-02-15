using UnityEngine;
using UnityEngine.InputSystem;
using ScrawledPixels.UI;

namespace ScrawledPixels.InputSystem
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private AnimatedWindow _window;

        public void OnMovement(InputAction.CallbackContext context)
        {
            _player.SetDirection(context.ReadValue<Vector2>());
        }

        public void OnMenuOpen(InputAction.CallbackContext context)
        {
            _window.Open();
        }
}
}
