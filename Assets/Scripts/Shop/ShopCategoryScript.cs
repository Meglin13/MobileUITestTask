using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public enum ShopItemCategory
{
    Tickets, Skin, Location
}

public class ShopCategoryScript : MonoBehaviour
{
    [SerializeField]
    private ShopItemCategory category;

    [SerializeField]
    private bool isRealMoney;

    [SerializeField]
    private TextMeshProUGUI categoryName;

    [SerializeField]
    private ShopItemScript prefab;

    [SerializeField]
    private Transform container;

    private List<ShopItemScript> placedItems = new();

    public void Load()
    {
        categoryName.text = category.ToString();

        var purchases = EconomyManager.Instance.VirtualPurchases;

        int index = 0;

        foreach (var purchase in purchases)
        {
            if (purchase.Name.ToLower().Contains(category.ToString().ToLower()))
            {
                var item = new ShopItem()
                {
                    ID = purchase.Id,
                    Name = purchase.CustomData["ItemName"].ToString(),
                    LevelRequired = int.Parse(purchase.CustomData["LevelRequired"].ToString()),
                    Icon = AssetDatabase.LoadAssetAtPath<Sprite>(purchase.CustomData["IconPath"].ToString()),
                    Costs = purchase.Costs,
                    Rewards = purchase.Rewards,
                    OneTimePurchase = Convert.ToBoolean(purchase.CustomData["OneTimePurchase"])
                };

                ShopItemScript shopItem = null;

                if (placedItems.Count > index)
                {
                    shopItem = placedItems[index];
                }
                else
                {
                    shopItem = Instantiate(prefab, container);
                    placedItems.Add(shopItem);
                }

                shopItem.SetItem(item);

                index++;
            }
        }
    }
}