using UnityEngine;

namespace Agava.IdleGame
{
    public class ObjectConsumerZone : StackInteractableZone
    {
        [SerializeField] private StackPresenter _selfStack;

        protected override bool CanInteract(StackPresenter enteredStack)
        {
            return _selfStack.CanAddToStack() && enteredStack.Count > 0;
        }

        protected override void InteractAction(StackPresenter enteredStack)
        {
            var stackable = enteredStack.RemoveAt(0);
            _selfStack.AddToStack(stackable);
        }
    }
}