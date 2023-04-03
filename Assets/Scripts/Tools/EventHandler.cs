using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<int> ReloadSlotDisplay;

    public static void CallReloadSlotDisplay(int index)
    {
        ReloadSlotDisplay?.Invoke(index);
    }
}