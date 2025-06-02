using System;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out Collector collector);
            collector.AddNotes();
            PickUpManager.Instance.PlayPickUp();
            Destroy(gameObject);
        }
    }

    //bounce animation on a curve, dotween
}
