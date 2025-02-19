using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
    public int startingCurrency = 100; // Số tiền ban đầu của người chơi
    private int currentCurrency; // Số tiền hiện tại của người chơi
    public Text currencyText; // Text UI để hiển thị tiền

    void Start()
    {
        currentCurrency = startingCurrency; // Thiết lập số tiền ban đầu
        UpdateCurrencyUI(); // Cập nhật UI
    }

    public void AddCurrency(int amount)
    {
        currentCurrency += amount; // Thêm tiền
        UpdateCurrencyUI(); // Cập nhật UI
    }

    public bool SpendCurrency(int amount)
    {
        if (currentCurrency >= amount)
        {
            currentCurrency -= amount; // Trừ tiền
            UpdateCurrencyUI(); // Cập nhật UI
            return true;
        }
        return false;
    }

    private void UpdateCurrencyUI()
    {
        currencyText.text = "Currency: " + currentCurrency.ToString(); // Cập nhật text UI hiển thị tiền
    }

    public int GetCurrentCurrency()
    {
        return currentCurrency;
    }
}
