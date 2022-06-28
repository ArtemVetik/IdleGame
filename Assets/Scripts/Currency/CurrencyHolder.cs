using Agava.IdleGame.Model;
using UnityEngine;
using UnityEngine.Events;

namespace Agava.IdleGame
{
    public abstract class CurrencyHolder : MonoBehaviour
    {
        private Currency _currency;

        public event UnityAction<int> BalanceChanged;

        protected abstract Currency InitCurrency();

        public int Value => _currency.Value;
        public bool HasMoney => _currency.Value > 0;

        private void OnEnable()
        {
            _currency = InitCurrency();
            _currency.Load();
            _currency.Changed += OnBalanceChanged;
        }

        private void OnDisable()
        {
            _currency.Changed -= OnBalanceChanged;
            _currency.Save();
        }

        public void Add(int value)
        {
            _currency.Add(value);
        }

        public void Spend(int value)
        {
            _currency.Spend(value);
        }

        private void OnBalanceChanged()
        {
            BalanceChanged?.Invoke(_currency.Value);
            _currency.Save();
        }
    }
}