using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : Singleton<SlotUI>, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemIcon;
    public ItemDetails currentItem;
    public ItemTooltip ItemTooltip;
    [SerializeField] private bool isSelected;

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

    public ItemDetails GetSelectedItem()
    {
        if (isSelected)
            return currentItem;

        return new ItemDetails();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        EventHandler.CallItemSelected(currentItem, isSelected);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // UI Tooltip
        ItemTooltip.SetItemText(currentItem.itemDisplayName);
        ItemTooltip.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemTooltip.gameObject.SetActive(false);
    }
}
