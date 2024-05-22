
using UnityEngine;

public class CanvasManagerScript : MonoBehaviour
{
    public GameObject shopCanvas;
    public GameObject inventoryCanvas;

    
    public void ShowInventory()
    {
        shopCanvas.SetActive(false);
        inventoryCanvas.SetActive(true);
    }

    
    public void ShowShop()
    {
        shopCanvas.SetActive(true);
        inventoryCanvas.SetActive(false);
    }
}
