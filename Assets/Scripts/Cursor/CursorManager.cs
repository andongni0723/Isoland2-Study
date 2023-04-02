using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private bool canClick;


    private void Update()
    {
        canClick = GetObjectOfMousePosition();
        
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
