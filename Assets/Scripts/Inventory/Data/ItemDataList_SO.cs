using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "Inventory/ItemDataList_SO")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;

    public ItemDetails FindItemDetails(ItemName targetItemName)
    {
        return itemDetailsList.Find(i => i.itemName == targetItemName);
    }
}

[System.Serializable]
public class ItemDetails
{
    public ItemName itemName;
    public string itemDisplayName;
    public Sprite itemIcon;
}
