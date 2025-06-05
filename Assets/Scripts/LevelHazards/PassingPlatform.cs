using System;
using UnityEngine;

public class PassingPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D collider;

    private void Update()
    {
        if (PlayerController.instance.transform.position.y - 1f < transform.position.y || Input.GetKeyDown(KeyCode.S))
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
    }
}
