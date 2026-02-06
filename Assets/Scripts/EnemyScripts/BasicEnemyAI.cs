using UnityEngine;

//теперь скрипт не будет применяться если у него нету этих компонентов
[RequireComponent(typeof(BasicEnemyMovement))]
[RequireComponent(typeof(EnemyBasicAttack))]
[RequireComponent(typeof(EnemyHealthComponent))]
public class EnemyAI : MonoBehaviour {
    
    [Header("References")]
    private Transform target;

    //скрипты которые есть на враге
    private BasicEnemyMovement movement;
    private EnemyBasicAttack attack;
    private EnemyHealthComponent health;

    private EnemyState currentState;

    public enum EnemyState {
        Idle,
        Chase,
        Attack,
        Dead
    }

    void Awake() {
        movement = GetComponent<BasicEnemyMovement>();
        attack = GetComponent<EnemyBasicAttack>();
        health = GetComponent<EnemyHealthComponent>();

        health.OnDeath += OnDeath;
    }

    void Start() {
        //enabled = false;
    }

    void FixedUpdate() {
        if (currentState == EnemyState.Dead || target == null) //если игрока нету или враг мертв ничегоне будет срабатывать
            return;

        switch (currentState) {
            case EnemyState.Idle:
                UpdateIdle();
                break;

            case EnemyState.Chase:
                UpdateChase();
                break;

            case EnemyState.Attack:
                UpdateAttack();
                break;
        }
    }

    void UpdateIdle() {
    if (attack.IsInRange())
        SetState(EnemyState.Attack);
    else
        SetState(EnemyState.Chase);
}
void UpdateChase() {
    movement.EnableMovement();
    movement.Move();

    if (attack.IsInRange())
        SetState(EnemyState.Attack);
}
void UpdateAttack() {
    movement.DisableMovement();

    attack.TryAttack(); // сам проверит кулдаун

    if (!attack.IsInRange())
        SetState(EnemyState.Chase);
}

    public void SetTarget(Transform target) {
        this.target = target;
    }

    // public void EnableAI() {
    //     currentState = EnemyState.Chase;
    //     enabled = true;
    // }

    void SetState(EnemyState newState) {
        if (currentState == newState) return;

        currentState = newState;
    }

    void OnDeath() {
        SetState(EnemyState.Dead);
        movement.DisableMovement();
        enabled = false;
    }
}