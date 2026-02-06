using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelectorSmooth : MonoBehaviour
{
    [Header("Ships")]
    [SerializeField] private List<Transform> ships;

    [Header("Points")]
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private Transform rightPoint;

    [Header("Animation")]
    [SerializeField] private float moveDuration = 0.35f;

    //private int currentIndex = 0;
    public int CurrentIndex { get; private set; }

    private bool isMoving = false;

    public System.Action<int> OnShipChanged;

    private void Start()
    {
        ForceToPoints();
    }

    public void NextShip()
    {
        if (isMoving) return;

        CurrentIndex = (CurrentIndex + 1) % ships.Count;
        StartCoroutine(MoveShips());

        OnShipChanged?.Invoke(CurrentIndex);
    }

    public void PrevShip()
    {
        if (isMoving) return;

        CurrentIndex--;
        if (CurrentIndex < 0)
            CurrentIndex = ships.Count - 1;

        StartCoroutine(MoveShips());

        OnShipChanged?.Invoke(CurrentIndex);
    }

    private IEnumerator MoveShips()
    {
        isMoving = true;

        Dictionary<Transform, Vector3> startPos = new();
        Dictionary<Transform, Vector3> targetPos = new();

        foreach (var ship in ships)
            startPos[ship] = ship.position;

        for (int i = 0; i < ships.Count; i++)
            targetPos[ships[i]] = GetTargetPoint(i).position;

        float time = 0f;

        while (time < moveDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / moveDuration);

            foreach (var ship in ships)
                ship.position = Vector3.Lerp(startPos[ship], targetPos[ship], t);

            yield return null;
        }

        // ��������
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].SetParent(GetTargetPoint(i));
            ships[i].localPosition = Vector3.zero;
        }

        isMoving = false;
    }

    private Transform GetTargetPoint(int index)
    {
        if (index == CurrentIndex)
            return centerPoint;

        if (index == (CurrentIndex + 1) % ships.Count)
            return rightPoint;

        return leftPoint;
    }

    private void ForceToPoints()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].SetParent(GetTargetPoint(i));
            ships[i].localPosition = Vector3.zero;
        }
    }

    /*public void ConfirmShip()
    {
        PlayerPrefs.SetInt("SelectedShipID", currentIndex);
        PlayerPrefs.Save();
        Debug.Log("Selected Ship ID: " + currentIndex);
    }*/

    public void SetIndexInstant(int index) {
        CurrentIndex = index;
        ForceToPoints();
    }

}
