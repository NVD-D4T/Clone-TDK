using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // Gán Panel Pause từ Inspector

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false); // Ẩn Panel lúc đầu
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // Dừng hoặc tiếp tục game
    }
}