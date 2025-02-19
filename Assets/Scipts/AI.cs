using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 5f;
    private WP Wpoint;
    private int waypointIndex = 0;
    private bool isMoving = true;
    private PlayerHealth playerHealth; // Tham chiếu đến PlayerHealth

    void Start()
    {
        // Tìm đối tượng Waypoint bằng tag
        GameObject waypointObject = GameObject.FindWithTag("Waypoint");
        if (waypointObject != null)
        {
            Wpoint = waypointObject.GetComponent<WP>();
        }

        // Tìm đối tượng PlayerHealth
        playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        // Kiểm tra trạng thái di chuyển và tồn tại waypoint
        if (!isMoving || Wpoint == null || Wpoint.waypoints == null || Wpoint.waypoints.Length == 0)
        {
            return;
        }

        // Quay mặt về hướng waypoint hiện tại
        Vector3 direction = Wpoint.waypoints[waypointIndex].position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * speed);

        // Di chuyển đến waypoint hiện tại
        transform.position = Vector3.MoveTowards(transform.position, Wpoint.waypoints[waypointIndex].position, speed * Time.deltaTime);

        // Kiểm tra nếu đã đến gần waypoint hiện tại
        if (Vector3.Distance(transform.position, Wpoint.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;

            // Nếu đã đi hết tất cả waypoint, giảm máu của người chơi và hủy đối tượng quái vật
            if (waypointIndex >= Wpoint.waypoints.Length)
            {
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                }
                Destroy(gameObject);
            }
        }
    }
}
