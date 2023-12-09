using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;
    private int earnedCoin;
    public static event Action<int> OnMoneyChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseCoin()
    {
        earnedCoin++;
        OnMoneyChanged?.Invoke(earnedCoin);
        Debug.Log(earnedCoin);
    }
}
