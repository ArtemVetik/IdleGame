using System;
using System.Collections.Generic;

namespace Agava.IdleGame.Model
{
    public class StackStorage
    {
        private readonly List<StackableObject> _data = new List<StackableObject>();
        private readonly int _capacity;

        public int Count => _data.Count;
        public int Capacity => _capacity;

        public StackStorage(int capacity)
        {
            _capacity = capacity;
            _data = new List<StackableObject>(capacity);
        }

        public event Action<StackableObject> Added;
        public event Action<StackableObject> Removed;

        public void Add(StackableObject stackable)
        {
            if (CanAdd() == false)
                throw new InvalidOperationException(nameof(stackable) + " can't be added");
            
            _data.Add(stackable);
            Added?.Invoke(stackable);
        }

        public void Remove(StackableObject stackable)
        {
            if (_data.Contains(stackable) == false)
                throw new InvalidOperationException(nameof(stackable) + " not in stack");

            _data.Remove(stackable);
            Removed?.Invoke(stackable);
        }

        public StackableObject RemoveAt(int index)
        {
            var stackable = _data[index];

            _data.RemoveAt(index);
            Removed?.Invoke(stackable);

            return stackable;
        }

        public bool CanAdd()
        {
            return _data.Count < _capacity;
        }

        public bool Contains(StackableObject stackableObject)
        {
            return _data.Contains(stackableObject);
        }
    }
}