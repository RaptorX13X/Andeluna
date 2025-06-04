using UnityEngine;

public class LeverPlatform : MonoBehaviour
{
    public bool clicked;
    [SerializeField] private LeverPlatformSpawn platform;
    [SerializeField] PlayerAudio PlayerAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out InputReader input))
        {
            input.InteractEvent += Interact;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out InputReader input))
        {
            input.InteractEvent -= Interact;
        }
    }

    private void Interact()
    {
        if (clicked) return;
        clicked = true;
        PlayerAudio.PlayInteraction();
        platform.CheckDoor();
    }
}
