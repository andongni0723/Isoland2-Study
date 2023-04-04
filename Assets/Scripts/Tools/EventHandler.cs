using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<int> ReloadSlotDisplay;
    public static void CallReloadSlotDisplay(int index)
    {
        ReloadSlotDisplay?.Invoke(index);
        
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
}