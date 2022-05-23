using UnityEngine;
using UnityEngine.Events;
using Agava.IdleGame.Model;
using System;
using System.Collections.Generic;

namespace Agava.IdleGame
{
    public class StackPresenter : MonoBehaviour
    {
        [SerializeField] private StackView _view;
        [SerializeField] private int _capacity;
        [SerializeField] public StackableLayerMask _stackableTypes;

        private StackStorage _stack;

        public event UnityAction<StackableObject> Added;
        public event UnityAction<StackableObject> Removed;

        public int Count => _stack.Count;
        public int Capacity => _capacity;
        public IEnumerable<StackableObject> Data => _stack.Data;

        private void OnValidate()
        {
            _capacity = Mathf.Clamp(_capacity, 0, int.MaxValue);
        }

        private void Awake()
        {
            _stack = new StackStorage(_capacity, _stackableTypes);
        }

        public bool CanAddToStack(int layer)
        {
            return _stack.CanAdd(layer);
        }

        public bool CanRemoveFromStack(StackableObject stackable)
        {
            return _stack.Contains(stackable);
        }

        public bool CanRemoveFromStack(int layer)
        {
            return _stack.Contains(layer);
        }

        public void AddToStack(StackableObject stackable)
        {
            if (CanAddToStack(stackable.Layer) == false)
                throw new InvalidOperationException();

            _stack.Add(stackable);
            _view.Add(stackable, () => Added?.Invoke(stackable));
        }

        public StackableObject RemoveAt(int index)
        {
            var stackable = _stack.RemoveAt(index);
            _view.Remove(stackable);

            Removed?.Invoke(stackable);
            return stackable;
        }

        public void RemoveFromStack(StackableObject stackable)
        {
            _stack.Remove(stackable);
            _view.Remove(stackable);

            Removed?.Invoke(stackable);
        }
    }
}