using TMPro;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerBalance tickets;
    public PlayerBalance Tickets 
    { 
        get => tickets; 
        private set => tickets = value; 
    }

    [SerializeField]
    private TextMeshProUGUI balanceText;

    public async void GetItems()
    {
        GetBalancesResult result = await EconomyService.Instance.PlayerBalances.GetBalancesAsync();
        Tickets = result.Balances[0];

        balanceText.text = tickets.Balance.ToString();
    }
}