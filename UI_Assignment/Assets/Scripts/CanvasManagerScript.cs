using UnityEngine;

public class CanvasManagerScript : MonoBehaviour
{
    public GameObject shopCanvas;
    public GameObject inventoryCanvas;

    // Method to switch to the Inventory canvas
    public void ShowInventory()
    {
        shopCanvas.SetActive(false);
        inventoryCanvas.SetActive(true);
    }

    // Method to switch back to the Shop canvas (if needed)
    public void ShowShop()
    {
        shopCanvas.SetActive(true);
        inventoryCanvas.SetActive(false);
    }
}
