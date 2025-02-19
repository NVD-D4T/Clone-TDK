using UnityEngine;

public class TurretPurchaseButton : MonoBehaviour
{
    public TurretPurchase turretPurchase; // Tham chiếu đến TurretPurchase
    private TurretShop turretShop; // Tham chiếu đến TurretShop

    void Start()
    {
        turretShop = Object.FindFirstObjectByType<TurretShop>(); // Tìm đối tượng TurretShop
    }

    public void OnPurchaseButtonClicked()
    {
        if (turretShop != null)
        {
            Vector3 purchasePosition = turretShop.GetPurchasePosition(); // Lấy vị trí mua trụ
            turretPurchase.PurchaseTurret(purchasePosition); // Mua trụ tại vị trí đã lưu
            turretShop.CloseShop(); // Ẩn cửa hàng sau khi mua trụ
        }
    }
}
