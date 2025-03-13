using UnityEngine;

public class TurretPurchaseButton : MonoBehaviour
{
<<<<<<< Updated upstream
    public TurretPurchase turretPurchase;
    private TurretShop turretShop;
    public int turretType;
=======
    public TurretPurchase turretPurchase; // Tham chiếu đến TurretPurchase
    private TurretShop turretShop; // Tham chiếu đến TurretShop
    public int turretType; // Loại trụ
>>>>>>> Stashed changes

    void Start()
    {
        turretShop = Object.FindFirstObjectByType<TurretShop>();
    }

    public void OnPurchaseButtonClicked()
    {
        if (turretShop != null)
        {
<<<<<<< Updated upstream
            Vector3 purchasePosition = turretShop.GetPurchasePosition();
            turretPurchase.PurchaseTurret(purchasePosition, turretType);
            turretShop.CloseShop();
=======
            Vector3 purchasePosition = turretShop.GetPurchasePosition(); // Lấy vị trí mua trụ
            turretPurchase.PurchaseTurret(purchasePosition, turretType); // Mua trụ tại vị trí đã lưu với loại trụ cụ thể
            turretShop.CloseShop(); // Ẩn cửa hàng sau khi mua trụ
>>>>>>> Stashed changes
        }
    }
}
