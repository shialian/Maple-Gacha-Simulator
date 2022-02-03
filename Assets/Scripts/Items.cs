using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

public class Item
{
    public TextMeshProUGUI text;
    [HideInInspector]
    public int amount;

    public void Init()
    {
        amount = 0;
        SetAmountText();
    }

    public void AddAndSetText(int itemAmount)
    {
        amount += itemAmount;
        SetAmountText();
    }

    public void UseAndSetText(int itemAmount)
    {
        if (amount >= itemAmount)
        {
            amount -= itemAmount;
            SetAmountText();
        }
    }

    private void SetAmountText()
    {
        text.SetText(amount.ToString());
    }
}

public enum ItemNames
{
    GoldApple,
    GoldApplePiece,
    Gourd,
    BossPiece,
    Stele,
    Other
}

public class Items : MonoBehaviour
{
    public static Items singleton;

    [SerializeField]
    private Item[] items;

    private void Start()
    {
        singleton = this;
        Init();
    }

    private void Init()
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i].Init();
        }
    }

    public bool HaveEnoughAmount(ItemNames itemName, int amount)
    {
        return items[(int)itemName].amount >= amount;
    }

    public void Add(ItemNames itemName, int amount)
    {
        items[(int)itemName].AddAndSetText(amount);
    }

    public void Use(ItemNames itemName, int amount)
    {
        items[(int)itemName].UseAndSetText(amount);
    }

    public int GetItemAmount(ItemNames itemName)
    {
        return items[(int)itemName].amount;
    }

    public bool AmountCheck(ItemNames itemName, int amount)
    {
        return items[(int)itemName].amount >= amount;
    }
}