using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTooltip : MonoBehaviour
{
    public TextMeshProUGUI itemDisplayName;
    
    public void SetItemText(string displayName)
    {
        itemDisplayName.text = displayName;
    }
}
