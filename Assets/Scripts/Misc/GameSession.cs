using UnityEngine;

public class GameSession : MonoBehaviour {


    //сохраняет данные с рантайм и переносит данные на сцену Game
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
