using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public GameObject shopUI; // Tham chiếu đến UI cửa hàng
    private Vector3 purchasePosition; // Vị trí mua trụ

    void Start()
    {
        shopUI.SetActive(false); // Ẩn UI cửa hàng lúc đầu
    }

    public void OpenShop()
    {
        shopUI.SetActive(true); // Hiển thị UI cửa hàng
    }

    public void CloseShop()
    {
        shopUI.SetActive(false); // Ẩn UI cửa hàng
    }

    public void SetPurchasePosition(Vector3 position)
    {
        purchasePosition = position; // Lưu vị trí mua trụ
    }

    public Vector3 GetPurchasePosition()
    {
        return purchasePosition; // Lấy vị trí mua trụ
    }
}
