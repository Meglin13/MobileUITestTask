using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem
{
    public string ID;
    public string Name;
    public int LevelRequired;
    public Sprite Icon;
    public List<PurchaseItemQuantity> Rewards;
    public List<PurchaseItemQuantity> Costs;
    public bool OneTimePurchase = true;
}

public class ShopItemScript : MonoBehaviour
{
    private ShopItem item;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private TextMeshProUGUI price;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private GameObject buyIcon;

    [SerializeField]
    private GameObject purchasedIcon;

    private bool isPurchased;

    public void SetItem(ShopItem item)
    {
        this.item = item;

        price.text = item.Costs[0].Amount.ToString();

        text.text = item.Name;
        
        //TODO: Разблокировка по уровню
        if (item.LevelRequired > LevelManager.Instance.CurrentLevel)
        {
            levelText.gameObject.SetActive(true);
            levelText.text = $"LV. {item.LevelRequired}";
            buyButton.interactable = false;
        }
        else
        {
            levelText.gameObject.SetActive(false);
            buyButton.interactable = true;

            if (item.Icon != null)
            {
                icon.sprite = item.Icon;
            }
        }

        var reward = item.Rewards.FirstOrDefault()?.Item.GetReferencedConfigurationItem()?.Id;

        if (item.OneTimePurchase & EconomyManager.Instance.PlayerInventory.Where(x => x.InventoryItemId == reward).FirstOrDefault() != null)
        {
            isPurchased = true;
            buyIcon.SetActive(false);
            purchasedIcon.SetActive(true);
        }
        else
        {
            buyIcon.SetActive(true);
            purchasedIcon.SetActive(false);
        }
    }

    public async void BuyButtonClick()
    {
        if (item != null)
        {
            if (isPurchased || item.LevelRequired > LevelManager.Instance.CurrentLevel)
            {
                return;
            }

            await EconomyService.Instance.Purchases.MakeVirtualPurchaseAsync(item.ID);
        }

        EconomyManager.Instance.Refresh();
    }
}