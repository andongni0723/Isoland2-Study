using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
            
            ButtonClickCanUse();
        }
    }

    #endregion
    
    #region Button Event
    
    public void ButtonClickToChangeItem(int amount) // amount 數量
    {
        currentIndex += amount;
        ButtonClickCanUse();
        EventHandler.CallBagChangeItem(currentIndex);
    }
    #endregion


    /// <summary>
    /// Check Button interactable state
    /// </summary>
    private void ButtonClickCanUse()
    {
        int bagCount = InventoryManager.Instance.Bag.Count;
        
        leftButton.interactable = currentIndex != 0;
        rightButton.interactable = currentIndex != bagCount - 1;
    }
}
