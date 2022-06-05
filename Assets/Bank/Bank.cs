using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField]
    int startingBalance = 150;

    [SerializeField]
    int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField]
    TextMeshProUGUI displayBalance;

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDispalyBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDispalyBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDispalyBalance();

        if (currentBalance < 0)
        {
            // lose game
            ReloadScene();
        }
    }

    void UpdateDispalyBalance()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
