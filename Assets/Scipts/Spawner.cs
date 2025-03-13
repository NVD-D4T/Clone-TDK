using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemyType1Prefab;
    public GameObject enemyType2Prefab;
    public GameObject enemyType3Prefab;
    public GameObject healthBarPrefab;
    public Transform spawnPoint;
    public Button spawnButton;
    public Canvas canvas;
    public PlayerHealth playerHealth; // Tham chiếu đến PlayerHealth script
    private int currentWave = 0;

    void Start()
    {
        spawnButton.onClick.AddListener(() => { if (!HasActiveEnemies()) SpawnWave(); });
        StartCoroutine(StartWaveAfterDelay(10f)); // Bắt đầu đợt quái đầu tiên sau 10 giây
    }

    void SpawnWave()
    {
        if (!HasActiveEnemies())
        {
            if (currentWave == 0)
            {
                StartCoroutine(SpawnEnemies(5, 0, 0)); // Đợt 1: 5 con loại 1
            }
            else if (currentWave == 1)
            {
                StartCoroutine(SpawnEnemies(5, 5, 0)); // Đợt 2: 5 con loại 1 và 5 con loại 2
            }
            else if (currentWave == 2)
            {
                StartCoroutine(SpawnEnemies(5, 7, 8)); // Đợt 3: 5 con loại 1, 7 con loại 2 và 8 con loại 3
            }
        }
    }

    IEnumerator StartWaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!HasActiveEnemies())
        {
            SpawnWave();
        }
    }

    IEnumerator SpawnEnemies(int type1Count, int type2Count, int type3Count)
    {
        for (int i = 0; i < type1Count; i++)
        {
            SpawnEnemy(enemyType1Prefab);
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < type2Count; i++)
        {
            SpawnEnemy(enemyType2Prefab);
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < type3Count; i++)
        {
            SpawnEnemy(enemyType3Prefab);
            yield return new WaitForSeconds(0.2f);
        }
        currentWave++;
        if (currentWave < 3)
        {
            StartCoroutine(StartWaveAfterDelay(15f)); // Chuyển sang đợt quái tiếp theo sau 15 giây
        }
        else
        {
            StartCoroutine(CheckForWinCondition());
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject healthBar = Instantiate(healthBarPrefab, canvas.transform);
        HealthBarSlider healthBarSlider = healthBar.GetComponent<HealthBarSlider>();
        healthBarSlider.enemy = enemy.GetComponent<Enemy>();
        healthBar.transform.SetParent(canvas.transform);
        RectTransform healthBarRect = healthBar.GetComponent<RectTransform>();
        healthBarRect.anchorMin = new Vector2(0.5f, 0);
        healthBarRect.anchorMax = new Vector2(0.5f, 0);
        healthBarRect.pivot = new Vector2(0.5f, 0);
        healthBarRect.anchoredPosition = new Vector2(0, 2);
        FollowEnemy followEnemyScript = healthBar.GetComponent<FollowEnemy>();
        if (followEnemyScript != null)
        {
            followEnemyScript.SetTarget(enemy.transform);
        }
    }

    bool HasActiveEnemies()
    {
        return GameObject.FindWithTag("Enemy") != null;
    }

    IEnumerator CheckForWinCondition()
    {
        while (HasActiveEnemies())
        {
            yield return new WaitForSeconds(1f);
        }
        playerHealth.CheckWinCondition(); // Gọi phương thức kiểm tra điều kiện chiến thắng
    }
}
