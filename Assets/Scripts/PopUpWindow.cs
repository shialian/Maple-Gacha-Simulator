using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour
{
    public static PopUpWindow singleton;

    public GameObject lucky;
    public GameObject unlucky;
    public GameObject warn;
    public GameObject maybeUnlucky;

    public Button buy;
    public Button appleGacha;
    public Button boxGacha;

    private void Start()
    {
        singleton = this;
    }

    public void ActiveLuckyWindow()
    {
        DisableButtons();
        lucky.SetActive(true);
    }

    public void ActiveUnluckyWindow()
    {
        DisableButtons();
        unlucky.SetActive(true);
    }

    public void ActiveMaybeUnluckyWindow()
    {
        DisableButtons();
        maybeUnlucky.SetActive(true);
    }

    public void Continue()
    {
        DisableWindows();
        EnableButtons();
    }

    public void StoreGash()
    {
        lucky.SetActive(false);
        unlucky.SetActive(false);
        maybeUnlucky.SetActive(false);
        warn.SetActive(true);
    }

    public void GoToStoreGash()
    {
        Application.OpenURL("https://tw.beanfun.com/");
    }

    public void SeeDetail()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=mHSEKXudXOI");
    }

    private void EnableButtons()
    {
        buy.interactable = true;
        appleGacha.interactable = true;
        boxGacha.interactable = true;
    }

    private void DisableButtons()
    {
        buy.interactable = false;
        appleGacha.interactable = false;
        boxGacha.interactable = false;
    }

    private void DisableWindows()
    {
        lucky.SetActive(false);
        unlucky.SetActive(false);
        maybeUnlucky.SetActive(false);
        warn.SetActive(false);
    }
}
