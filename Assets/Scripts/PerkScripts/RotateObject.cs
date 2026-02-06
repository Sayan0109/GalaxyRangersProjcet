using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 0, 90f);
    // градусы в секунду

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
