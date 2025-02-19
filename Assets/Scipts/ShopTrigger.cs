using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private TurretShop turretShop; // Tham chiếu đến TurretShop

    void Start()
    {
        turretShop = Object.FindFirstObjectByType<TurretShop>(); // Tìm đối tượng TurretShop
    }

    void OnMouseDown()
    {
        if (turretShop != null)
        {
            turretShop.OpenShop(); // Mở cửa hàng khi nhấp vào đối tượng
            turretShop.SetPurchasePosition(transform.position); // Lưu vị trí của đối tượng 3D
        }
    }
}
