using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public SlotUI slotUI;
    public GameObject itemTooktip;
    public TextMeshProUGUI itemDisplayText;

    public int currentIndex;

    #region Event

    private void OnEnable()
    {
        EventHandler.ReloadSlotDisplay += OnReloadSlotDisplay;
    }

    private void OnDisable()
    {
        EventHandler.ReloadSlotDisplay -= OnReloadSlotDisplay;
    }

    private void OnReloadSlotDisplay(ItemDetails itemDetails, int index)
    {
        if (index == -1)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            slotUI.DisplayItem(itemDetails, index);
            currentIndex = index;
        }
    }

    #endregion
}
