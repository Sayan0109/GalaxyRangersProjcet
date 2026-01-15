using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [Header("Mine Spawn Settings")]
    [SerializeField] private GameObject minePrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float spawnInterval = 8f;
    [SerializeField] private float minSpawnInterval = 2f; // ⬅ минимум 2 секунды

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMine();
            timer = 0f;
        }
    }

    private void SpawnMine()
    {
        if (minePrefab == null || spawnPoint == null)
            return;

        Instantiate(minePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // 🔘 Вызывается кнопкой / перком
    public void ReduceSpawnInterval()
    {
        spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 1f);
        Debug.Log($"Mine spawn interval: {spawnInterval}");
    }
}

