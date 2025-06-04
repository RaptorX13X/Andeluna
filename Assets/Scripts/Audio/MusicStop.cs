using UnityEngine;
using FMODUnity;

public class MusicStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.instance.StopMusic();
            Destroy(this);
        }
    }
}
