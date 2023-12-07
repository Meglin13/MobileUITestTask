using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField]
    private ShopItemScript prefab;

    void Start()
    {
        var items = Resources.LoadAll<ShopItem>("ShopItems");

        foreach (var item in items)
        {
            var shopItem = Instantiate(prefab, transform);

            shopItem.SetItem(item);
        }
    }
}
