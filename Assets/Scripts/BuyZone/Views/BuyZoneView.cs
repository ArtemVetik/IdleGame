using UnityEngine;
using TMPro;

public class BuyZoneView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentCost;

    public void RenderCost(int value)
    {
        _currentCost.text = value.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
