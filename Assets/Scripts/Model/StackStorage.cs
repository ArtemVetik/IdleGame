using System;
using System.Linq;
using System.Collections.Generic;

namespace Agava.IdleGame.Model
{
    public class StackStorage
    {
        private readonly List<StackableObject> _data = new List<StackableObject>();
        private readonly int _capacity;
        private readonly StackableLayerMask _stackableTypes;

        public int Count => _data.Count;
        public int Capacity => _capacity;
        public IEnumerable<StackableObject> Data => _data;

        public StackStorage(int capacity, StackableLayerMask stackableTypes)
        {
            _capacity = capacity;
            _stackableTypes = stackableTypes;

            _data = new List<StackableObject>(capacity);
        }

        public event Action<StackableObject> Added;
        public event Action<StackableObject> Removed;

        public void Add(StackableObject stackable)
        {
            if (CanAdd(stackable.Layer) == false)
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
            if (index < 0 || index >= _data.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var stackable = _data[index];

            _data.RemoveAt(index);
            Removed?.Invoke(stackable);

            return stackable;
        }

        public bool CanAdd(int layer)
        {
            return _data.Count < _capacity && 
                ((_stackableTypes.Value & (1 << layer)) == (1 << layer));
        }

        public bool Contains(StackableObject stackableObject)
        {
            return _data.Contains(stackableObject);
        }

        public bool Contains(int layer)
        {
            return _data.Any(stackable => stackable.Layer == layer);
        }
    }
}