using System;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float power;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.JumpPad(power);
        }
    }
}
