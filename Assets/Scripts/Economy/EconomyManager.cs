using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Collections.Generic;
using Unity.Services.Economy.Model;
using Unity.Services.Economy;
using UnityEngine.Events;

public class EconomyManager : MonoBehaviour
{
    public UnityEvent OnUpdated;

    public static EconomyManager Instance { get; private set; }

    public List<VirtualPurchaseDefinition> VirtualPurchases { get; private set; } = new();

    private void Awake()
    {
        Instance = this;
    }

    public async void Refresh()
    {
        VirtualPurchases = await EconomyService.Instance.Configuration.GetVirtualPurchasesAsync();

        OnUpdated?.Invoke();

        Debug.Log("Economy loaded");
    }
}