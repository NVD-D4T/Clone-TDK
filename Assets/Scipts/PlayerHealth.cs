using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Máu tối đa của người chơi
    private int currentHealth; // Máu hiện tại của người chơi
    public Text healthText; // Text UI để hiển thị máu

    public GameObject gameOverPanel; // Tham chiếu đến Panel thông báo Game Over
    public GameObject winPanel; // Tham chiếu đến Panel thông báo chiến thắng
    public Button restartButton; // Tham chiếu đến nút Restart
    public Button menuButton; // Tham chiếu đến nút Menu
    public Button restartButton1; // Tham chiếu đến nút Restart
    public Button menuButton1; // Tham chiếu đến nút Menu

    void Start()
    {
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        UpdateHealthUI(); // Cập nhật UI
        gameOverPanel.SetActive(false); // Ẩn Panel thông báo Game Over lúc đầu
        winPanel.SetActive(false); // Ẩn Panel thông báo chiến thắng lúc đầu

        restartButton.onClick.AddListener(RestartScene); // Gắn sự kiện khi nhấn nút Restart
        menuButton.onClick.AddListener(LoadMenuScene); // Gắn sự kiện khi nhấn nút Menu
        restartButton1.onClick.AddListener(RestartScene); // Gắn sự kiện khi nhấn nút Restart
        menuButton1.onClick.AddListener(LoadMenuScene); // Gắn sự kiện khi nhấn nút Menu
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

    public void CheckWinCondition()
    {
        if (currentHealth > 0)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true); // Hiển thị Panel thông báo chiến thắng
        Time.timeScale = 0;
    }

    private void UpdateHealthUI()
    {
        healthText.text = "       " + currentHealth.ToString(); // Cập nhật text UI hiển thị máu
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true); // Hiển thị Panel thông báo Game Over
        Time.timeScale = 0;
    }

    private void RestartScene()
    {
        Time.timeScale = 1; // Đặt lại Time.timeScale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại scene hiện tại
    }

    private void LoadMenuScene()
    {
        Time.timeScale = 1; // Đặt lại Time.timeScale
        SceneManager.LoadScene("Menu"); // Tải scene "Menu"
    }
}
