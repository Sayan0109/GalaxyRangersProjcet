using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour, IHealth {

    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;
    public float CurrentHealth {get; private set;} //доступен везде, но меняется только в этом скрипте

    public System.Action OnDeath; //условная функция которая существует везде для вызова действия смерти

    public void Init(float maxHealth) { //функция для устоновки здоровья врага
        this.maxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float amount) {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth); //подсчет здоровья чтобы никогда не был ни больше максимального, ни больше минимального здоровья

        if(CurrentHealth <= 0) {
            Die();
        }
    }

    public void Heal(float amount) {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public void Die() {
        OnDeath?.Invoke(); // вызов условной функции чтобы другие скрипты связанные с этим вызывали свои функции
        Destroy(gameObject);
    }

}
