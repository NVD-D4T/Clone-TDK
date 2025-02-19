using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f; // Máu tối đa của quái vật
    public float currentHealth; // Máu hiện tại của quái vật
    public int currencyReward = 10; // Số tiền thưởng khi tiêu diệt quái vật
    private HealthBarSlider healthBarSlider;
    private PlayerCurrency playerCurrency; // Tham chiếu đến PlayerCurrency

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        healthBarSlider = GetComponentInChildren<HealthBarSlider>(); // Tìm thành phần thanh máu con
        if (healthBarSlider != null)
        {
            healthBarSlider.gameObject.SetActive(true); // Hiển thị thanh máu khi sinh ra
        }

        playerCurrency = Object.FindFirstObjectByType<PlayerCurrency>(); // Tìm đối tượng PlayerCurrency
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
        // Thêm tiền cho người chơi khi tiêu diệt quái vật
        if (playerCurrency != null)
        {
            playerCurrency.AddCurrency(currencyReward);
        }

        // Hủy hoặc ẩn thanh máu khi quái vật chết
        if (healthBarSlider != null)
        {
            Destroy(healthBarSlider.gameObject);
        }
        
        Destroy(gameObject); // Hủy quái vật
    }
}
