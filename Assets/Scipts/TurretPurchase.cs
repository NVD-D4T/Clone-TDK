using UnityEngine;

public class TurretPurchase : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab của trụ
    public int turretCost = 20; // Giá của trụ
    private PlayerCurrency playerCurrency; // Tham chiếu đến PlayerCurrency

    void Start()
    {
        FindPlayerCurrency();
    }

    private void FindPlayerCurrency()
    {
        // Tìm đối tượng PlayerCurrency theo tag
        GameObject playerCurrencyObject = GameObject.FindWithTag("PlayerCurrency1");
        if (playerCurrencyObject != null)
        {
            playerCurrency = playerCurrencyObject.GetComponent<PlayerCurrency>();
        }
    }

    public void PurchaseTurret(Vector3 position)
    {
        if (playerCurrency == null)
        {
            FindPlayerCurrency();
        }

        if (playerCurrency != null && playerCurrency.SpendCurrency(turretCost))
        {
            Instantiate(turretPrefab, position, Quaternion.identity); // Tạo trụ tại vị trí được chỉ định
        }
    }
}
