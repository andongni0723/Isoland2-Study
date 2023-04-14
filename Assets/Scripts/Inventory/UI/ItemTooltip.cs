using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemTooltip : MonoBehaviour
{
    public Text itemDisplayName;
    
    public void SetItemText(string displayName)
    {
        itemDisplayName.text = displayName;
    }
}
