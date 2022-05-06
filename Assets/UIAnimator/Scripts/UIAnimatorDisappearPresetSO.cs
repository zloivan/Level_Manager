using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace UIAnimator
{
    public abstract class UIAnimatorPresetSO : ScriptableObject
    {
        public abstract UniTask PlayShowAnimationAsync(RectTransform rectTransform, float duration);

        public abstract UniTask PlayHideAnimationAsync(RectTransform rectTransform, float duration);
    }

    [CreateAssetMenu(menuName = "UIAnimator/Presets/DisappearPreset", fileName = "DisappearPreset", order = 0)]
    internal class UIAnimatorDisappearPresetSO : UIAnimatorPresetSO
    {
        public override UniTask PlayShowAnimationAsync(RectTransform rectTransform, float duration)
        {
            if (rectTransform.gameObject == null)
            {
                return UniTask.CompletedTask;
            }

            var cg = rectTransform.gameObject.TryGetComponent<CanvasGroup>(out var group);

            if (cg == false)
            {
                group = rectTransform.gameObject.AddComponent<CanvasGroup>();
            }


            return UniTask.WhenAll(group.DOFade(1f, duration).From(0f)
                .ToUniTask(cancellationToken: rectTransform.gameObject.GetCancellationTokenOnDestroy()));
        }

        public override UniTask PlayHideAnimationAsync(RectTransform rectTransform, float duration)
        {
            if (rectTransform.gameObject == null)
            {
                return UniTask.CompletedTask;
            }

            var cg = rectTransform.gameObject.TryGetComponent<CanvasGroup>(out var group);

            if (cg == false)
            {
                group = rectTransform.gameObject.AddComponent<CanvasGroup>();
            }


            return group.DOFade(0f, duration).From(1f)
                .ToUniTask(cancellationToken: rectTransform.gameObject.GetCancellationTokenOnDestroy());
        }
    }
}