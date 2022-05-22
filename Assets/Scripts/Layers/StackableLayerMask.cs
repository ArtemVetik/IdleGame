using System;
using UnityEngine;

namespace Agava.IdleGame
{
    [Serializable]
    public struct StackableLayerMask
    {
        private static StackableLayers _layersAsset = StackableLayers.GetAsset();

        [SerializeField] private int _value;

        public int Value => _value;
        public static string[] Layers => _layersAsset.Layers;

        public static string LayerToName(int layer)
        {
            return _layersAsset.LayerToName(layer);
        }

        public static int NameToLayer(string name)
        {
            return _layersAsset.NameToLayer(name);
        }
    }
}