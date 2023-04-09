using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Dictionary<ItemName, bool> AllSceneItemStateDict = new Dictionary<ItemName, bool>();
    public Dictionary<string, bool> AllSceneInteractiveStateDict = new Dictionary<string, bool>();

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
            AllSceneItemStateDict.TryAdd(item.itemName, true);
        }

        foreach (Interactive item in FindObjectsOfType<Interactive>())
        {
            if (AllSceneInteractiveStateDict.ContainsKey(item.name))
            {
                AllSceneInteractiveStateDict[item.name] = item.isCorrect;
            }
            else
            {
                AllSceneInteractiveStateDict.TryAdd(item.gameObject.name, item.isCorrect);
            }
        }
    }
    
    private void OnAfterSceneLoad()
    {
        // Load Item State and Save New Item
        foreach (Item item in FindObjectsOfType<Item>())
        {
            if (AllSceneItemStateDict.TryGetValue(item.itemName, out var value))
            {
                item.gameObject.SetActive(value);
            }
            else
            {
                AllSceneItemStateDict.Add(item.itemName, true);
            }
        }
        
        // Load Interactive object State and Save New Item
        foreach (Interactive item in FindObjectsOfType<Interactive>())
        {
            if (AllSceneInteractiveStateDict.TryGetValue(item.gameObject.name, out var value))
            {
                Debug.Log("load");
                item.isCorrect = value;
            }
        }
    }
    
    private void OnAfterReloadSlotDisplay(int index)
    {
        if(index == -1) return;
        
        
        // Update Item State
        AllSceneItemStateDict[InventoryManager.Instance.Bag[index]] = false;
    }


    #endregion
}
