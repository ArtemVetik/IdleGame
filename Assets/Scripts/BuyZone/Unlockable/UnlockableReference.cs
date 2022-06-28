using UnityEngine;
using UnityEngine.Events;

namespace Agava.IdleGame
{
    public class UnlockableReference : UnlockableObject
    {
        [SerializeField] private MonoBehaviour _template;

        public event UnityAction<MonoBehaviour, bool, string> Unlocked;

        public override GameObject Unlock(Transform parent, bool onLoad, string guid)
        {
            var inst = Instantiate(_template, parent);
            Unlocked?.Invoke(inst, onLoad, guid);

            return inst.gameObject;
        }
    }
}