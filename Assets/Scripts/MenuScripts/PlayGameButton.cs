using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayGameButton : MonoBehaviour {

    [SerializeField] private GarageController garage;
    [SerializeField] private string gameSceneName = "Game";

    public void StartGame() {
        var runtime = garage.CurrentRuntime;

        if (runtime == null) {
            Debug.LogError("No ship selected!");
            return;
        }

        GameSession.Instance.SetPlayerShip(runtime);
        SceneManager.LoadScene(gameSceneName);
    }
}
