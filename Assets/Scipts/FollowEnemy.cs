using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform enemy; // Tham chiếu đến đối tượng quái vật
    public Vector3 offset = new Vector3(0, 2, 0); // Độ lệch để thanh máu nằm phía trên quái vật

    void Update()
    {
        if (enemy != null)
        {
            // Cập nhật vị trí thanh máu
            transform.position = Camera.main.WorldToScreenPoint(enemy.position + offset);
        }
    }

    public void SetTarget(Transform target)
    {
        enemy = target;
    }
}
