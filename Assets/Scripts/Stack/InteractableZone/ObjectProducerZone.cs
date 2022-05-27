using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectProducerZone : StackInteractableZone
    {
        [Header("Produced template")]
        [SerializeField] private StackableObjectPresenter _template;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return enteredStack.CanAddToStack(_template.Layer);
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            var inst = Instantiate(_template, transform.position, Quaternion.identity);
            enteredStack.AddToStack(inst.Stackable);
        }
    }
}