using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject hand;
    
    private Vector3 mouseWorldPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private bool canClick;

    #region Event

    private void OnEnable()
    {
        EventHandler.ItemSelected += OnItemSelected; // Set hand active
    }

    private void OnDisable()
    {
        EventHandler.ItemSelected -= OnItemSelected;
    }

    private void OnItemSelected(ItemDetails itemDetails, bool isSelected)
    {
        hand.SetActive(isSelected);
    }

    #endregion

    private void Update()
    {
        canClick = GetObjectOfMousePosition();
        
        // Hand cursor position
        if (hand.activeInHierarchy)
        {
            hand.transform.position = Input.mousePosition;
        }

        // Pointer Click
        if (canClick && Input.GetMouseButtonDown(0))
        {
             // Click Action
             ClickAction(GetObjectOfMousePosition().gameObject);
        }
    }

    private void ClickAction(GameObject target)
    {
        // Call the interface
        ICursorClick iCursorClick = target.GetComponent<ICursorClick>();
        iCursorClick?.ICursorClick();
    }

    /// <summary>
    /// Get the object at mouse position
    /// </summary>
    /// <returns></returns>
    private Collider2D GetObjectOfMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPosition);
    }
}
