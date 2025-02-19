using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource; // Tham chiếu đến AudioSource chứa âm thanh hiệu ứng

    private void Start()
    {
        // Lấy component Button và thêm sự kiện onClick
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Phát âm thanh hiệu ứng
        }
    }
}