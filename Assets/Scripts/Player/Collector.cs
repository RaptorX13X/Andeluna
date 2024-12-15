using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int notesAmount = 0;

    public void AddNotes()
    {
        notesAmount += 1;
    }
}
