using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 5f;
    private WP Wpoint;
    private int waypointIndex = 0;
    private bool isMoving = true;

    void Start()
    {
        // Tìm đối tượng Waypoint bằng tag
        GameObject waypointObject = GameObject.FindWithTag("Waypoint");
        if (waypointObject != null)
        {
            Wpoint = waypointObject.GetComponent<WP>();
        }
    }

    void Update()
    {
        // Kiểm tra trạng thái di chuyển và tồn tại waypoint
        if (!isMoving || Wpoint == null || Wpoint.waypoints == null || Wpoint.waypoints.Length == 0)
        {
            return;
        }

        // Di chuyển đến waypoint hiện tại
        transform.position = Vector3.MoveTowards(transform.position, Wpoint.waypoints[waypointIndex].position, speed * Time.deltaTime);

        // Kiểm tra nếu đã đến gần waypoint hiện tại
        if (Vector3.Distance(transform.position, Wpoint.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;

            // Nếu đã đi hết tất cả waypoint, dừng lại ở waypoint cuối cùng
            if (waypointIndex >= Wpoint.waypoints.Length)
            {
                isMoving = false;
            }
        }
    }
}
