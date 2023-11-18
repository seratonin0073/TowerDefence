using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private int startCoin;
    private static int coin;

    private void Start()
    {
        coin = startCoin;
    }

    private void LateUpdate()
    {
        coinText.text = coin.ToString();
    }
    public static int GetCoin()
    {
        return coin;
    }

    public static void AddCoin(int value)
    {
        coin += value;
    }

    public static bool SubtracCoin(int value)
    {
        if (value > coin) return false;
        coin -= value;
        return true;
    }


    
}
