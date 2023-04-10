using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemDataList;
    [SerializeField] public List<ItemName> Bag = new List<ItemName>(); 

    #region Event

    private void OnEnable()
    {
        EventHandler.UseItem += OnUseItem; // Remove item in bag, and reload bag UI display
        EventHandler.AfterSceneLoad += OnAfterSceneLoad; // Reload bag UI display
        EventHandler.BagChangeItem += OnBagChangeItem; // Reload bag UI display
    }

    private void OnDisable()
    {
        EventHandler.UseItem -= OnUseItem;
        EventHandler.BagChangeItem -= OnBagChangeItem;
        EventHandler.AfterSceneLoad -= OnAfterSceneLoad;
    }

    private void OnBagChangeItem(int index)
    {
        EventHandler.CallReloadSlotDisplay(itemDataList.FindItemDetails(Bag[index]), index);
    }

    private void OnAfterSceneLoad()
    {
        if (Bag.Count == 0)
        {
            EventHandler.CallReloadSlotDisplay(null, -1);
        }
        else
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                EventHandler.CallReloadSlotDisplay(itemDataList.FindItemDetails(Bag[i]), i);
            }
        }
        
    }

    private void OnUseItem(ItemName itemName)
    {
        Bag.Remove(itemName);
        
        if(Bag.Count == 0)
            EventHandler.CallReloadSlotDisplay(null ,-1);
        else
            EventHandler.CallReloadSlotDisplay(itemDataList.FindItemDetails(Bag[0]), 0);
    }

    #endregion

    public void AddItem(ItemName item)
    {
        // Check not have this item and add to bag
        if (!Bag.Contains(item)) // Contains 包含
        {
            Bag.Add(item);
            
            // UI display the last(new) item
            EventHandler.CallReloadSlotDisplay(itemDataList.FindItemDetails(item), Bag.Count - 1);
        }
    }
}
