using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int goldReward = 25;

    [SerializeField]
    int goldPenalty = 10;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (!bank) { return; }
        bank.Deposit(goldReward);
    }

    public void PenalizeGold()
    {
        if (!bank) { return; }
        bank.Withdraw(goldPenalty);
    }
}
