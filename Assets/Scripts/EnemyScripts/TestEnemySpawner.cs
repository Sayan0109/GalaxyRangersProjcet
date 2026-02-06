using UnityEngine;

public class TestEnemySpawner : MonoBehaviour {

    [SerializeField] private EnemyFactory factory;
    [SerializeField] private EnemyData[] enemyData;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnInterval = 3f;

    private Transform player;

    void Start() {
        Invoke(nameof(Locate), 1f);

        InvokeRepeating(nameof(Spawn), 2f, spawnInterval);
    }

    void Spawn() {
        if (factory == null || enemyData == null || player == null)
            return;

        Vector3 spawnPoint = GetRandomPointOnCircle();
        
        int index = Random.Range(0, enemyData.Length);

        factory.CreateEnemy(
            enemyData[index],
            spawnPoint,
            Quaternion.identity,
            player
        );
    }

    void Locate() {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    Vector3 GetRandomPointOnCircle() {
        float angle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 offset = new Vector3(
            Mathf.Cos(angle),
            0f,
            Mathf.Sin(angle)
        ) * spawnRadius;

        return transform.position + offset;
    }

    // Просто для удобства в редакторе
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
