using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageController : MonoBehaviour {

    [Header("Ships Data")]
    [SerializeField] private List<ShipData> allShips; // хранилище всех ISO

    [Header("Selector")]
    [SerializeField] private ShipSelectorSmooth shipSelector; // ссылка на скрипт с движением кораблей
    private int selectedIndex = 0;

    [Header("UI - Stats")]
    [SerializeField] private Text healthText;
    [SerializeField] private Text damageText; // как я понимаю здесь должен быть щит
    [SerializeField] private Text speedText;

    [Header("Upgrade Values")]
    [SerializeField] private int healthUpgradeValue = 10;
    [SerializeField] private float damageUpgradeValue = 5f;
    [SerializeField] private float speedUpgradeValue = 1f; // знчения можно поменять на что угодно 

    private PlayerShipRuntimeData currentRuntime; //основной и первый runtime, который был создал
    private Dictionary <int, PlayerShipRuntimeData> shipRuntimes = new(); // Dictionary со всеми runtime для каждого кораблся
    public PlayerShipRuntimeData CurrentRuntime => currentRuntime;

    private void Start() {
        shipSelector.OnShipChanged += OnShipSelected;

        // Выбираем первый корабль при старте
        OnShipSelected(0);
        SelectShipInstant(selectedIndex);
    }

    // private void OnDestroy() {
    //     shipSelector.OnShipChanged -= OnShipSelected;
    // }

    private void OnShipSelected(int index) {

        if (index < 0 || index >= allShips.Count)
            return;

        // Если runtime уже есть — используем его
        if (!shipRuntimes.TryGetValue(index, out currentRuntime)) {
            currentRuntime = new PlayerShipRuntimeData(allShips[index]);
            shipRuntimes.Add(index, currentRuntime);
        }

        UpdateUI();
    }

    // Все методы улучшения можно объеденить вместе так как кнопка одна и улучшает все сразу.
    public void UpgradeHealth() {
        if (currentRuntime == null) return;

        currentRuntime.AddHealth(healthUpgradeValue);
        UpdateUI();
    }

    public void UpgradeDamage() {
        if (currentRuntime == null) return;

        currentRuntime.AddDamage(damageUpgradeValue);
        UpdateUI();
    }

    public void UpgradeSpeed() {
        if (currentRuntime == null) return;

        currentRuntime.AddSpeed(speedUpgradeValue, speedUpgradeValue);
        UpdateUI();
    }

    // Сразу жу отображает у каждого кораблся свои значения
    private void UpdateUI() {
        if (currentRuntime == null) return;

        healthText.text = $"{currentRuntime.maxHealth}";
        damageText.text = $"{currentRuntime.damage}";
        speedText.text = $"{currentRuntime.maxSpeed}";
    }

    public PlayerShipRuntimeData GetCurrentRuntimeData() {
        return currentRuntime;
    }

    private void SelectShipInstant(int index)
    {
        selectedIndex = index;

        shipSelector.SetIndexInstant(index);
        OnShipSelected(index); // создаёт / берёт RuntimeData
    }
}
