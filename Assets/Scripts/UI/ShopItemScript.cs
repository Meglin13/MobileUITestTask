using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject PurchasedIcon;

    public void SetItem(ShopItem item)
    {
        this.item = item;

        if (item.LevelRequired < LevelManager.CurrentLevel)
        {
            levelText.gameObject.SetActive(true);
            levelText.text = $"LV. {item.LevelRequired}";
            buyButton.interactable = false;
        }
        else
        {
            levelText.gameObject.SetActive(false);
            icon.sprite = item.Icon;
            buyButton.interactable = true;
        }
    }

    public void BuyButtonClick()
    {

    }
}
