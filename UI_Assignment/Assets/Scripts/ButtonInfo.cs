using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;
    public GameObject ItemImagePrefab; // Reference to the item image prefab

    private ShopManagerScript shopManagerScript;

    void Start()
    {
        if (ShopManager != null)
        {
            shopManagerScript = ShopManager.GetComponent<ShopManagerScript>();
        }

        if (shopManagerScript != null)
        {
            shopManagerScript.OnShopItemChanged += UpdateTextFields; // Subscribe to event
        }

        UpdateTextFields();
    }

    void OnDestroy()
    {
        if (shopManagerScript != null)
        {
            shopManagerScript.OnShopItemChanged -= UpdateTextFields; // Unsubscribe from event
        }
    }

    private void UpdateTextFields()
    {
        PriceTxt.text = "Price: $" + shopManagerScript.shopItems[1, ItemID - 1].ToString();
        QuantityTxt.text = shopManagerScript.shopItems[2, ItemID - 1].ToString();
    }
}
