using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UIAnimator
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class UiAnimator : MonoBehaviour
    {
        [SerializeField] private UIAnimatorPresetSO _resetOrStyle;

        [SerializeField] private float _startDelay;

        [SerializeField] private float _duration;


        [ContextMenu("Play Show")]
        [Button]
        public void Show()
        {
            ShowWithTask(_duration);
        }

        [ContextMenu("Play Hide")]
        [Button]
        public void Hide()
        {
            HideWithTask(_duration);
        }


        [Button]
        public void Show(float duration)
        {
            ShowWithTask(duration);
        }

        [Button]
        public void Hide(float duration)
        {
            HideWithTask(duration);
        }

        public async UniTask ShowWithTask(float duration)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_startDelay));

            await _resetOrStyle.PlayShowAnimationAsync(gameObject.GetComponent<RectTransform>(), duration);
        }

        public async UniTask HideWithTask(float duration)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_startDelay));

            await _resetOrStyle.PlayHideAnimationAsync(gameObject.GetComponent<RectTransform>(), duration);
        }
    }
}