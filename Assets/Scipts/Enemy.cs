using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f; // Máu tối đa của quái vật
    public float currentHealth; // Máu hiện tại của quái vật
    public GameObject healthBar; // Tham chiếu đến thanh máu
    private float lastHitTime; // Thời gian bị bắn gần nhất
    private bool isHealthBarVisible = false; // Trạng thái hiển thị của thanh máu
    public float healthBarDisplayDuration = 2f; // Thời gian hiển thị thanh máu

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        healthBar.SetActive(false); // Ẩn thanh máu ban đầu
    }

    void Update()
    {
        // Kiểm tra thời gian từ lần bị bắn cuối cùng
        if (isHealthBarVisible && Time.time - lastHitTime >= healthBarDisplayDuration)
        {
            healthBar.SetActive(false);
            isHealthBarVisible = false;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Giảm máu khi bị tấn công

        // Cập nhật thời gian bị bắn gần nhất và hiển thị thanh máu
        lastHitTime = Time.time;
        if (!isHealthBarVisible)
        {
            healthBar.SetActive(true);
            isHealthBarVisible = true;
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
        Destroy(healthBar); 
        
        Destroy(gameObject); // Hủy quái vật
    }
}
