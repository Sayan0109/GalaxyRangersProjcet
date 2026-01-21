using UnityEngine;

public class GameSession : MonoBehaviour {
    public static GameSession Instance { get; private set; }

    public PlayerShipRuntimeData SelectedShip { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerShip(PlayerShipRuntimeData runtime) {
        SelectedShip = runtime;
    }
}
