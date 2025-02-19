using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); // Thay "GameScene" bằng tên cảnh game của bạn
    }
}