using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPElementSetup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TextMeshProUGUI priceText;

    public void OnProductPurchased(Product product)
    {
        EconomyManager.Instance.AddCurrency(product);
    }
    
    public void OnProductFetched(Product product)
    {
        nameText.text = product.metadata.localizedTitle;
        priceText.text = product.metadata.localizedPriceString;
    }
}
