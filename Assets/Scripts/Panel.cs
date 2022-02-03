using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MsgName
{
    NoBudge,
    NoApple,
    NoBox,
    Apple,
    Box
}

public class Panel : MonoBehaviour
{
    public static Panel singleton;

    

    public RectTransform noBudgeMsg;
    public RectTransform noAppleMsg;
    public RectTransform noBoxMsg;
    public RectTransform appleMsg;
    public RectTransform boxMsg;
    private List<RectTransform> msgList = new List<RectTransform>();

    private RectTransform rectTransform;
    private float maxHeight;
    private float msgHeight;

    private void Start()
    {
        singleton = this;
        rectTransform = GetComponent<RectTransform>();
        maxHeight = rectTransform.rect.height - 10f;
        msgHeight = noBudgeMsg.GetComponent<RectTransform>().rect.height;
    }

    public void CreateMessage(MsgName msgName, string itemName="")
    {
        RectTransform newMsg = null;
        switch (msgName)
        {
            case MsgName.NoBudge:
                newMsg = Instantiate(noBudgeMsg, transform);
                break;
            case MsgName.NoApple:
                newMsg = Instantiate(noAppleMsg, transform);
                break;
            case MsgName.NoBox:
                newMsg = Instantiate(noBoxMsg, transform);
                break;
            case MsgName.Apple:
                newMsg = Instantiate(appleMsg, transform);
                newMsg.GetComponent<Message>().SetItemText(itemName);
                break;
            case MsgName.Box:
                newMsg = Instantiate(boxMsg, transform);
                newMsg.GetComponent<Message>().SetItemText("[" + itemName + "]");
                break;
        }
        UpdateMsgPosition();
        MsgInit(newMsg);
    }

    private void UpdateMsgPosition()
    {
        Vector2 position;
        for (int i = 0; i < msgList.Count; i++)
        {
            position = msgList[i].anchoredPosition;
            position.y += msgHeight;
            msgList[i].anchoredPosition = position;
        }
        if (msgList.Count > 0 && msgList[0].position.y > maxHeight)
        {
            GameObject obj = msgList[0].gameObject;
            msgList.RemoveAt(0);
            Destroy(obj);
        }
    }

    private void MsgInit(RectTransform msg)
    {
        msg.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, msgHeight / 2f);
        msgList.Add(msg);
    }
}
