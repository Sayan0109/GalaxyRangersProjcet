using UnityEngine;

public class DroneFollowPoint : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform targetPoint;

    [Header("Movement")]
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float stopDistance = 2f;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 5f;

    void Update()
    {
        if (targetPoint == null) return;

        Vector3 direction = targetPoint.position - transform.position;
        float distance = direction.magnitude;

        // Поворот к цели
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Движение, если дальше нужной дистанции
        if (distance > stopDistance)
        {
            Vector3 moveDir = direction.normalized;
            transform.position += moveDir * followSpeed * Time.deltaTime;
        }
    }
}
