using TMPro;
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
    private TextMeshProUGUI categoryName;

    [SerializeField]
    private ShopItemScript prefab;

    [SerializeField]
    private Transform container;

    public void Load()
    {
        categoryName.text = category.ToString();

        foreach (var item in EconomyManager.Instance.VirtualPurchases)
        {
            if (item.Name.ToLower().Contains(category.ToString().ToLower()))
            {
                var shopItem = Instantiate(prefab, container);

                shopItem.SetItem(item); 
            }
        }
    }
}