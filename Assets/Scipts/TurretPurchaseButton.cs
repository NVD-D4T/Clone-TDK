using UnityEngine;

public class TurretPurchaseButton : MonoBehaviour
{
    public TurretPurchase turretPurchase;
    private TurretShop turretShop;
    public int turretType;

    void Start()
    {
        turretShop = Object.FindFirstObjectByType<TurretShop>();
    }

    public void OnPurchaseButtonClicked()
    {
        if (turretShop != null)
        {
            Vector3 purchasePosition = turretShop.GetPurchasePosition();
            turretPurchase.PurchaseTurret(purchasePosition, turretType);
            turretShop.CloseShop();
        }
    }
}
