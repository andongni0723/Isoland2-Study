using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICursorClick
{
    public ItemName itemName;
    public void ICursorClick()
    {
        // Add to bag and disable self
        InventoryManager.Instance.AddItem(itemName);
        gameObject.SetActive(false);
    }
}
