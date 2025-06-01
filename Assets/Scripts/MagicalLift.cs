using System;
using UnityEngine;

public class MagicalLift : MonoBehaviour
{
    [SerializeField] private float power;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.Lift(power);
        }
    }
}
