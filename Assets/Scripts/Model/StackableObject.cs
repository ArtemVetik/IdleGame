using UnityEngine;

namespace Agava.IdleGame.Model
{
    public class StackableObject
    {
        public readonly Transform View;
        public readonly int Layer;

        public StackableObject(Transform view, int layer)
        {
            View = view;
            Layer = layer;
        }
    }
}