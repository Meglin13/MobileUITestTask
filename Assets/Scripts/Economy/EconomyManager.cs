using UnityEngine;
using System.Collections.Generic;
using Unity.Services.Economy.Model;
using Unity.Services.Economy;
using UnityEngine.Events;
using UnityEngine.Purchasing;

public class EconomyManager : MonoBehaviour
{
    public UnityEvent OnUpdated;

    public static EconomyManager Instance { get; private set; }
    public List<PlayersInventoryItem> PlayerInventory { get; private set; }

    public List<VirtualPurchaseDefinition> VirtualPurchases { get; private set; } = new();


    private void Awake()
    {
        Instance = this;
    }

    public async void Refresh()
    {
        VirtualPurchases = await EconomyService.Instance.Configuration.GetVirtualPurchasesAsync();

        var inv = await EconomyService.Instance.PlayerInventory.GetInventoryAsync();
        PlayerInventory = inv.PlayersInventoryItems;

        OnUpdated?.Invoke();

        Debug.Log("Economy loaded");
    }

    public void AddCurrency(Product product)
    {
        string name = product.definition.payout.subtype;
        int amount = int.Parse(product.definition.payout.quantity.ToString());

        AddCurrency(name, amount);
    }

    public void AddCurrency(string name, int amount)
    {
        EconomyService.Instance.PlayerBalances.IncrementBalanceAsync(name.ToUpper(), amount);
        Refresh();
    }
}