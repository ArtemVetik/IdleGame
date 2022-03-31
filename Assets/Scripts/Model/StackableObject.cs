using UnityEngine;

namespace Agava.IdleGame.Model
{
    public class StackableObject
    {
        public readonly Transform View;

        public StackableObject(Transform view)
        {
            View = view;
        }
    }
}