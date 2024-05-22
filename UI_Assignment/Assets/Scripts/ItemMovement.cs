/*
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMovement : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Vector2 difference = Vector2.zero;
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    // Reference to the main canvas
    public Canvas mainCanvas;

    // List of GameObjects used as snap positions
    public RectTransform[] snapPositionObjects;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = mainCanvas;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        difference = eventData.position - (Vector2)rectTransform.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 newPosition = eventData.position - difference;
            rectTransform.anchoredPosition = newPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        SnapToPosition();
    }

    private void SnapToPosition()
    {
        if (snapPositionObjects == null || snapPositionObjects.Length == 0)
            return;

        float minDistance = float.MaxValue;
        RectTransform closestPosition = null;

        foreach (RectTransform snapObject in snapPositionObjects)
        {
            float distance = Vector2.Distance(rectTransform.position, snapObject.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPosition = snapObject;
            }
        }

        if (closestPosition != null)
        {
            rectTransform.anchoredPosition = closestPosition.anchoredPosition;
        }
    }
}
*/

/*
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMovement : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Vector2 difference = Vector2.zero;
    private RectTransform rectTransform;
    private bool isDragging = false;

    // List of GameObjects used as snap positions
    public RectTransform[] snapPositionObjects;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        difference = eventData.position - (Vector2)rectTransform.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 newPosition = eventData.position - difference;
            rectTransform.anchoredPosition = newPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        SnapToPosition();
    }

    private void SnapToPosition()
    {
        if (snapPositionObjects == null || snapPositionObjects.Length == 0)
            return;

        float minDistance = float.MaxValue;
        RectTransform closestPosition = null;

        foreach (RectTransform snapObject in snapPositionObjects)
        {
            float distance = Vector2.Distance(rectTransform.position, snapObject.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPosition = snapObject;
            }
        }

        if (closestPosition != null)
        {
            rectTransform.anchoredPosition = closestPosition.anchoredPosition;
        }
    }
}
*/


/*
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        // Calculate the offset between the object's position and the mouse position
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        // Update the object's position based on the mouse position and offset
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
*/



using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    // List of snap positions
    public List<Transform> snapPositionObjects;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToNearestPosition();
    }

    private void SnapToNearestPosition()
    {
        if (snapPositionObjects == null || snapPositionObjects.Count == 0)
            return;

        float minDistance = float.MaxValue;
        Transform closestSnapPosition = null;

        foreach (Transform snapPosition in snapPositionObjects)
        {
            float distance = Vector2.Distance(transform.position, snapPosition.position);
            Debug.Log("Distance to snap position: " + distance); // Add this line for debugging
            if (distance < minDistance)
            {
                minDistance = distance;
                closestSnapPosition = snapPosition;
            }
        }

        if (closestSnapPosition != null)
        {
            transform.position = closestSnapPosition.position;
        }
    }



}


