using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Attacks/Debug Melee Attack")]
public class AttackTest : AttackData {
    
    public override void Execute(GameObject attacker, GameObject target) {
        if (attacker == null || target == null)
            return;

        Debug.Log(
            $"Игрок {target.name} был атакован на {damage} урона " +
            $"врагом {attacker.name}"
        );
    }

}
