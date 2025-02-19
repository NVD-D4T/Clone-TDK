using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BlinkText : MonoBehaviour
{
    public Text tapToStartText; // Tham chiếu đến Text component
    public float blinkSpeed = 1.0f; // Tốc độ nhấp nháy

    private void Start()
    {
        // Bắt đầu Coroutine để làm chữ nhấp nháy
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true) // Lặp vô hạn
        {
            // Làm chữ trong suốt (alpha = 0)
            tapToStartText.color = new Color(tapToStartText.color.r, tapToStartText.color.g, tapToStartText.color.b, 0);
            yield return new WaitForSeconds(blinkSpeed / 2); // Chờ một nửa thời gian

            // Làm chữ hiện rõ (alpha = 1)
            tapToStartText.color = new Color(tapToStartText.color.r, tapToStartText.color.g, tapToStartText.color.b, 1);
            yield return new WaitForSeconds(blinkSpeed / 2); // Chờ một nửa thời gian
        }
    }

    // Hàm này sẽ được gọi khi nhấn vào nút
    public void OnTapToStart()
    {
        SceneManager.LoadScene("SampleScene"); // Thay "GameScene" bằng tên cảnh game của bạn
    }
}