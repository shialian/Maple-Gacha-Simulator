using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gacha : MonoBehaviour
{
    private int appleGachaed = 0;
    private bool getMainItem = false;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        GameManager.singleton.SpentMoneyCheck(appleGachaed, true);
    //    }
    //}

    public void AppleGacha()
    {
        if(Items.singleton.HaveEnoughAmount(ItemNames.GoldApple, 1))
        {
            Items.singleton.Use(ItemNames.GoldApple, 1);
            Items.singleton.Add(ItemNames.GoldApplePiece, 1);
            RandomAppleGacha();
            appleGachaed++;
            GameManager.singleton.BrokenCheck();
            GameManager.singleton.SpentMoneyCheck(appleGachaed, getMainItem);
        }
        else
        {
            Panel.singleton.CreateMessage(MsgName.NoApple);
        }
    }

    public void BoxGacha()
    {
        if (Items.singleton.HaveEnoughAmount(ItemNames.GoldApplePiece, 100))
        {
            Items.singleton.Use(ItemNames.GoldApplePiece, 100);
            RandomBoxGacha();
            GameManager.singleton.BrokenCheck();
        }
        else
        {
            Panel.singleton.CreateMessage(MsgName.NoBox);
        }
    }

    private void RandomAppleGacha()
    {
        float randomNum = Mathf.Round(Random.value * 10000f);

        if(randomNum <= 6f)
        {
            getMainItem = true;
            Items.singleton.Add(ItemNames.Stele, 1);
            Panel.singleton.CreateMessage(MsgName.Apple, GameManager.singleton.GetRandomMainItem(MsgName.Apple));
            GameManager.singleton.SpentMoneyCheck(appleGachaed, getMainItem);
        }
        else if(randomNum <= 111f)
        {
            Items.singleton.Add(ItemNames.Gourd, 1);
            Panel.singleton.CreateMessage(MsgName.Apple, GameManager.singleton.GetGourd());
        }
        else if(randomNum <= 699f)
        {
            Items.singleton.Add(ItemNames.BossPiece, 1);
            Panel.singleton.CreateMessage(MsgName.Apple, GameManager.singleton.GetBossPiece());
        }
        else
        {
            Panel.singleton.CreateMessage(MsgName.Apple, GameManager.singleton.GetOtherItem(MsgName.Apple));
        }
    }

    private void RandomBoxGacha()
    {
        float randomNum = Mathf.Round(Random.value * 10000f);

        if (randomNum <= 439f)
        {
            getMainItem = true;
            Items.singleton.Add(ItemNames.Stele, 1);
            Panel.singleton.CreateMessage(MsgName.Box, GameManager.singleton.GetRandomMainItem(MsgName.Box));
            GameManager.singleton.SpentMoneyCheck(appleGachaed, getMainItem);
        }
        else
        {
            Panel.singleton.CreateMessage(MsgName.Box, GameManager.singleton.GetOtherItem(MsgName.Box));
        }
    }
}
