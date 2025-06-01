using System;
using UnityEngine;

public class PointDoor : MonoBehaviour
{
    [SerializeField] private Collector points;
    [SerializeField] private int amount;

    private void Update()
    {
        if (points.notesAmount == amount)
        {
            gameObject.SetActive(false);
        }
    }
}
