using UnityEngine;

public class ShipInitializer : MonoBehaviour {
    
    private PlayerMovement movement;
    private TurretController turret;

    void Awake() {
        movement = GetComponent<PlayerMovement>();
        turret = GetComponentInChildren<TurretController>();
    }

    public void ApplyRuntimeData(PlayerShipRuntimeData data) {
        Debug.Log("🚀 Применяем данные корабля:");

        Debug.Log($"MaxSpeed: {data.maxSpeed}");
        Debug.Log($"RotationSpeed: {data.rotationSpeed}");
        Debug.Log($"Damage: {data.damage}");

        // ---- PlayerMovement ----
        if (movement != null) {
            movement.maxSpeed = data.maxSpeed;
            movement.rotationSpeed = data.rotationSpeed;
        }

        // ---- TurretController ----
        if (turret != null) {
            turret.damage = data.damage;
        }
    }

}
