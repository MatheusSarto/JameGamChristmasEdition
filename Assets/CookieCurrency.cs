using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CookieCurrency : MonoBehaviour
{

    public static CookieCurrency instance;


    void Awake()
    {
        instance = this;
    }


    [Header("Cookies")]
    public int CookieCount = 0;
    public Text CurCookies;


    public void PickUpCookie()
    {
        CookieCount++;
        CurCookies.text = "Cookies: " + CookieCount;
        Debug.Log($"Quantidade de cookies: {CookieCount}");
    }


}
