/*
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


}

*/
/*
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 4];
    public float coins;
    public TextMeshProUGUI CoinsTxt;
    public CanvasManagerScript canvasManager;
    public GameObject inventoryCanvas;
    public RectTransform[] inventorySlots;
    private bool[] slotsOccupied;

    public event Action OnShopItemChanged;

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

    public void Buy(ButtonInfo buttonInfo)
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
            return;
        }

        if (coins >= shopItems[1, buttonInfo.ItemID - 1])
        {
            coins -= shopItems[1, buttonInfo.ItemID - 1];
            shopItems[2, buttonInfo.ItemID - 1]++;

            CoinsTxt.text = "Coins: $" + coins;
            buttonInfo.QuantityTxt.text = shopItems[2, buttonInfo.ItemID - 1].ToString();

            OnShopItemChanged?.Invoke();

            SpawnItemImage(buttonInfo.ItemID, buttonInfo.ItemImagePrefab);
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
                        itemRectTransform.anchoredPosition = inventorySlots[i].anchoredPosition;
                        itemRectTransform.localScale = new Vector3(5, 5, 5);
                        slotsOccupied[i] = true;

                        ItemImage itemImageScript = itemImage.GetComponent<ItemImage>();
                        if (itemImageScript != null)
                        {
                            itemImageScript.ItemID = itemID;
                            Debug.Log("Item image instantiated with ID: " + itemID);
                        }
                        else
                        {
                            Debug.LogError("The instantiated item image does not have an ItemImage component.");
                        }

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



    public void SellItem(ButtonInfo buttonInfo)
    {
        if (shopItems[2, buttonInfo.ItemID - 1] > 0)
        {
            coins += shopItems[1, buttonInfo.ItemID - 1];
            shopItems[2, buttonInfo.ItemID - 1]--;
            CoinsTxt.text = "Coins: $" + coins;
            buttonInfo.QuantityTxt.text = shopItems[2, buttonInfo.ItemID - 1].ToString();

            Debug.Log("Selling item with ID: " + buttonInfo.ItemID);

            // Destroy the item prefab
            RemoveItemImage(buttonInfo.ItemID);

            OnShopItemChanged?.Invoke();
        }
        else
        {
            Debug.Log("Cannot sell this item because it's not in inventory.");
        }
    }

    public void RemoveItemImage(int itemID)
    {
        Debug.Log("Attempting to remove item with ID: " + itemID);
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (slotsOccupied[i])
            {
                ItemImage[] itemImages = inventorySlots[i].GetComponentsInChildren<ItemImage>();
                Debug.Log("Slot " + i + " contains " + itemImages.Length + " item images.");
                foreach (ItemImage itemImage in itemImages)
                {
                    Debug.Log("Checking item with ID: " + itemImage.ItemID);
                    if (itemImage.ItemID == itemID)
                    {
                        Debug.Log("Found and destroying item prefab with ItemID: " + itemImage.ItemID);
                        Destroy(itemImage.gameObject);
                        slotsOccupied[i] = false;
                        return; // Exit the method once the item is found and removed
                    }
                }
            }
        }
        Debug.Log("No item with ID: " + itemID + " found to remove.");
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
}
*/

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

    public void Buy(ButtonInfo buttonInfo)
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

    public void SellItem(ButtonInfo buttonInfo)
    {
        if (buttonInfo != null && shopItems[2, buttonInfo.ItemID - 1] > 0)
        {
            shopItems[2, buttonInfo.ItemID - 1]--;
            coins += shopItems[1, buttonInfo.ItemID - 1] / 2; // sell for half the price

            CoinsTxt.text = "Coins: $" + coins; // Ensure consistent text update
            buttonInfo.QuantityTxt.text = shopItems[2, buttonInfo.ItemID - 1].ToString();

            OnShopItemChanged?.Invoke(); // Trigger event

            // Remove the item image from the inventory
            RemoveItemImage(buttonInfo.ItemID);
        }
        else
        {
            Debug.Log("Cannot sell this item because it's not in inventory.");
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
                        itemRectTransform.anchoredPosition = inventorySlots[i].anchoredPosition;
                        itemRectTransform.localScale = new Vector3(5, 5, 5);
                        slotsOccupied[i] = true;

                        ItemImage itemImageScript = itemImage.GetComponent<ItemImage>();
                        if (itemImageScript != null)
                        {
                            itemImageScript.ItemID = itemID;
                            itemImageScript.SlotIndex = i;
                            Debug.Log("Item image instantiated with ID: " + itemID + " in slot " + i);
                        }
                        else
                        {
                            Debug.LogError("The instantiated item image does not have an ItemImage component.");
                        }

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

    public void RemoveItemImage(int itemID)
    {
        Debug.Log("Attempting to remove item with ID: " + itemID);
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (slotsOccupied[i])
            {
                ItemImage[] itemImages = inventorySlots[i].GetComponentsInChildren<ItemImage>();
                Debug.Log("Slot " + i + " contains " + itemImages.Length + " item images.");
                foreach (ItemImage itemImage in itemImages)
                {
                    Debug.Log("Checking item with ID: " + itemImage.ItemID + " in slot " + i);
                    if (itemImage.ItemID == itemID)
                    {
                        Debug.Log("Found and destroying item prefab with ItemID: " + itemImage.ItemID + " in slot " + i);
                        Destroy(itemImage.gameObject); // Destroy the entire game object
                        slotsOccupied[i] = false; // Mark the slot as unoccupied
                        return; // Exit the method once the item is found and removed
                    }
                }
                // If the loop doesn't return, no matching item found in this slot, so mark it as unoccupied
                slotsOccupied[i] = false;
            }
        }
        Debug.Log("No item with ID: " + itemID + " found to remove.");
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
}

