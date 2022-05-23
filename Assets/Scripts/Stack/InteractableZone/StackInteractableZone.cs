using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public abstract class StackInteractableZone : MonoBehaviour
    {
        [SerializeField] private float _interactionTime = 0.1f;
        [SerializeField] private Trigger<StackPresenter> _trigger;

        private Timer _timer = new Timer();
        private StackPresenter _enteredStack;
        private Coroutine _waitCoroutine;

        public ITimer Timer => _timer;
        protected virtual float InteracionTime => _interactionTime;

        private void OnValidate()
        {
            _interactionTime = Mathf.Clamp(_interactionTime, 0.01f, float.MaxValue);
        }

        private void OnEnable()
        {
            _trigger.Enter += OnEnter;
            _trigger.Stay += OnStay;
            _trigger.Exit += OnExit;
            _timer.Completed += OnTimeOver;
        }

        private void OnDisable()
        {
            _trigger.Enter -= OnEnter;
            _trigger.Stay -= OnStay;
            _trigger.Exit -= OnExit;
            _timer.Completed -= OnTimeOver;
        }

        private void Update()
        {
            _timer.Tick(Time.deltaTime);
        }

        private void OnEnter(StackPresenter enteredStack)
        {
            if (_enteredStack != null)
                return;

            _enteredStack = enteredStack;

            if (CanInteract(enteredStack))
                _timer.Start(InteracionTime);
            else
                _waitCoroutine = StartCoroutine(WaitUntilCanInteract(() => _timer.Start(InteracionTime)));
        }

        private void OnStay(StackPresenter enteredStack)
        {
            if (_enteredStack == null)
                OnEnter(enteredStack);
        }

        private void OnExit(StackPresenter otherStack)
        {
            if (otherStack == _enteredStack)
            {
                if (_waitCoroutine != null)
                    StopCoroutine(_waitCoroutine);

                _timer.Stop();
                _enteredStack = null;
            }
        }

        private void OnTimeOver()
        {
            InteractAction(_enteredStack);
            _waitCoroutine = StartCoroutine(WaitUntilCanInteract(() => _timer.Start(InteracionTime)));
        }

        private IEnumerator WaitUntilCanInteract(UnityAction finalAction)
        {
            yield return null;
            yield return new WaitUntil(() => CanInteract(_enteredStack));
            finalAction?.Invoke();
        }

        protected abstract void InteractAction(StackPresenter enteredStack);
        protected abstract bool CanInteract(StackPresenter enteredStack);
    }
}