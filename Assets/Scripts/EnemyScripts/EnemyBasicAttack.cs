using Unity.VisualScripting;
using UnityEngine;

public class EnemyBasicAttack : MonoBehaviour {
    
    private AttackData attackData;
    private float nextAttackTime;
    private Transform target;

    public float AttackRange => attackData != null ? attackData.attackRange : 5f;

    public void Init(AttackData data) {
        attackData = data;
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }

    public bool IsInRange() {
    if (attackData == null || target == null) return false;

    float dist = Vector3.Distance(transform.position, target.position);
    return dist <= attackData.attackRange;
}

public bool IsCooldownReady() {
    return Time.time >= nextAttackTime;
}
public bool CanAttack() {
    return IsInRange() && IsCooldownReady();
}

    public void TryAttack() {
        if (!CanAttack()) return;

        attackData.Execute(gameObject, target.gameObject);
        nextAttackTime = Time.time + attackData.cooldown;
    }

    // void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackData.attackRange);
    // }
}
