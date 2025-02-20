using UnityEngine;

public class TurretPurchase : MonoBehaviour
{
    public GameObject turretType1Prefab;
    public GameObject turretType2Prefab;
    public GameObject turretType3Prefab;
    private PlayerCurrency playerCurrency;

    void Start()
    {
        FindPlayerCurrency();
    }

    private void FindPlayerCurrency()
    {
        GameObject playerCurrencyObject = GameObject.FindWithTag("PlayerCurrency1");
        if (playerCurrencyObject != null)
        {
            playerCurrency = playerCurrencyObject.GetComponent<PlayerCurrency>();
        }
    }

    public void PurchaseTurret(Vector3 position, int turretType)
    {
        if (playerCurrency == null)
        {
            FindPlayerCurrency();
        }

        GameObject turretPrefab = null;
        int turretCost = 0;

        switch (turretType)
        {
            case 1:
                turretPrefab = turretType1Prefab;
                turretCost = turretType1Prefab.GetComponent<TurretType1>().turretCost;
                break;
            case 2:
                turretPrefab = turretType2Prefab;
                turretCost = turretType2Prefab.GetComponent<TurretType2>().turretCost;
                break;
            case 3:
                turretPrefab = turretType3Prefab;
                turretCost = turretType3Prefab.GetComponent<TurretType3>().turretCost;
                break;
        }

        if (playerCurrency != null && playerCurrency.SpendCurrency(turretCost))
        {
            // Thay đổi vị trí để trụ đặt phía trên đối tượng turretShop
            Vector3 placementPosition = new Vector3(position.x, position.y + 0.7f, position.z);
            Instantiate(turretPrefab, placementPosition, Quaternion.identity);
        }
    }
}
