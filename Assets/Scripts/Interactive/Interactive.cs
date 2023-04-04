using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactive : MonoBehaviour, ICursorClick
{
    public ItemName correctItem;
    public bool isCorrect;

    public void ICursorClick()
    {
        CheckItemCorrect(SlotUI.Instance.GetSelectedItem().itemName);
    }

    public void CheckItemCorrect(ItemName itemName)
    {
        if (itemName == correctItem)
        {
            CorrectClick();
        }
        else
        {
            CommonClick();
            Debug.Log("Empty Click");
        }
    }

    protected virtual void CommonClick() {}
    protected virtual void CorrectClick() {}
}
