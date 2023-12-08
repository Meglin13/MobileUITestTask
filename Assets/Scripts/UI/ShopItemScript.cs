using System.IO;
using TMPro;
using Unity.Services.Economy.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour
{
    private VirtualPurchaseDefinition item;

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

    public void SetItem(VirtualPurchaseDefinition item)
    {
        this.item = item;

        price.text = item.Costs[0].Amount.ToString();

        text.text = item.CustomData["ItemName"].ToString();

        var level = item.CustomData["LevelRequired"].ToString();

        if (int.Parse(level) < LevelManager.CurrentLevel)
        {
            levelText.gameObject.SetActive(true);
            levelText.text = $"LV. {level}";
            buyButton.interactable = false;
        }
        else
        {
            levelText.gameObject.SetActive(false);
            buyButton.interactable = true;

            var path = item.CustomData["LevelRequired"].ToString();

            if (path != string.Empty)
            {
                icon.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            }
        }

        //TODO: Обозначение купленной покупки
        //if (true)
        //{
        //    buyIcon.SetActive(false);
        //    purchasedIcon.SetActive(true);
        //}
        //else
        //{
        buyIcon.SetActive(true);
        purchasedIcon.SetActive(false);
        //}
    }

    public void BuyButtonClick()
    {
        
    }
}
