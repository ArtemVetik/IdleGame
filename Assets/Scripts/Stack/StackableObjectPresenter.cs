using Agava.IdleGame.Model;
using UnityEngine;

namespace Agava.IdleGame
{
    public class StackableObjectPresenter : MonoBehaviour
    {
        private StackableObject _stackable;

        public StackableObject Stackable => _stackable;

        private void Awake()
        {
            _stackable = new StackableObject(transform);
        }
    }
}