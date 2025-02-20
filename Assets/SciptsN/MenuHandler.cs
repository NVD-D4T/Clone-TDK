using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Button menuButton;    // Nút Menu
    public Button confirmButton; // Nút Confirm
    public string menuSceneName; // Tên Scene Menu

    void Start()
    {
        confirmButton.gameObject.SetActive(false); // Ẩn Confirm ban đầu

        menuButton.onClick.AddListener(() =>
        {
            confirmButton.gameObject.SetActive(true); // Hiện Confirm khi nhấn Menu
        });

        confirmButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(menuSceneName); // Chuyển Scene khi nhấn Confirm
        });
    }
}