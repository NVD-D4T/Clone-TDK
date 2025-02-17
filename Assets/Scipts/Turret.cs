using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRange = 10f; // Tầm phát hiện quái vật
    public GameObject bulletPrefab; // Prefab của đạn
    public Transform firePoint; // Điểm bắn đạn
    public float fireRate = 1f; // Tốc độ bắn (đạn/giây)
    private float fireCooldown = 0f;

    void Update()
    {
        // Kiểm tra cooldown bắn
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }

        // Tìm quái vật trong tầm
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                // Bắn đạn nếu có quái vật trong tầm và cooldown đã hết
                if (fireCooldown <= 0)
                {
                    Shoot(hitCollider.transform);
                    fireCooldown = 1f / fireRate;
                }
            }
        }
    }

    void Shoot(Transform target)
    {
        // Tạo đạn và bắn về phía mục tiêu
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(target);
        }
    }

    // Vẽ tầm phát hiện trong chế độ Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
