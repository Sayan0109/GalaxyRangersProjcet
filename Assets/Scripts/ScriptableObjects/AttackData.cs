using UnityEngine;

public abstract class AttackData : ScriptableObject {

    [Header("Basic Settings")]
    public float damage = 10;
    public float attackRange = 5;
    public float cooldown = 1;

    //Выполнение Атаки
    public abstract void Execute(GameObject attacker, GameObject target);

}
