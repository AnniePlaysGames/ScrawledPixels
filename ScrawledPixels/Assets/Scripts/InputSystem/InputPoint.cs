using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScrawledPixels.InputSystem
{
    public class InputPoint : Button
    {
        public UnityEvent onPointerEnter;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private int _id;

        public bool IsActivated
        {
            get => _isActivated;
            set => _isActivated = value;
        }

        private bool _isActivated;

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            onPointerEnter.Invoke();
        }

        public void Deactivate()
        {
            _isActivated = false;
        }
    }
}
