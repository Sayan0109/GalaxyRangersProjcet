using UnityEngine;

    //Создает ассет внутри проекта
    [CreateAssetMenu(
        fileName = "New Ship",
        menuName = "Ship/Ship Data"
    )]

public class ShipData : ScriptableObject { //! Важно чтобы библиотека было не MonoBehaviour а ScriptableObject

    [Header("Ship")]
    public int shipID;
    public GameObject shipPrefab;

    [Header("Basic Characteristics")]

    public float maxHealth;
    public float damage;
    public float maxSpeed;
    public float rotationSpeed;
    // public float fireRate;
    // public float abilityCooldown;
    // public float abilityDuration;

    //Способностей пока нету
}
