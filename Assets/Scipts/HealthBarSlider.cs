using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    public Enemy enemy; // Tham chiếu đến đối tượng quái vật
    public Slider healthSlider; // Slider của thanh máu
    private Canvas canvas; // Canvas chính

    void Start()
    {
        healthSlider.maxValue = enemy.maxHealth; // Đặt giá trị tối đa của Slider bằng máu tối đa của quái vật
        healthSlider.value = enemy.currentHealth; // Đặt giá trị hiện tại của Slider bằng máu hiện tại của quái vật

        // Thay thế Object.FindObjectOfType bằng Object.FindFirstObjectByType hoặc Object.FindAnyObjectByType
        canvas = Object.FindFirstObjectByType<Canvas>();
        if (canvas != null)
        {
            transform.SetParent(canvas.transform);
        }

        // Hiển thị thanh máu khi bắt đầu
        gameObject.SetActive(true);
    }

    void Update()
    {
        // Kiểm tra xem đối tượng enemy có bị hủy không trước khi truy cập vào thuộc tính của nó
        if (enemy == null)  
        {
            Destroy(gameObject); // Hủy đối tượng thanh máu nếu quái vật đã bị hủy
            return;
        }

        healthSlider.value = enemy.currentHealth; // Cập nhật giá trị của Slider theo máu hiện tại của quái vật

        // Cập nhật vị trí của thanh máu theo vị trí của quái vật
        Vector3 healthBarPosition = Camera.main.WorldToScreenPoint(enemy.transform.position + new Vector3(0, 2, 0));
        transform.position = healthBarPosition;
    }
}
