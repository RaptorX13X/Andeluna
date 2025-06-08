using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool clicked;
    private Animator animator;
    [SerializeField] private LeverDoor door;
    [SerializeField] private bool moreDoors;
    [SerializeField] private LeverDoor door2;
    [SerializeField] PlayerAudio PlayerAudio;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
        if (animator != null)
        {
            animator.SetTrigger("Click");
        }
        PlayerAudio.PlayInteraction();
        door.CheckDoor();
        if (moreDoors)
        {
            door2.CheckDoor();
        }
    }
}
