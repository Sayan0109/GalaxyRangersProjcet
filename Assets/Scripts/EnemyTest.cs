using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {
    
    [SerializeField] private AttackData attackData;

    void Start() {
        BasicEnemyMovement basicEnemyMovement = GetComponent<BasicEnemyMovement>();
        basicEnemyMovement.Init(3);
        basicEnemyMovement.SetTarget(transform);
        EnemyBasicAttack enemyBasicAttack = GetComponent<EnemyBasicAttack>();
        enemyBasicAttack.Init(attackData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
