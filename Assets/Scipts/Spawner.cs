using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của quái vật
    public GameObject healthBarPrefab; // Prefab của thanh máu
    public Transform spawnPoint; // Điểm xuất hiện quái vật
    public Button spawnButton; // Nút nhấn để tạo quái vật
    public Canvas canvas; // Canvas để hiển thị thanh máu
    public int wave1Count = 5;
    public int wave2Count = 10;
    public int wave3Count = 20;
    private int currentWave = 0;

    void Start()
    {
        // Thêm sự kiện OnClick cho nút
        spawnButton.onClick.AddListener(() => { if (!HasActiveEnemies()) SpawnWave(); });
        StartCoroutine(StartWaveAfterDelay(10f, wave1Count)); // Bắt đầu đợt quái đầu tiên sau 10 giây
    }

    void SpawnWave()
    {
        if (!HasActiveEnemies())
        {
            if (currentWave == 0)
            {
                StartCoroutine(SpawnEnemies(wave1Count));
            }
            else if (currentWave == 1)
            {
                StartCoroutine(SpawnEnemies(wave2Count));
            }
            else if (currentWave == 2)
            {
                StartCoroutine(SpawnEnemies(wave3Count));
            }
        }
    }

    IEnumerator StartWaveAfterDelay(float delay, int waveCount)
    {
        yield return new WaitForSeconds(delay);
        if (!HasActiveEnemies()) // Kiểm tra nếu không có con quái nào còn hoạt động
        {
            StartCoroutine(SpawnEnemies(waveCount));
        }
    }

    IEnumerator SpawnEnemies(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Sinh ra quái vật tại vị trí cố định
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Tạo thanh máu và gán nó cho quái vật
            GameObject healthBar = Instantiate(healthBarPrefab, canvas.transform);
            HealthBarSlider healthBarSlider = healthBar.GetComponent<HealthBarSlider>();
            healthBarSlider.enemy = enemy.GetComponent<Enemy>();

            // Đặt thanh máu là con của canvas để nó hiển thị trên màn hình
            healthBar.transform.SetParent(canvas.transform);

            // Cài đặt RectTransform của thanh máu
            RectTransform healthBarRect = healthBar.GetComponent<RectTransform>();
            healthBarRect.anchorMin = new Vector2(0.5f, 0); // Đặt anchor ở giữa đáy
            healthBarRect.anchorMax = new Vector2(0.5f, 0); // Đặt anchor ở giữa đáy
            healthBarRect.pivot = new Vector2(0.5f, 0); // Đặt pivot ở giữa đáy
            healthBarRect.anchoredPosition = new Vector2(0, 2); // Cài đặt vị trí của thanh máu phía trên đầu quái vật

            // Gán đối tượng quái vật cho script FollowEnemy
            FollowEnemy followEnemyScript = healthBar.GetComponent<FollowEnemy>();
            if (followEnemyScript != null)
            {
                followEnemyScript.SetTarget(enemy.transform);
            }

            // Đợi 1 giây trước khi tạo quái vật tiếp theo
            yield return new WaitForSeconds(1f);
        }
        currentWave++;
        
        // Kiểm tra nếu đã hết tất cả đợt quái, kết thúc
        if (currentWave < 3)
        {
            if (currentWave == 1)
            {
                StartCoroutine(StartWaveAfterDelay(15f, wave2Count)); // Bắt đầu đợt quái thứ 2 sau 15 giây
            }
            else if (currentWave == 2)
            {
                StartCoroutine(StartWaveAfterDelay(15f, wave3Count)); // Bắt đầu đợt quái thứ 3 sau 15 giây
            }
        }
    }

    bool HasActiveEnemies()
    {
        // Kiểm tra nếu có bất kỳ đối tượng nào có tag "Enemy"
        return GameObject.FindWithTag("Enemy") != null;
    }
}
