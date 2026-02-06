using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkManager : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // корабль

    void Update()
    {
        // если не назначили вручную Ч ищем
        if (target == null)
        {
            // вариант 1: по тегу (–≈ ќћ≈Ќƒ”≈“—я)
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }

        // сразу ставим позицию
        if (target != null)
            transform.position = target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // следуем за кораблЄм
        transform.position = target.position;
    }
}
