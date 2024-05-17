/*
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Transform originalParent;
    private Vector2 originalPosition;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
        transform.SetParent(originalParent.parent); // Set parent to canvas to avoid clipping
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvasGroup.transform.localScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        // Implement logic to check if dropped in a valid slot
        if (!DropItemInSlot(eventData))
        {
            // If not dropped in a valid slot, return to original position
            rectTransform.anchoredPosition = originalPosition;
            transform.SetParent(originalParent);
        }
    }

    private bool DropItemInSlot(PointerEventData eventData)
    {
        GameObject dropTarget = eventData.pointerCurrentRaycast.gameObject;
        if (dropTarget != null && dropTarget.CompareTag("Slot"))
        {
            RectTransform slotRectTransform = dropTarget.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = slotRectTransform.anchoredPosition;
            transform.SetParent(dropTarget.transform);
            return true;
        }
        return false;
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
}