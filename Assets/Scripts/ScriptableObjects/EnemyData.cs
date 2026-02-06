using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject {

    [Header("Ship")]
    public EnemyType enemyType;
    public GameObject prefab;

    [Header("Basic Stats")]
    public float maxHealth = 100;
    public float movementSpeed = 20;
    //public float attackRange = 5;

    [Header("Combat")]
    public AttackData attackData;

}
