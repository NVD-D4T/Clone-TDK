using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f; // Máu tối đa của quái vật
    public float currentHealth; // Máu hiện tại của quái vật
    private HealthBarSlider healthBarSlider;

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        healthBarSlider = GetComponentInChildren<HealthBarSlider>(); // Tìm thành phần thanh máu con
        if (healthBarSlider != null)
        {
            healthBarSlider.gameObject.SetActive(true); // Hiển thị thanh máu khi sinh ra
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Giảm máu khi bị tấn công

        // Cập nhật giá trị thanh máu
        if (healthBarSlider != null)
        {
            healthBarSlider.healthSlider.value = currentHealth; // Cập nhật giá trị của Slider theo máu hiện tại của quái vật
        }

        // Kiểm tra nếu máu bằng 0 hoặc ít hơn
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Hủy hoặc ẩn thanh máu khi quái vật chết
        if (healthBarSlider != null)
        {
            Destroy(healthBarSlider.gameObject);
        }
        
        Destroy(gameObject); // Hủy quái vật
    }
}
