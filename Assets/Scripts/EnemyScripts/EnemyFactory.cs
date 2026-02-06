using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public GameObject CreateEnemy(EnemyData enemyData, Vector3 position, Quaternion rotation, Transform target) {

        // 1. Создаём врага
        GameObject enemy = Instantiate(
            enemyData.prefab,
            position,
            rotation
        );

        // 2. Ищем инициализатор
        EnemyInitializer initializer = enemy.GetComponent<EnemyInitializer>();

        // 3. Применяем данные
        initializer.Initialize(enemyData, target);

        return enemy;
    }
}
