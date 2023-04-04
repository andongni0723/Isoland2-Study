using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Dictionary<ItemName, bool> AllSceneItemStateDict = new Dictionary<ItemName, bool>();

    #region Event

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnload += OnBeforeSceneUnload; // Save new item
        EventHandler.AfterSceneLoad += OnAfterSceneLoad; // Load item, and Save new item
        EventHandler.AfterReloadSlotDisplay += OnAfterReloadSlotDisplay; // Update item state to false
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnload -= OnBeforeSceneUnload;
        EventHandler.AfterSceneLoad -= OnAfterSceneLoad;
        EventHandler.AfterReloadSlotDisplay -= OnAfterReloadSlotDisplay; 
    }
    
    private void OnBeforeSceneUnload()
    {
        // Save New Item
        foreach (Item item in FindObjectsOfType<Item>())
        {
            if (!AllSceneItemStateDict.ContainsKey(item.itemName))
            {
                AllSceneItemStateDict.Add(item.itemName, true);
            }
        }
    }
    
    private void OnAfterSceneLoad()
    {
        // Load Item State and Save New Item
        foreach (Item item in FindObjectsOfType<Item>())
        {
            if (AllSceneItemStateDict.ContainsKey(item.itemName))
            {
                item.gameObject.SetActive(AllSceneItemStateDict[item.itemName]);
            }
            else
            {
                AllSceneItemStateDict.Add(item.itemName, true);
            }
        }
    }
    
    private void OnAfterReloadSlotDisplay(int index)
    {
        // Update Item State
        AllSceneItemStateDict[InventoryManager.Instance.Bag[index]] = false;
    }


    #endregion
}
