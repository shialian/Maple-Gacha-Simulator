using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    public TextMeshProUGUI itemText;

    public void SetItemText(string itemName)
    {
        itemText.SetText(itemName);
    }
}
