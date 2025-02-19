using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("level2"); // Thay "GameScene" bằng tên cảnh game của bạn
    }
}