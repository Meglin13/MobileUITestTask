using UnityEngine;

public enum ShopItemCategory
{
    Tickets, Skins, Locations
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItems", order = 1)]
public class ShopItem : ScriptableObject
{
    [SerializeField]
    private ShopItemCategory category;
    public ShopItemCategory Category => category;

    [SerializeField]
    private string itemName;
    public string ItemName => itemName;

    [SerializeField]
    private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField]
    private int price;
    public int Price => price;

    [SerializeField]
    private int levelRequired = 0;
    public int LevelRequired => levelRequired;

}