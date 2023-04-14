using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "__DialogueData_SO", menuName = "Dialogue/DialogueData_SO")]
public class DialogueData_SO : ScriptableObject
{
    public Data data;
}

[System.Serializable]
public class Data
{
    public List<string> DialogueList = new List<string>();

}
