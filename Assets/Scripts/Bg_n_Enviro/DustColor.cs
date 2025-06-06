using UnityEngine;

public class DustColor : MonoBehaviour
{
    public Color sandColor = new Color(1f, 0.9f, 0.7f, 0.5f);
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = sandColor;
    }
}
