using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform enemy; // Tham chiếu đến đối tượng quái vật
    public Vector3 offset; // Độ lệch để thanh máu nằm phía trên quái vật

    void Start()
    {
        // Kiểm tra nếu enemy không null và cập nhật offset
        if (enemy != null)
        {
            offset = new Vector3(0, 2, 0); // Đặt độ lệch vị trí thanh máu (ví dụ: phía trên đầu quái vật)
        }
    }

    void Update()
    {
        if (enemy != null)
        {
            // Cập nhật vị trí thanh máu
            transform.position = Camera.main.WorldToScreenPoint(enemy.position + offset);
        }
    }
}
