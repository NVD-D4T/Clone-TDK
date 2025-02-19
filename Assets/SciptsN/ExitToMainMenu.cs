using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitPanel : MonoBehaviour
{
    public void ExitToMainMenu() // Thay "MainMenu" bằng tên Scene của bạn
    {
        SceneManager.LoadScene("Menu");
    }
}
