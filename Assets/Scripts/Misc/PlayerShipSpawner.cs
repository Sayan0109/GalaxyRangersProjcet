using UnityEngine;

public class PlayerShipSpawner : MonoBehaviour {
    public Transform spawnPoint;
    [SerializeField] private CameraFollow mainCamera;

    void Start() {
        var runtimeData = GameSession.Instance.SelectedShip;

        GameObject ship = Instantiate(
            runtimeData.shipData.shipPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        ShipInitializer initializer = ship.GetComponent<ShipInitializer>();
        if (initializer != null) {
            initializer.ApplyRuntimeData(runtimeData);
        }

        mainCamera.target = ship.transform;
    }
}