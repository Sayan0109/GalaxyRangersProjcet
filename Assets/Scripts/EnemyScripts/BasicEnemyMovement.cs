using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {
    private float moveSpeed;
    private Transform target;
    private bool canMove = false;

    // Инициализация из EnemyData
    public void Init(float speed) {
        moveSpeed = speed;
    }

    // Установка цели (игрок)
    public void SetTarget(Transform target) {
        this.target = target;
    }

    public void EnableMovement() {
        canMove = true;
    }

    public void DisableMovement() {
        canMove = false;
    }

    public void Move() {
        if (!canMove || target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        if (dir != Vector3.zero) {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10f * Time.deltaTime);
        }
    }
}
