using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    private int ticketsBalance;

    public int TicketsBalance
    {
        get => ticketsBalance;
        set
        {
            ticketsBalance = value;
            OnBalanceChanged?.Invoke();
        }
    }

    public UnityEvent OnBalanceChanged;

    void Start()
    {
        
    }
}
