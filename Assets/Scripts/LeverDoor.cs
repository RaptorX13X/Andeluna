using System.Linq;
using UnityEngine;

public class LeverDoor : MonoBehaviour
{
    [SerializeField] private Lever[] levers;

    public void CheckDoor()
    {
        if (levers.Any(lever => !lever.clicked)) return;
        
        OpenDoor();
    }

    private void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
