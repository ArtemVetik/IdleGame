using TMPro;
using UnityEngine;
using Agava.IdleGame.Model;
using DG.Tweening;

namespace Agava.IdleGame {
    public class StackCountView : MonoBehaviour
    {
        [SerializeField] private StackPresenter _stackPresenter;
        [SerializeField] private Trigger<StackPresenter> _trigger;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _stackPresenter.Added += OnStackUpdated;
            _stackPresenter.Removed += OnStackUpdated;
            _trigger.Enter += OnEnter;
            _trigger.Exit += OnExit;
        }

        private void OnDisable()
        {
            _trigger.Enter -= OnEnter;
            _trigger.Exit -= OnExit;
        }

        private void Start()
        {
            _canvasGroup.alpha = 0f;
            UpdateText();
        }

        private void OnStackUpdated(StackableObject _)
        {
            UpdateText();
        }

        private void OnEnter(StackPresenter _)
        {
            _canvasGroup.DOFade(1f, 1f);
        }

        private void OnExit(StackPresenter _)
        {
            _canvasGroup.DOFade(0f, 1f);
        }

        private void UpdateText()
        {
            _text.text = $"{_stackPresenter.Count}/{_stackPresenter.Capacity}";
        }
    }
}