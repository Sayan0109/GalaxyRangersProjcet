using UnityEngine;

public class SimpleCameraMove : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 3f;

    private Transform target;

    void Start()
    {
        target = leftPoint; // стартовая точка
    }

    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            Time.deltaTime * speed
        );
    }

    public void MoveLeft()
    {
        target = leftPoint;
    }

    public void MoveRight()
    {
        target = rightPoint;
    }
}

