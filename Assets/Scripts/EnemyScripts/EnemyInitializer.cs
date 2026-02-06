using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
[RequireComponent(typeof(BasicEnemyMovement))]
[RequireComponent(typeof(EnemyBasicAttack))]
[RequireComponent(typeof(EnemyHealthComponent))]
public class EnemyInitializer : MonoBehaviour {

    private EnemyAI ai;
    private BasicEnemyMovement movement;
    private EnemyBasicAttack attack;
    private EnemyHealthComponent health;

    void Awake() {
        ai = GetComponent<EnemyAI>();
        movement = GetComponent<BasicEnemyMovement>();
        attack = GetComponent<EnemyBasicAttack>();
        health = GetComponent<EnemyHealthComponent>();
    }

    public void Initialize(EnemyData data, Transform target) {
        // ===== Movement =====
        movement.Init(data.movementSpeed);
        movement.SetTarget(target);

        // ===== Attack =====
        attack.Init(data.attackData);
        attack.SetTarget(target);

        // ===== Health =====
        health.Init(data.maxHealth);

        // ===== AI =====
        ai.SetTarget(target);
        //ai.EnableAI();
    }
}
