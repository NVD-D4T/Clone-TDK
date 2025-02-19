using UnityEngine;
using UnityEngine.UI;

public class PanelManagerMarket : MonoBehaviour
{
    // Tham chiếu đến Panel 1 và Panel 2
    public GameObject panel1;
    public GameObject panel2;

    // Tham chiếu đến Button trong Panel 1
    public Button buttonInPanel1;

    // Hàm khởi tạo
    void Start()
    {
        // Đảm bảo Panel 2 ban đầu bị ẩn
        panel2.SetActive(false);
        

        // Gắn sự kiện cho Button khi được nhấn
        buttonInPanel1.onClick.AddListener(ShowPanel2OnTop);
    }

    // Hàm để hiển thị Panel 2 chồng lên Panel 1
    void ShowPanel2OnTop()
    {
        panel2.SetActive(true); // Bật Panel 2
    }
}