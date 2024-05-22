using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private Camera mainCamera;
    private bool isDragging = false;

    public List<Transform> snapPositions;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        difference = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 newPosition = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - difference;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToNearestPosition();
    }

    private void SnapToNearestPosition()
    {
        if (snapPositions == null || snapPositions.Count == 0)
            return;

        float minDistance = float.MaxValue;
        Transform closestSnapPosition = null;

        foreach (Transform snapPosition in snapPositions)
        {
            float distance = Vector2.Distance(transform.position, snapPosition.position);
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




