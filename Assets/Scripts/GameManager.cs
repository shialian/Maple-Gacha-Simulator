using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;


    public TMP_InputField budgeText;
    private int yourBudge = 150000;

    public TextAsset appleItemListText;
    public TextAsset boxItemListText;
    public int mainItemNum;
    private int gourdIndex;
    private int bossPieceIndex;
    private string[] appleItemList;
    private string[] boxItemList;

    public int mainItemPrice;
    public GameObject broken;
    private int applePrice = 1890;
    private int singleApplePrice = 54;

    private void Start()
    {
        DontDestroyOnLoad(this);
        singleton = this;
        budgeText.text = yourBudge.ToString();
        AppleListInit();
        BoxListInit();
    }

    private void AppleListInit()
    {
        appleItemList = appleItemListText.text.Split(' ', '\n');
        gourdIndex = mainItemNum;
        bossPieceIndex = gourdIndex + 1;
        for(int i = 0; i < appleItemList.Length; i++)
        {
            string item = appleItemList[i];
            int len = appleItemList[i].Length;
            if (item[len - 1] == '\r')
            {
                appleItemList[i] = item.Substring(0, len - 1);
            }
        }
    }

    private void BoxListInit()
    {
        boxItemList = boxItemListText.text.Split(' ', '\n');
        gourdIndex = mainItemNum;
        bossPieceIndex = gourdIndex + 1;
        for (int i = 0; i < boxItemList.Length; i++)
        {
            string item = boxItemList[i];
            int len = boxItemList[i].Length;
            if (item[len - 1] == '\r')
            {
                boxItemList[i] = item.Substring(0, len - 1);
            }
        }
    }

    public bool HaveEnoughMoney(int price)
    {
        return yourBudge >= price;
    }

    public void PayMoney(int price)
    {
        yourBudge -= price;
        budgeText.text = yourBudge.ToString();
    }

    public void ChangeBudge()
    {
        yourBudge = int.Parse(budgeText.text);
        if(yourBudge >= applePrice)
        {
            broken.SetActive(false);
        }
    }

    public string GetRandomMainItem(MsgName msgName)
    {
        int randomIndex = Random.Range(0, mainItemNum);
        if (msgName == MsgName.Apple)
        {
            return appleItemList[randomIndex];
        }
        else
        {
            return boxItemList[randomIndex];
        }
    }

    public string GetGourd()
    {
        return appleItemList[gourdIndex];
    }

    public string GetBossPiece()
    {
        return appleItemList[bossPieceIndex];
    }

    public string GetOtherItem(MsgName msgName)
    {
        int randomIndex;
        if (msgName == MsgName.Apple)
        {
            randomIndex = Random.Range(bossPieceIndex + 1, appleItemList.Length);
            return appleItemList[randomIndex];
        }
        else
        {
            randomIndex = Random.Range(mainItemNum, boxItemList.Length);
            if (boxItemList[randomIndex] == "漆黑的BOSS飾品碎片(10)")
                Items.singleton.Add(ItemNames.BossPiece, 10);
            if (boxItemList[randomIndex] == "漆黑的BOSS飾品碎片(15)")
                Items.singleton.Add(ItemNames.BossPiece, 15);
            if (boxItemList[randomIndex] == "漆黑的BOSS飾品碎片(20)")
                Items.singleton.Add(ItemNames.BossPiece, 20);
            return boxItemList[randomIndex];
        }
    }

    public void BrokenCheck()
    {
        if(yourBudge <= applePrice && Items.singleton.AmountCheck(ItemNames.GoldApple, 1) == false && Items.singleton.AmountCheck(ItemNames.GoldApplePiece, 100) == false)
        {
            if(Items.singleton.AmountCheck(ItemNames.Stele, 1) == false)
            {
                broken.SetActive(true);
            }
        }
    }

    public void SpentMoneyCheck(int appleSpentAmount, bool getMainItem)
    {
        int totalSpent = appleSpentAmount * singleApplePrice;
        if (getMainItem)
        {
            if(totalSpent >= mainItemPrice && Items.singleton.AmountCheck(ItemNames.Stele, 2) == false)
            {
                PopUpWindow.singleton.ActiveMaybeUnluckyWindow();
            }
            else
            {
                PopUpWindow.singleton.ActiveLuckyWindow();
            }
        }
        else if(totalSpent >= mainItemPrice && totalSpent < mainItemPrice + singleApplePrice)
        {
            PopUpWindow.singleton.ActiveUnluckyWindow();
        }
    }
}