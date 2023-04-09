using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemDataList;
    [SerializeField] public List<ItemName> Bag = new List<ItemName>(); // Bag

    //protected override void Awake()
    //{
    //    base.Awake();
    //    //FIXME:
    //    EventHandler.CallReloadSlotDisplay(-1);
    //}

    #region Event

    private void OnEnable()
    {
        EventHandler.UseItem += OnUseItem;
    }

    private void OnDisable()
    {
        EventHandler.UseItem -= OnUseItem;
    }

    private void OnUseItem(ItemName itemName)
    {
        Bag.Remove(itemName);
        
        if(Bag.Count == 0)
            EventHandler.CallReloadSlotDisplay(null ,-1);
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
