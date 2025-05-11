using UnityEngine;
using System.Linq;

public class LeverPlatformSpawn : MonoBehaviour
{
    [SerializeField] private Lever[] levers;
    [SerializeField] private GameObject platform;

    public void CheckDoor()
    {
        if (levers.Any(lever => !lever.clicked)) return;
        
        OpenDoor();
    }

    private void OpenDoor()
    {
        platform.SetActive(true);
    }
}
