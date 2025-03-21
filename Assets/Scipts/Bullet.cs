using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Tốc độ bay của đạn
    public float damage = 10f; // Sát thương của đạn
    public Transform bulletHead; // Transform của đầu đạn
    private Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Di chuyển đạn về phía mục tiêu
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Quay đầu đạn về phía mục tiêu
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        bulletHead.rotation = lookRotation;

        // Di chuyển cả đầu và đuôi đạn về phía trước
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Gây sát thương cho mục tiêu
        }

        Destroy(gameObject); // Hủy đạn sau khi gây sát thương
    }
}
