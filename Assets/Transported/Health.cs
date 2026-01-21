using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [Header("Health Settings")]
    public float maxHealth = 100f;

    public float MaxHealth => maxHealth;
    public float CurrentHealth { get; private set; }

    public event System.Action OnDeath;

    private Rigidbody rb;

    void Start()
    {
        CurrentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        //Debug.Log($"{gameObject.name} HP: {CurrentHealth}/{MaxHealth}");
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        //Debug.Log($"{gameObject.name} ������� ����: {amount}, ������� HP: {CurrentHealth}/{MaxHealth}");

        if (CurrentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        Debug.Log($"{gameObject.name} ����������� ��������: {amount}, ������� HP: {CurrentHealth}/{MaxHealth}");
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} ����!");

        // ������������� ��������
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // ����� ������������� ������, ����� ������ �� ��������
        }

        OnDeath?.Invoke();
    }
}