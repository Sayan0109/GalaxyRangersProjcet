using System.Collections.Generic;
using UnityEngine;

public class PerkOrbitRotation : MonoBehaviour
{
    [Header("Orbit Settings")]
    [SerializeField] private Transform center;
    [SerializeField] private List<Transform> points = new List<Transform>();

    [SerializeField] private float radius = 2f;
    [SerializeField] private float rotationSpeed = 90f; // градусов/сек

    private float currentAngle;

    private void Start()
    {
        ArrangePoints();
    }

    private void Update()
    {
        RotatePoints();
    }

    private void ArrangePoints()
    {
        int count = points.Count;
        if (count == 0) return;

        float step = 360f / count;

        for (int i = 0; i < count; i++)
        {
            if (points[i] == null) continue;

            float angle = step * i * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(angle) * radius,
                0f,
                Mathf.Sin(angle) * radius
            );

            points[i].position = center.position + offset;
        }
    }

    private void RotatePoints()
    {
        int count = points.Count;
        if (count == 0) return;

        currentAngle += rotationSpeed * Time.deltaTime;
        float step = 360f / count;

        for (int i = 0; i < count; i++)
        {
            if (points[i] == null) continue;

            float angle = (currentAngle + step * i) * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(
                Mathf.Cos(angle) * radius,
                0f,
                Mathf.Sin(angle) * radius
            );

            points[i].position = center.position + offset;
        }
    }
}
