using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> ReloadSlotDisplay;
    public static void CallReloadSlotDisplay(ItemDetails itemDetails, int index)
    {
        ReloadSlotDisplay?.Invoke(itemDetails, index);
        
        CallAfterReloadSlotDisplay(index);
    }
    
    public static event Action<int> AfterReloadSlotDisplay;
    public static void CallAfterReloadSlotDisplay(int index)
    {
        AfterReloadSlotDisplay?.Invoke(index);
    }

    public static event Action BeforeSceneUnload;
    public static void CallBeforeSceneUnload()
    {
        BeforeSceneUnload?.Invoke();
    }

    public static event Action AfterSceneLoad;
    public static void CallAfterSceneLoad()
    {
        AfterSceneLoad?.Invoke();
    }


    public static event Action<ItemDetails, bool> ItemSelected;
    public static void CallItemSelected(ItemDetails itemDetails, bool isSelected)
    {
        ItemSelected?.Invoke(itemDetails, isSelected);
    }

    public static event Action<ItemName> UseItem;
    public static void CallUseItem(ItemName itemName)
    {
        UseItem?.Invoke(itemName);
    }
    
    public static event Action<int> BagChangeItem;
    public static void CallBagChangeItem(int index)
    {
        BagChangeItem?.Invoke(index);
    }
}