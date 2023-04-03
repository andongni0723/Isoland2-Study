using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemIcon;
    private ItemDetails currentItem;
    private bool isSelected;

    public void DisplayItem(int index)
    {
        currentItem = InventoryManager.Instance.itemDataList.itemDetailsList[index];
        gameObject.SetActive(true);
        
        // Display
        itemIcon.sprite = currentItem.itemIcon;
        itemIcon.SetNativeSize();
    }

    public void SetEmpty()
    {
        gameObject.SetActive(false);
        itemIcon.sprite = null;
        currentItem = null;
    }
}
