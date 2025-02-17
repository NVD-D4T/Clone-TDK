using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    public Enemy enemy; // Tham chiếu đến đối tượng quái vật
    public Slider healthSlider; // Slider của thanh máu

    void Start()
    {
        healthSlider.maxValue = enemy.maxHealth; // Đặt giá trị tối đa của Slider bằng máu tối đa của quái vật
        healthSlider.value = enemy.currentHealth; // Đặt giá trị hiện tại của Slider bằng máu hiện tại của quái vật
    }

    void Update()
    {
        healthSlider.value = enemy.currentHealth; // Cập nhật giá trị của Slider theo máu hiện tại của quái vật
    }
}
