using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 4];
    public float coins;
    public TextMeshProUGUI CoinsTxt;
    public CanvasManagerScript canvasManager; // Reference to CanvasManagerScript
    public GameObject inventoryCanvas; // Reference to the inventory canvas
    public RectTransform[] inventorySlots; // Array of slot references
    private bool[] slotsOccupied; // Track slot occupancy

    public event Action OnShopItemChanged; // Event for item change

    void Start()
    {
        if (CoinsTxt == null)
        {
            Debug.LogError("CoinsTxt is not assigned in the Inspector.");
            return;
        }

        CoinsTxt.text = "Coins: $" + coins;

        // Initialize shop items
        shopItems[0, 0] = 1;
        shopItems[0, 1] = 2;
        shopItems[0, 2] = 3;
        shopItems[0, 3] = 4;

        shopItems[1, 0] = 2;
        shopItems[1, 1] = 5;
        shopItems[1, 2] = 9;
        shopItems[1, 3] = 12;

        shopItems[2, 0] = 0;
        shopItems[2, 1] = 0;
        shopItems[2, 2] = 0;
        shopItems[2, 3] = 0;

        // Initialize slot occupancy tracking
        slotsOccupied = new bool[inventorySlots.Length];
    }

    public void Buy()
    {
        // Check if there is any available slot
        bool hasAvailableSlot = false;
        foreach (bool slot in slotsOccupied)
        {
            if (!slot)
            {
                hasAvailableSlot = true;
                break;
            }
        }

        if (!hasAvailableSlot)
        {
            Debug.Log("No available slots. Cannot purchase more items.");
            return; // Exit the method if no slots are available
        }

        GameObject ButtonRef = EventSystem.current.currentSelectedGameObject;

        if (ButtonRef != null)
        {
            ButtonInfo buttonInfo = ButtonRef.GetComponent<ButtonInfo>();

            if (buttonInfo != null && coins >= shopItems[1, buttonInfo.ItemID - 1])
            {
                coins -= shopItems[1, buttonInfo.ItemID - 1];
                shopItems[2, buttonInfo.ItemID - 1]++;

                CoinsTxt.text = "Coins: $" + coins; // Ensure consistent text update
                buttonInfo.QuantityTxt.text = shopItems[2, buttonInfo.ItemID - 1].ToString();

                OnShopItemChanged?.Invoke(); // Trigger event

                // Spawn the item image in the next available slot
                SpawnItemImage(buttonInfo.ItemID, buttonInfo.ItemImagePrefab);
            }
        }
    }
    private void SpawnItemImage(int itemID, GameObject itemImagePrefab)
    {
        if (itemImagePrefab != null && inventoryCanvas != null)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (!slotsOccupied[i])
                {
                    GameObject itemImage = Instantiate(itemImagePrefab, inventoryCanvas.transform);
                    RectTransform itemRectTransform = itemImage.GetComponent<RectTransform>();
                    if (itemRectTransform != null)
                    {
                        // Set the position of the item image to the corresponding slot position
                        itemRectTransform.anchoredPosition = inventorySlots[i].anchoredPosition;

                        // Set the desired scale of the item image
                        itemRectTransform.localScale = new Vector3(5, 5, 5);

                        // Mark the slot as occupied
                        slotsOccupied[i] = true;

                        // Optionally: Store the item image in the slot for later reference
                        break;
                    }
                    else
                    {
                        Debug.LogError("The instantiated item image does not have a RectTransform component.");
                    }
                }
            }
        }
        else
        {
            Debug.LogError("ItemImagePrefab or InventoryCanvas is not assigned.");
        }
    }


    public void OnBackpackAndChestButton()
    {
        if (canvasManager != null)
        {
            canvasManager.ShowInventory();
        }
        else
        {
            Debug.LogError("CanvasManager is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        // Optional: If you have any update logic
    }
}
