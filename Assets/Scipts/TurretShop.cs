using UnityEngine;
using UnityEngine.UI;

public class TurretShop : MonoBehaviour
{
    public GameObject shopUI; // Tham chiếu đến UI cửa hàng
    private Vector3 purchasePosition; // Vị trí mua trụ
    public Button closeButton; // Tham chiếu đến nút đóng cửa hàng

    void Start()
    {
        shopUI.SetActive(false); // Ẩn UI cửa hàng lúc đầu
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        closeButton.onClick.AddListener(CloseShop); // Gắn sự kiện khi nhấn nút tắt cửa hàng
=======
=======
>>>>>>> Stashed changes
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseShop); // Kết nối sự kiện khi nhấn nút tắt cửa hàng
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
