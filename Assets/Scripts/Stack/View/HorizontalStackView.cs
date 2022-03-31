using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class HorizontalStackView : StackView
    {
        [SerializeField] private float _space = 0.05f;

        private void OnValidate()
        {
            _space = Mathf.Clamp(_space, 0f, float.MaxValue);
        }

        protected override Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
        {
            return Vector3.right * container.childCount * (stackable.lossyScale.x + _space);
        }

        protected override void Sort(IEnumerable<StackableObject> unsortedStackables, float animationDuration)
        {
            var sortedList = unsortedStackables.OrderBy(stackable => stackable.View.localPosition.x);

            var iteration = 0;
            foreach (var item in sortedList)
            {
                var position = Vector3.right * iteration * (item.View.lossyScale.x + _space);

                item.View.DOComplete(true);
                item.View.DOLocalMove(position, animationDuration);

                iteration++;
            }
        }
    }
}