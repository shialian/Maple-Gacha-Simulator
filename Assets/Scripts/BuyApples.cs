using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyApples : MonoBehaviour
{
    private int price = 1890;
    private int apples = 35;

    public void Buy()
    {
        if(GameManager.singleton.HaveEnoughMoney(price))
        {
            GameManager.singleton.PayMoney(price);
            Items.singleton.Add(ItemNames.GoldApple, apples);
        }
        else
        {
            Panel.singleton.CreateMessage(MsgName.NoBudge);
        }
    }
}
