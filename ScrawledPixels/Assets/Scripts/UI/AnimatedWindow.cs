using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrawledPixels.UI
{
    public class AnimatedWindow : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int ShowKey = Animator.StringToHash("Show");
        private static readonly int HideKey = Animator.StringToHash("Hide");
        private static readonly int HiddenKey = Animator.StringToHash("Hidden");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Open()
        {
            _animator.SetTrigger(ShowKey);
        }

        public void Close()
        {
            _animator.SetTrigger(HideKey);
        }

        public void OnCloseAnimationComplete()
        {
            _animator.SetTrigger(HiddenKey);
        }
    }
}
