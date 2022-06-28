using TMPro;
using UnityEngine;

namespace Agava.IdleGame.Examples
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private SoftCurrencyHolder _holder;
        [SerializeField] private TMP_Text _currencyText;

        private void OnEnable()
        {
            _holder.BalanceChanged += OnBalanceChanged;
        }

        private void OnDisable()
        {
            _holder.BalanceChanged -= OnBalanceChanged;
        }

        private void Start()
        {
            OnBalanceChanged(_holder.Value);
        }

        private void OnBalanceChanged(int balance)
        {
            _currencyText.text = balance.ToString();
        }
    }
}