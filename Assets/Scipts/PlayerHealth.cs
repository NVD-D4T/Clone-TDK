using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Máu tối đa của người chơi
    private int currentHealth; // Máu hiện tại của người chơi
    public Text healthText; // Text UI để hiển thị máu

    public GameObject gameOverPanel; // Tham chiếu đến Panel thông báo Game Over

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        UpdateHealthUI(); // Cập nhật UI
        gameOverPanel.SetActive(false); // Ẩn Panel thông báo Game Over lúc đầu
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Giảm máu khi bị tấn công
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthUI(); // Cập nhật UI

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthUI()
    {
        healthText.text = "       " + currentHealth.ToString(); // Cập nhật text UI hiển thị máu
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Hiển thị Panel thông báo Game Over
        // Bạn có thể thêm các hành động khác tại đây (ví dụ: dừng game, phát nhạc, v.v.)
        Time.timeScale = 0;
    }
}
