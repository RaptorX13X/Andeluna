using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Terrain"))
        {
            Debug.Log(other.tag);
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Terrain"))
        {
            grounded = false;
        }
    }
}
