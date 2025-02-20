using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Gán Panel Pause vào đây
    public GameObject pauseButton;    // Gán nút Pause vào đây

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false); // Ẩn panel khi bắt đầu
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);
        pauseButton.SetActive(!isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Dừng game
        }
        else
        {
            Time.timeScale = 1f; // Tiếp tục game
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Đảm bảo game chạy lại bình thường
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load lại map hiện tại
    }
}